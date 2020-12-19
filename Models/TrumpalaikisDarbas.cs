using System;
using System.Collections.Generic;

namespace is_backend.Models
{
    public partial class TrumpalaikisDarbas
    {
        public TrumpalaikisDarbas()
        {
            VartotojoKandidatavimas = new HashSet<VartotojoKandidatavimas>();
        }

        public string Pavadinimas { get; set; }
        public string Aprasymas { get; set; }
        public decimal Uzmokestis { get; set; }
        public string Miestas { get; set; }
        public string Adresas { get; set; }
        public int IdTrumpalaikisDarbas { get; set; }
        public int FkVeiklosTipasidVeiklosTipas { get; set; }
        public int FkImoneidImone { get; set; }

        public virtual Imone FkImoneidImoneNavigation { get; set; }
        public virtual VeiklosTipas FkVeiklosTipasidVeiklosTipasNavigation { get; set; }
        public virtual ICollection<VartotojoKandidatavimas> VartotojoKandidatavimas { get; set; }
    }
}
