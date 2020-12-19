using System;
using System.Collections.Generic;

namespace is_backend.Models
{
    public partial class Nuotrauka
    {
        public string Path { get; set; }
        public int IdNuotrauka { get; set; }
        public int FkIndividualiVeiklaidIndividualiVeikla { get; set; }
        public int FkVartotojasidVartotojas { get; set; }
        public int FkImoneidImone { get; set; }

        public virtual Imone FkImoneidImoneNavigation { get; set; }
        public virtual IndividualiVeikla FkIndividualiVeiklaidIndividualiVeiklaNavigation { get; set; }
        public virtual Vartotojas FkVartotojasidVartotojasNavigation { get; set; }
    }
}
