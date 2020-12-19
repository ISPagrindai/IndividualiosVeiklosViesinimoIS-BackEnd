using System;
using System.Collections.Generic;

namespace is_backend.Models
{
    public partial class PrisijungimoDuomenys
    {
        public string Epastas { get; set; }
        public string Slaptazodis { get; set; }
        public int FkTipas { get; set; }
        public int? FkVartotojasId { get; set; }
        public int? FkImoneId { get; set; }

        public virtual Imone FkImone { get; set; }
        public virtual VartotojoTipas FkTipasNavigation { get; set; }
        public virtual Vartotojas FkVartotojas { get; set; }
    }
}
