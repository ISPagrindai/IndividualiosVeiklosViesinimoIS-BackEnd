using is_backend.Dto;
using is_backend.IV_Models;
using is_backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace is_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IndividualiVeiklaController : Controller
    {
        private readonly individuali_veiklaContext _db;

        public IndividualiVeiklaController(individuali_veiklaContext context)
        {
            _db = context;
        }

        [HttpPost]
        [Authorize(Roles = Role.VartotojasIrAdmin)]
        public async Task<IActionResult> Post(POST_IndividualiVeikla post)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                var veikla = new IndividualiVeikla()
                {
                    Pavadinimas = post.Pavadinimas,
                    Aprasymas = post.Aprasymas,
                    Kaina = post.Kaina,
                    Grafikas = post.Grafikas,
                    ArUzsaldytas = false,
                    Vip = 0,
                    Miestas = post.Miestas,
                    FkVeiklosTipasidVeiklosTipas = post.VeiklosTipas,
                    FkVartotojasidVartotojas = int.Parse(User.Identity.Name)
            };
                await _db.IndividualiVeikla.AddAsync(veikla);
                await _db.SaveChangesAsync();
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /*[HttpPost]
        [Authorize(Roles = Role.Vartotojas)]
        public async Task<IActionResult> Post(POST_TrumpalaikioDarboPretendavimas job)
        {
            var vartotojoId = int.Parse(User.Identity.Name);
            if (job.TrumpalaikoDarboId < 1)
                return BadRequest();
            await _db.VartotojoKandidatavimas.AddAsync(new VartotojoKandidatavimas() { FkVartotojasidVartotojas = vartotojoId, FkTrumpalaikisDarbasidTrumpalaikisDarbas = job.TrumpalaikoDarboId });
            await _db.SaveChangesAsync();
            return Ok();
        }*/

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IndividualiVeikla>>> Get()
        {
            return Ok(await _db.IndividualiVeikla.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var veikla = await _db.IndividualiVeikla.FirstOrDefaultAsync(v => v.IdIndividualiVeikla == id);
            if (veikla == null)
                return NotFound();
            return Ok(veikla);
        }

        [Authorize(Roles = Role.VartotojasIrAdmin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var vartotojoId = int.Parse(User.Identity.Name);

            var veikla = _db.IndividualiVeikla.FirstOrDefault(v => v.IdIndividualiVeikla == id);
            if (veikla == null)
                return NotFound();

            if (User.IsInRole(Role.Vartotojas) && veikla.FkVartotojasidVartotojas != vartotojoId)
                return Forbid();

            _db.IndividualiVeikla.Remove(veikla);
            await _db.SaveChangesAsync();
            return Ok(veikla);
        }

        [HttpPut]
        [Authorize(Roles = Role.VartotojasIrAdmin)]
        public async Task<IActionResult> Update(UPDATE_IndividualiVeikla post)
        {
            if (ModelState.IsValid)
                return BadRequest();

            var vartotojoId = int.Parse(User.Identity.Name);

            var veikla = await _db.IndividualiVeikla.FirstOrDefaultAsync(v => v.IdIndividualiVeikla == post.IndividualiosVeiklosId);
            if (veikla == null)
                return NotFound();

            if (User.IsInRole(Role.Vartotojas) && veikla.FkVartotojasidVartotojas == vartotojoId)
                return Forbid();

            UpdateFields(veikla, post);
            await _db.SaveChangesAsync();
            return Ok();
        }

        private void UpdateFields(IndividualiVeikla oldData, UPDATE_IndividualiVeikla newData)
        {
            oldData.Pavadinimas = newData.Pavadinimas;
            oldData.Aprasymas = newData.Aprasymas;
            oldData.Kaina = newData.Kaina;
            oldData.Grafikas = newData.Grafikas;
            oldData.Miestas = newData.Miestas;
            oldData.FkVeiklosTipasidVeiklosTipas = newData.VeiklosTipas;
        }
    }
}
