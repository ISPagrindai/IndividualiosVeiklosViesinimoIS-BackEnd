using is_backend.Entities;
using is_backend.Helpers;
using is_backend.Models;
using is_backend.Models_2;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace is_backend.Services
{
    public interface IUserService
    {
        PrisijungimoDuomenys Authenticate(string username, string password);
        PrisijungimoDuomenys Create(RegisterModel user, string password);
        PrisijungimoDuomenys CreateCompany(RegisterCompanyModel company, string password);
    }

    public class UserService : IUserService
    {

        private readonly individuali_veiklaContext _db;

        public UserService(individuali_veiklaContext db)
        {
            _db = db;
        }

        public PrisijungimoDuomenys Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _db.PrisijungimoDuomenys.SingleOrDefault(x => x.Epastas == username);

            if (user == null) return null;

            if (!VerifyPasswordHash(password, user.Slaptazodis, user.SlaptazodisSalt))
                return null;

            return user;
        }

        public PrisijungimoDuomenys Create(RegisterModel user, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (_db.PrisijungimoDuomenys.Any(x => x.Epastas == user.Epastas))
                throw new AppException("Email \"" + user.Epastas + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var duomenys = new PrisijungimoDuomenys();
            duomenys.Epastas = user.Epastas;
            duomenys.FkTipas = 2;
            duomenys.Slaptazodis = passwordHash;
            duomenys.SlaptazodisSalt = passwordSalt;

            var vartotojas = new Vartotojas();
            MapVartotojas(vartotojas, user);

            _db.Vartotojas.Add(vartotojas);
            _db.SaveChanges();

            var vartotojasId = vartotojas.IdVartotojas;

            duomenys.FkVartotojasId = vartotojasId;
            _db.PrisijungimoDuomenys.Add(duomenys);
            _db.SaveChanges();

            return duomenys;
        }

        public PrisijungimoDuomenys CreateCompany(RegisterCompanyModel company, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (_db.PrisijungimoDuomenys.Any(x => x.Epastas == company.Epastas))
                throw new AppException("Email \"" + company.Epastas + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var duomenys = new PrisijungimoDuomenys();
            duomenys.Epastas = company.Epastas;
            duomenys.FkTipas = 3;
            duomenys.Slaptazodis = passwordHash;
            duomenys.SlaptazodisSalt = passwordSalt;

            var imone = new Imone();
            MapImone(imone, company);

            _db.Imone.Add(imone);
            _db.SaveChanges();

            var imonesId = imone.IdImone;

            duomenys.FkImoneId = imonesId;
            _db.PrisijungimoDuomenys.Add(duomenys);
            _db.SaveChanges();

            return duomenys;
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using(var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i=0; i<computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }

        private void MapVartotojas(Vartotojas vartotojas, RegisterModel register)
        {
            vartotojas.Aprasymas = register.Aprasymas;
            vartotojas.ArUzsaldytas = false;
            vartotojas.AsmensKodas = register.AsmensKodas;
            vartotojas.GimimoMetai = register.GimimoMetai;
            vartotojas.Lytis = register.Lytis;
            vartotojas.Pavarde = register.Pavarde;
            vartotojas.SasNr = register.SasNr;
            vartotojas.Vardas = register.Vardas;
        }

        private void MapImone(Imone imone, RegisterCompanyModel register)
        {
            imone.Adresas = register.Adresas;
            imone.Aprasymas = register.Aprasymas;
            imone.ArUzsaldytas = false;
            imone.ElPastas = register.ImonesPastas;
            imone.ImonesKodas = register.ImonesKodas;
            imone.Miestas = register.Miestas;
            imone.Nuotrauka = register.Nuotrauka;
            imone.Pavadinimas = register.Pavadinimas;
            imone.TelNr = register.TelNr;
            imone.Tinklalapis = register.Tinklapis;
            imone.Vadovas = register.Vadovas;
        }
    }
}
