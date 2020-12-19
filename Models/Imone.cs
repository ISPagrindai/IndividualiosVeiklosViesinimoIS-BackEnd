using System;
using System.Collections.Generic;

namespace is_backend.Models
{
    public partial class Imone
    {
        public Imone()
        {
            Atsiliepimas = new HashSet<Atsiliepimas>();
            TrumpalaikisDarbas = new HashSet<TrumpalaikisDarbas>();
        }

        public string Pavadinimas { get; set; }
        public string Aprasymas { get; set; }
        public string ImonesKodas { get; set; }
        public string Vadovas { get; set; }
        public string Tinklalapis { get; set; }
        public bool ArUzsaldytas { get; set; }
        public string TelNr { get; set; }
        public string ElPastas { get; set; }
        public string Miestas { get; set; }
        public string Adresas { get; set; }
        public byte[] Nuotrauka { get; set; }
        public int IdImone { get; set; }

        public virtual ICollection<Atsiliepimas> Atsiliepimas { get; set; }
        public virtual ICollection<TrumpalaikisDarbas> TrumpalaikisDarbas { get; set; }
    }
}
