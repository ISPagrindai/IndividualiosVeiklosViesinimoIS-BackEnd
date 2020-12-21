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
    public class ProfileController : ControllerBase
    {
        private readonly individuali_veiklaContext _db;

        public ProfileController(individuali_veiklaContext context)
        {
            _db = context;
        }

        [HttpGet("{id}")]
        //[Authorize(Roles = Role.VartotojasIrAdmin)]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _db.Vartotojas.FirstOrDefaultAsync(v => v.IdVartotojas == id);
            if (user == null) return BadRequest();

            var getUser = new GET_User();
            MapUser(getUser, user);

            getUser.Email = (await _db.PrisijungimoDuomenys.FirstOrDefaultAsync(v => v.FkVartotojasId == id))?.Epastas;

            return Ok(getUser);
        }

        private void MapUser(GET_User toUser, Vartotojas fromUser)
        {
            toUser.Aprasymas = fromUser.Aprasymas;
            toUser.ArUzsaldytas = fromUser.ArUzsaldytas;
            toUser.AsmensKodas = fromUser.AsmensKodas;
            toUser.GimimoMetai = fromUser.GimimoMetai;
            toUser.IdVartotojas = fromUser.IdVartotojas;
            toUser.Lytis = fromUser.Lytis;
            toUser.Pavarde = fromUser.Pavarde;
            toUser.SasNr = fromUser.SasNr;
            toUser.Vardas = fromUser.Vardas;
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (User.Identity.IsAuthenticated)
                return Ok(new { Response = int.Parse(User.Identity.Name) });
            else
                return Ok(new { Response = -1 });
        }
    }
}
