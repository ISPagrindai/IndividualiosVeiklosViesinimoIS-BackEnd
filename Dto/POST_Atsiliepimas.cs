using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace is_backend.Dto
{
    public class POST_Atsiliepimas
    {
        [Required]
        public string Komentaras { get; set; }
        [Required]
        public int Ivertinimas { get; set; }
        public int VartotojasId { get; set; }
        public int ImoneId { get; set; }
        public int IndividualiVeiklaId { get; set; }

    }
}
