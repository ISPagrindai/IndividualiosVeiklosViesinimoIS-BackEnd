using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace is_backend.IV_Models
{
    public class PostIW
    {

        public int UserId { get; set; }

        public string Pavadinimas { get; set; }

        public string Aprasymas { get; set; }

        public decimal Kaina { get; set; }

        public string Grafikas { get; set; }

        public string Miestas { get; set; }

        public int VeiklosTipas { get; set; }
    }
}
