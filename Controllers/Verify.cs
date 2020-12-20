using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace is_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Verify : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { Response =  User.Identity.IsAuthenticated });
        }
    }
}
