using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace is_backend.Dto
{
    public class POST_TrumpalaikisDarbas
    {
        [Required]
        [MinLength(5)]
        public string Pavadinimas { get; set; }
        [Required]
        public string Aprasymas { get; set; }
        [Required]
        public decimal Uzmokestis { get; set; }
        [Required]
        public string Miestas { get; set; }
        [Required]
        [MinLength(5)]
        public string Adresas { get; set; }
        [Required]
        public int Tipas { get; set; }
    }
}
