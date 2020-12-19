using System;
using System.Collections.Generic;

namespace is_backend.Models
{
    public partial class Imone
    {
        public Imone()
        {
            Atsiliepimas = new HashSet<Atsiliepimas>();
            Nuotrauka = new HashSet<Nuotrauka>();
            TrumpalaikisDarbas = new HashSet<TrumpalaikisDarbas>();
        }

        public string Pavadinimas { get; set; }
        public string Aprasymas { get; set; }
        public string ImonesKodas { get; set; }
        public string Vadovas { get; set; }
        public string Tinklalapis { get; set; }
        public bool ArUzsaldytas { get; set; }
        public int IdImone { get; set; }
        public int FkVietaidVieta { get; set; }
        public int FkKontaktaiidKontaktai { get; set; }
        public int FkAtsiliepimasidAtsiliepimas { get; set; }

        public virtual Atsiliepimas FkAtsiliepimasidAtsiliepimasNavigation { get; set; }
        public virtual Kontaktai FkKontaktaiidKontaktaiNavigation { get; set; }
        public virtual Vieta FkVietaidVietaNavigation { get; set; }
        public virtual ICollection<Atsiliepimas> Atsiliepimas { get; set; }
        public virtual ICollection<Nuotrauka> Nuotrauka { get; set; }
        public virtual ICollection<TrumpalaikisDarbas> TrumpalaikisDarbas { get; set; }
    }
}
