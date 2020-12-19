using System;
using System.Collections.Generic;

namespace is_backend.Models
{
    public partial class Atsiliepimas
    {
        public string Komentaras { get; set; }
        public int Ivertinimas { get; set; }
        public string SiuntejoTipas { get; set; }
        public int SiuntejoId { get; set; }
        public int IdAtsiliepimas { get; set; }
        public int? FkVartotojasidVartotojas { get; set; }
        public int? FkImoneidImone { get; set; }
        public int? FkIndividualiVeiklaidIndividualiVeikla { get; set; }

        public virtual Imone FkImoneidImoneNavigation { get; set; }
        public virtual IndividualiVeikla FkIndividualiVeiklaidIndividualiVeiklaNavigation { get; set; }
        public virtual Vartotojas FkVartotojasidVartotojasNavigation { get; set; }
    }
}
