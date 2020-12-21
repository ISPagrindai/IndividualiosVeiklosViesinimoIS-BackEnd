using is_backend.Dto;
using is_backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace is_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImonesController : ControllerBase
    {
        private readonly individuali_veiklaContext _db;

        public ImonesController(individuali_veiklaContext context)
        {
            _db = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TrumpalaikisDarbas>> GetAllWorkOffers()
        {
            return Ok(_db.TrumpalaikisDarbas);
        }
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<TrumpalaikisDarbas>> GetAllWorkOffersByCompanyId(int id)
        {
            if (_db.Imone.Find(id) == null)
                return NotFound();

            return Ok(_db.TrumpalaikisDarbas.Where(offer => offer.FkImoneidImone == id).ToList());
        }
        [Authorize(Roles = Role.ImoneIrAdmin)]
        [HttpGet("current")]
        public ActionResult<IEnumerable<TrumpalaikisDarbas>> GetAllWorkOffersByCurrentCompany()
        {
            var id = int.Parse(User.Identity.Name);

            if (_db.Imone.Find(id) == null)
                return NotFound();
            var result = _db.TrumpalaikisDarbas.Where(offer => offer.FkImoneidImone == id).ToList();

            return Ok(result);
        }

        [HttpGet("darbas/{id?}")]
        public ActionResult<TrumpalaikisDarbas> GetWorkOfferById(int id)
        {
            var result = _db.TrumpalaikisDarbas.Find(id);
            if(result == null)
            {
                return NotFound();
            }

            return _db.TrumpalaikisDarbas.Find(id);
        }
        [Authorize(Roles = Role.ImoneIrAdmin)]
        [HttpGet("current/info")]
        public ActionResult<GET_CompanyInfo> getCurrentCompanyInfo()
        {
            var id = int.Parse(User.Identity.Name);
            var info = new GET_CompanyInfo();
            var imone = _db.Imone.Find(id);
            if (imone == null)
                return NotFound();


            info.Pavadinimas = imone.Pavadinimas;
            info.SkelbimuSk = _db.TrumpalaikisDarbas.Count(j => j.FkImoneidImone == id);
            info.AtsiliepimuSk = _db.Atsiliepimas.Count(a => a.FkImoneidImone == id);
            info.Ivertis = Math.Round(info.AtsiliepimuSk == 0 ? 0 : _db.Atsiliepimas.Where(i => i.FkImoneidImone == id).Select(i => i.Ivertinimas).Sum() / (double)info.AtsiliepimuSk, 1);
            info.KandidatuSk = _db.VartotojoKandidatavimas.Count(i => _db.TrumpalaikisDarbas.Where(i => i.FkImoneidImone == id).Select(i => i.IdTrumpalaikisDarbas).Contains(i.FkTrumpalaikisDarbasidTrumpalaikisDarbas));
            return info;
        }
        [HttpGet("candidates/{id}")]
        public ActionResult<IEnumerable<GET_Kandidatas>> getJobCandidates(int id)
        {
            var job = _db.TrumpalaikisDarbas.Find(id);

            if (job == null)
                return NotFound();

            var userIds = _db.VartotojoKandidatavimas.Where(i => i.FkTrumpalaikisDarbasidTrumpalaikisDarbas == id).Select(i => i.FkVartotojasidVartotojas);

            var result = _db.Vartotojas.Where(i => userIds.Contains(i.IdVartotojas)).Select(i => new GET_Kandidatas {Id = i.IdVartotojas,Vardas = i.Vardas, Pavarde = i.Pavarde, Lytis = i.Lytis, Epastas = _db.PrisijungimoDuomenys.FirstOrDefault(u => u.FkVartotojasId == i.IdVartotojas).Epastas, GimimoData = i.GimimoMetai}).ToList();

            return result;
        }
        [HttpPost("candidates/remove")]
        public ActionResult removeCandidateFromJob(POST_DeleteCandidate post)
        {
            if (_db.Vartotojas.Find(post.CandidateId) == null)
                return NotFound("Kandidatas nerastas");
            if (_db.TrumpalaikisDarbas.Find(post.JobId) == null)
                return NotFound("Trumpalaikis darbas nerastas");

            var result = _db.VartotojoKandidatavimas.FirstOrDefault(i => i.FkTrumpalaikisDarbasidTrumpalaikisDarbas == post.JobId && i.FkVartotojasidVartotojas == post.CandidateId);

            if (result == null)
                return NotFound("Toks įrašas neegzistuoja");

            _db.VartotojoKandidatavimas.Remove(result);
            _db.SaveChanges();
            return Ok("Kandidatas pašalintas");
        }

        [Authorize(Roles = Role.ImoneIrAdmin)]
        [HttpPost]
        public ActionResult NewWorkOffer(POST_TrumpalaikisDarbas post)
        {
            if (_db.VeiklosTipas.Find(post.Tipas) == null)
                return BadRequest("Netinkamas veiklos tipas");

            var result = postMapper(post);
            _db.TrumpalaikisDarbas.Add(result);
            _db.SaveChanges();
            return Ok();
        }
        [Authorize(Roles = Role.ImoneIrAdmin)]
        [HttpPut]
        public ActionResult UpdateWorkOffer(PUT_TrumpalaikisDarbas post)
        {
            var companyId = int.Parse(User.Identity.Name);

            var result = _db.TrumpalaikisDarbas.Find(post.Id);
            if (result == null)
                return NotFound();

            if (User.IsInRole(Role.Imone) && result.FkImoneidImone != companyId)
                return Forbid();

            result = putMapper(result, post);
            _db.SaveChanges();
            return Ok();
        }
        [Authorize(Roles = Role.ImoneIrAdmin)]
        [HttpDelete("{id}")]
        public ActionResult DeleteWorkOffer(int id)
        {
            var companyId = int.Parse(User.Identity.Name);

            var result = _db.TrumpalaikisDarbas.FirstOrDefault(t => t.IdTrumpalaikisDarbas == id);
            if (result == null)
                return NotFound();

            if (User.IsInRole(Role.Imone) && result.FkImoneidImone != companyId)
                return Forbid();       

            _db.TrumpalaikisDarbas.Remove(result);
            _db.SaveChanges();
            return Ok();
        }

        private TrumpalaikisDarbas postMapper(POST_TrumpalaikisDarbas post)
        {
            var result = new TrumpalaikisDarbas();
            result.Pavadinimas = post.Pavadinimas;
            result.Aprasymas = post.Aprasymas;
            result.Adresas = post.Adresas;
            result.Uzmokestis = post.Uzmokestis;
            result.Miestas = post.Miestas;
            result.FkVeiklosTipasidVeiklosTipasNavigation = _db.VeiklosTipas.Find(post.Tipas);
            result.FkImoneidImoneNavigation = _db.Imone.Find(int.Parse(User.Identity.Name));
            return result;
        }
        private TrumpalaikisDarbas putMapper(TrumpalaikisDarbas result, PUT_TrumpalaikisDarbas post)
        {

            result.Pavadinimas = post.Pavadinimas;
            result.Aprasymas = post.Aprasymas;
            result.Adresas = post.Adresas;
            result.Uzmokestis = post.Uzmokestis;
            result.Miestas = post.Miestas;
            result.FkVeiklosTipasidVeiklosTipasNavigation = _db.VeiklosTipas.Find(post.Tipas);
            result.FkImoneidImoneNavigation = _db.Imone.Find(int.Parse(User.Identity.Name)); 
            return result;
        }
    }
}
