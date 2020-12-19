using System;
using System.Collections.Generic;

namespace is_backend.Models
{
    public partial class Kontaktai
    {
        public string TelNr { get; set; }
        public string ElPastas { get; set; }
        public int IdKontaktai { get; set; }
        public int FkVartotojasidVartotojas { get; set; }

        public virtual Vartotojas FkVartotojasidVartotojasNavigation { get; set; }
        public virtual Imone Imone { get; set; }
        public virtual IndividualiVeikla IndividualiVeikla { get; set; }
    }
}
