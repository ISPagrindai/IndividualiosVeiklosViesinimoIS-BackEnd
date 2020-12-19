using is_backend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace is_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController
    {
        private readonly individuali_veiklaContext _context;

        public TestController(individuali_veiklaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Vieta> Get()
        {
            return _context.Vieta.ToList();
        }
    }
}
