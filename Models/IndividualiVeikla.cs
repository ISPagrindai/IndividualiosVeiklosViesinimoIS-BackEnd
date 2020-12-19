using System;
using System.Collections.Generic;

namespace is_backend.Models
{
    public partial class IndividualiVeikla
    {
        public IndividualiVeikla()
        {
            Atsiliepimas = new HashSet<Atsiliepimas>();
            Nuotrauka = new HashSet<Nuotrauka>();
        }

        public string Pavadinimas { get; set; }
        public string Aprasymas { get; set; }
        public decimal Kaina { get; set; }
        public string Grafikas { get; set; }
        public int Vip { get; set; }
        public bool ArUzsaldytas { get; set; }
        public int IdIndividualiVeikla { get; set; }
        public int FkVietaidVieta { get; set; }
        public int FkKontaktaiidKontaktai { get; set; }
        public int FkVeiklosTipasidVeiklosTipas { get; set; }
        public int FkVartotojasidVartotojas { get; set; }

        public virtual Kontaktai FkKontaktaiidKontaktaiNavigation { get; set; }
        public virtual Vartotojas FkVartotojasidVartotojasNavigation { get; set; }
        public virtual VeiklosTipas FkVeiklosTipasidVeiklosTipasNavigation { get; set; }
        public virtual Vieta FkVietaidVietaNavigation { get; set; }
        public virtual VipUzsakymas VipUzsakymas { get; set; }
        public virtual ICollection<Atsiliepimas> Atsiliepimas { get; set; }
        public virtual ICollection<Nuotrauka> Nuotrauka { get; set; }
    }
}
