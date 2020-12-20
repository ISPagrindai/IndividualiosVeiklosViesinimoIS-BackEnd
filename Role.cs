using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace is_backend
{
    public static class Role
    {
        public const string Admin = "Admin";
        public const string Vartotojas = "Vartotojas";
        public const string Imone = "Įmonė";

        public const string VartotojasIrAdmin = Admin + "," + Vartotojas;
        public const string ImoneIrAdmin = Admin + "," + Imone;
    }
}
