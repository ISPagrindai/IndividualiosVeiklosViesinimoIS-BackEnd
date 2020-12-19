using System;
using System.Collections.Generic;

namespace is_backend.Models
{
    public partial class VartotojoTipas
    {
        public VartotojoTipas()
        {
            Vartotojas = new HashSet<Vartotojas>();
        }

        public string Pavadinimas { get; set; }
        public int IdVartotojoTipas { get; set; }

        public virtual ICollection<Vartotojas> Vartotojas { get; set; }
    }
}
