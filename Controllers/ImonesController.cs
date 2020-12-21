using is_backend.Dto;
using is_backend.Models;
using Microsoft.AspNetCore.Mvc;
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
            if (result == null)
            {
                return NotFound();
            }

            return _db.TrumpalaikisDarbas.Find(id);
        }
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
        [HttpPut]
        public ActionResult UpdateWorkOffer(PUT_TrumpalaikisDarbas post)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = _db.TrumpalaikisDarbas.Find(post.Id);
            if (result == null)
                return NotFound();

            result = putMapper(result, post);
            _db.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteWorkOffer(int id)
        {
            var result = _db.TrumpalaikisDarbas.Find(id);
            if (result == null)
                return NotFound();

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
            result.FkImoneidImoneNavigation = _db.Imone.First(); // TODO change
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
            result.FkImoneidImoneNavigation = _db.Imone.First(); // TODO change
            return result;
        }
    }
}
