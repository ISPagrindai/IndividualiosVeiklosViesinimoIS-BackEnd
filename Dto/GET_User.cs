using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace is_backend.Dto
{
    public class GET_User
    {
        public string Vardas { get; set; }
        public string Pavarde { get; set; }
        public DateTime? GimimoMetai { get; set; }
        public string Lytis { get; set; }
        public string Aprasymas { get; set; }
        public string AsmensKodas { get; set; }
        public string SasNr { get; set; }
        public bool ArUzsaldytas { get; set; }
        public int IdVartotojas { get; set; }
        public string Email { get; set; }
    }
}
