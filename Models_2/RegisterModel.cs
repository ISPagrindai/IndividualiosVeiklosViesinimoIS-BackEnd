using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace is_backend.Models_2
{
    public class RegisterModel
    {
        [Required]
        public string Epastas { get; set; }
        [Required]
        public string Slaptazodis { get; set; }
        [Required]
        public int Tipas { get; set; }
        [Required]
        public string Vardas { get; set; }
        [Required]
        public string Pavarde { get; set; }
        [Required]
        public DateTime GimimoMetai { get; set; }
        [Required]
        public string Lytis { get; set; }
        [Required]
        public string Aprasymas { get; set; }
        [Required]
        public string AsmensKodas { get; set; }
        [Required]
        public string SasNr { get; set; }

    }
}
