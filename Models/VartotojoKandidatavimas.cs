using System;
using System.Collections.Generic;

namespace is_backend.Models
{
    public partial class VartotojoKandidatavimas
    {
        public int FkTrumpalaikisDarbasidTrumpalaikisDarbas { get; set; }
        public int FkVartotojasidVartotojas { get; set; }

        public virtual TrumpalaikisDarbas FkTrumpalaikisDarbasidTrumpalaikisDarbasNavigation { get; set; }
    }
}
