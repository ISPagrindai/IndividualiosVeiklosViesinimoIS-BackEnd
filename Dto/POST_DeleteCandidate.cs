using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace is_backend.Dto
{
    public class POST_DeleteCandidate
    {
        public int JobId { get; set; }
        public int CandidateId { get; set; }
    }
}
