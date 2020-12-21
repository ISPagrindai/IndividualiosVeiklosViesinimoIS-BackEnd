using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace is_backend.Dto
{
    public class GET_Kandidatas
    {
        public int Id { get; set; }
        public string Vardas {get; set;}

        public string Pavarde { get; set; }

        public string Lytis { get; set; }

        public string Epastas { get; set; }

        public DateTime? GimimoData { get; set; }
    }
}
