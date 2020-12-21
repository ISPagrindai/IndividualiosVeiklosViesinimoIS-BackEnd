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
    public class AdminController : ControllerBase
    {
        public readonly individuali_veiklaContext _db;
        public AdminController(individuali_veiklaContext db)
        {
            _db = db;
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vartotojas>>> GetAllUsers()
        {
            return Ok(await _db.Vartotojas.ToListAsync());
        }
        [Authorize(Roles = Role.Admin)]
        [HttpGet("imones")]
        public async Task<ActionResult<IEnumerable<Vartotojas>>> GetAllEmployers()
        {
            return Ok(await _db.Imone.ToListAsync());
        }

        [Authorize(Roles = Role.Admin)]
        [HttpDelete("imones/{id}")]
        public ActionResult DeleteEmployer(int id)
        {
            var result = _db.Imone.FirstOrDefault(t => t.IdImone == id);
            if (result == null)
                return NotFound();

            _db.Imone.Remove(result);
            _db.SaveChanges();
            return Ok();
        }

        [Authorize(Roles = Role.Admin)]
        [HttpDelete("individualiVeikla/{id}")]
        public ActionResult DeleteIndividualWork(int id)
        {
            var result = _db.IndividualiVeikla.FirstOrDefault(t => t.IdIndividualiVeikla == id);
            if (result == null)
                return NotFound();

            _db.IndividualiVeikla.Remove(result);
            _db.SaveChanges();
            return Ok();
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet("naujosImones")]
        public ActionResult<IEnumerable<Imone>> GetNewEmpolyers()
        {
            var result = _db.Imone.Where(i => i.ArUzsaldytas == true);
            return Ok(result);
        }

        [HttpPut]
        public ActionResult ConfirmEmployer(PUT_Imone post)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _db.Imone.Find(post.IdImone);
            if (result == null)
                return NotFound();

            result = putMapper(result, post);
            _db.SaveChanges();
            return Ok();
        }
        private Imone putMapper(Imone result, PUT_Imone post)
        {

            result.ArUzsaldytas = post.ArUzsaldytas;

            return result;
        }
    }
}
