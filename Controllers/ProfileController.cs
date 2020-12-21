using is_backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace is_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly individuali_veiklaContext _db;

        public ProfileController(individuali_veiklaContext context)
        {
            _db = context;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = Role.VartotojasIrAdmin)]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _db.Vartotojas.FirstOrDefaultAsync(v => v.IdVartotojas == id);
            if (user == null) return BadRequest();

            return Ok(user);
        }

        [HttpGet]
        [Authorize(Roles = Role.Vartotojas)]
        public IActionResult Get()
        {
            if (User.Identity.IsAuthenticated)
                return Ok(new { Response = int.Parse(User.Identity.Name) });
            else
                return Ok(new { Response = -1 });
        }
    }
}
