using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace is_backend.Dto
{
    public class POST_TrumpalaikioDarboPretendavimas
    {
        [Required]
        public int TrumpalaikoDarboId { get; set; }
    }
}
