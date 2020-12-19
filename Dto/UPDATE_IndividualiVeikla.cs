using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace is_backend.Dto
{
    public class UPDATE_IndividualiVeikla
    {
        [Required]
        public int IndividualiosVeiklosId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        [MinLength(5)]
        public string Pavadinimas { get; set; }
        [Required]
        [MinLength(5)]
        public string Aprasymas { get; set; }
        [Required]
        public decimal Kaina { get; set; }
        [Required]
        [MinLength(5)]
        public string Grafikas { get; set; }
        [Required]
        [MinLength(5)]
        public string Miestas { get; set; }
        [Required]
        public int VeiklosTipas { get; set; }
    }
}
