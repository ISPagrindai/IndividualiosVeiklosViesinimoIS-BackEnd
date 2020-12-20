using System;
using System.Collections.Generic;

namespace is_backend.Models
{
    public partial class VartotojoTipas
    {
        public VartotojoTipas()
        {
            PrisijungimoDuomenys = new HashSet<PrisijungimoDuomenys>();
        }

        public string Pavadinimas { get; set; }
        public int IdVartotojoTipas { get; set; }

        public virtual ICollection<PrisijungimoDuomenys> PrisijungimoDuomenys { get; set; }
    }
}
