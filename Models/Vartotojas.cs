﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace is_backend.Models
{
    public partial class Vartotojas
    {
        public Vartotojas()
        {
            Atsiliepimas = new HashSet<Atsiliepimas>();
            IndividualiVeikla = new HashSet<IndividualiVeikla>();
            PrisijungimoDuomenys = new HashSet<PrisijungimoDuomenys>();
        }

        public string Vardas { get; set; }
        public string Pavarde { get; set; }
        public DateTime? GimimoMetai { get; set; }
        public string Lytis { get; set; }
        public string Aprasymas { get; set; }
        public string AsmensKodas { get; set; }
        public string SasNr { get; set; }
        public bool ArUzsaldytas { get; set; }
        public int IdVartotojas { get; set; }

        [JsonIgnore]
        public virtual ICollection<Atsiliepimas> Atsiliepimas { get; set; }
        [JsonIgnore]
        public virtual ICollection<IndividualiVeikla> IndividualiVeikla { get; set; }
        [JsonIgnore]
        public virtual ICollection<PrisijungimoDuomenys> PrisijungimoDuomenys { get; set; }
        
    }
}
