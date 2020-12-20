using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace is_backend.Models_2
{
    public class RegisterCompanyModel
    {
        [Required]
        public string Epastas { get; set; }
        [Required]
        public string Slaptazodis { get; set; }
        [Required]
        public int Tipas { get; set; }
        [Required]
        public string Pavadinimas { get; set; }
        [Required]
        public string Aprasymas { get; set; }
        [Required]
        public string ImonesKodas { get; set; }
        [Required]
        public string Vadovas { get; set; }
        public string? Tinklapis { get; set; }
        public byte[]? Nuotrauka { get; set; }
        [Required]
        public string TelNr { get; set; }
        [Required]
        public string ImonesPastas { get; set; }
        [Required]
        public string Miestas { get; set; }
        [Required]
        public string Adresas { get; set; }
    }
}
