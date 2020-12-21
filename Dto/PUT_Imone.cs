using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace is_backend.Dto
{
    public class PUT_Imone
    {
        [Required]
        public bool ArUzsaldytas { get; set; }
        [Required]
        public int IdImone { get; set; }

    }
}
