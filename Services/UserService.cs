using is_backend.Entities;
using is_backend.Helpers;
using is_backend.Models;
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
        User Authenticate(string username, string password);
    }

    public class UserService : IUserService
    {

        private readonly AppSettings _appSettings;
        private readonly individuali_veiklaContext _db;

        public UserService(IOptions<AppSettings> appSettings, individuali_veiklaContext db)
        {
            _appSettings = appSettings.Value;
            _db = db;
        }

        public User Authenticate(string username, string password)
        {
            var user = _db.PrisijungimoDuomenys.SingleOrDefault(x => x.Epastas == username && x.Slaptazodis == password);

            if (user == null) return null;

            var userReturn = new User()
            {
                Epastas = user.Epastas,
                Slaptazodis = user.Slaptazodis,
                Role = _db.VartotojoTipas.FirstOrDefault(x => x.IdVartotojoTipas == user.FkTipas).Pavadinimas
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.FkVartotojasId.ToString()),
                    new Claim(ClaimTypes.Role, userReturn.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            userReturn.Token = tokenHandler.WriteToken(token);

            return userReturn.WithoutPassword();
        }
    }
}
