using System;
using System.Collections.Generic;

namespace is_backend.Models
{
    public partial class Vieta
    {
        public string Miestas { get; set; }
        public string Adresas { get; set; }
        public int IdVieta { get; set; }

        public virtual Imone Imone { get; set; }
        public virtual IndividualiVeikla IndividualiVeikla { get; set; }
        public virtual Vartotojas Vartotojas { get; set; }
    }
}
