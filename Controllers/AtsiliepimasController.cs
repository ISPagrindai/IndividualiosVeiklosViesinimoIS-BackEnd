using is_backend.Dto;
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
    public class AtsiliepimasController : ControllerBase
    {
        private readonly individuali_veiklaContext _db;

        public AtsiliepimasController(individuali_veiklaContext context)
        {
            _db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Atsiliepimas>>> Get()
        {
            return Ok(await _db.Atsiliepimas.ToListAsync());
        }

        [HttpPost]
        [Authorize(Roles = Role.VartotojasIrImone)]
        public async Task<IActionResult> Post(POST_Atsiliepimas atsiliepimas)
        {
            if (atsiliepimas.VartotojasId == 0 && atsiliepimas.IndividualiVeiklaId == 0 && atsiliepimas.ImoneId == 0)
                return BadRequest("Reciever not selected");

            var vartotojoId = int.Parse(User.Identity.Name);
            
            var atsil = new Atsiliepimas();
            MapAtsiliepimas(atsil, atsiliepimas);

            atsil.SiuntejoId = vartotojoId;
            if (User.IsInRole(Role.Vartotojas))
                atsil.SiuntejoTipas = Role.Vartotojas;
            else
                atsil.SiuntejoTipas = Role.Imone;

            if(atsiliepimas.VartotojasId != 0)
            {
                atsil.FkVartotojasidVartotojas = atsiliepimas.VartotojasId;
                await _db.Atsiliepimas.AddAsync(atsil);
            }
            else if(atsiliepimas.ImoneId != 0)
            {
                atsil.FkImoneidImone = atsiliepimas.ImoneId;
                await _db.Atsiliepimas.AddAsync(atsil);
            }
            else
            {
                atsil.FkIndividualiVeiklaidIndividualiVeikla = atsiliepimas.IndividualiVeiklaId;
                await _db.Atsiliepimas.AddAsync(atsil);
            }
            await _db.SaveChangesAsync();

            return Ok();
        }

        private void MapAtsiliepimas(Atsiliepimas atsiliepimas, POST_Atsiliepimas postAtsiliepimas)
        {
            atsiliepimas.Ivertinimas = postAtsiliepimas.Ivertinimas;
            atsiliepimas.Komentaras = postAtsiliepimas.Komentaras;  
        }
    }
}
