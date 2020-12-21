using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace is_backend.Dto
{
    public class GET_CompanyInfo
    {
        //public byte[] Img { get; set; }

        public string Pavadinimas { get; set; }

        public int SkelbimuSk { get; set; }

        public int KandidatuSk { get; set; }

        public double Ivertis { get; set; }

        public int AtsiliepimuSk { get; set; }
    }
}
