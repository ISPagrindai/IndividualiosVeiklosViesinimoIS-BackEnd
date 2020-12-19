using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace is_backend.Services
{
    public interface IAuthenticationService
    {
        public bool AuthenticateLogIn(string username, string password, ref string role);
    }
}
