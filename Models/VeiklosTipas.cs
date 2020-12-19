using System;
using System.Collections.Generic;

namespace is_backend.Models
{
    public partial class VeiklosTipas
    {
        public VeiklosTipas()
        {
            IndividualiVeikla = new HashSet<IndividualiVeikla>();
            TrumpalaikisDarbas = new HashSet<TrumpalaikisDarbas>();
        }

        public string Pavadinimas { get; set; }
        public int IdVeiklosTipas { get; set; }

        public virtual ICollection<IndividualiVeikla> IndividualiVeikla { get; set; }
        public virtual ICollection<TrumpalaikisDarbas> TrumpalaikisDarbas { get; set; }
    }
}
