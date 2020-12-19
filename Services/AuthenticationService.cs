using is_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace is_backend.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly individuali_veiklaContext db;

        public AuthenticationService(individuali_veiklaContext db)
        {
            this.db = db;
        }
        public bool AuthenticateLogIn(string username, string password, ref string role)
        {
            var roleId = db.PrisijungimoDuomenys.FirstOrDefault(v => v.Epastas == username && v.Slaptazodis == password)?.FkTipas;
            if (roleId != null) { role = db.VartotojoTipas.FirstOrDefault(t => t.IdVartotojoTipas == roleId).Pavadinimas; return true; }

            return false;
        }
    }
}
