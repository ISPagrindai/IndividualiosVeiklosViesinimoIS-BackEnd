using System;
using System.Collections.Generic;

namespace is_backend.Models
{
    public partial class VipUzsakymas
    {
        public DateTime PrData { get; set; }
        public DateTime PbData { get; set; }
        public int IdVipUzsakymas { get; set; }
        public int FkIndividualiVeiklaidIndividualiVeikla { get; set; }

        public virtual IndividualiVeikla FkIndividualiVeiklaidIndividualiVeiklaNavigation { get; set; }
    }
}
