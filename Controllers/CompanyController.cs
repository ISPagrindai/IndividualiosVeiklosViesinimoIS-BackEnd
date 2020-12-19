using is_backend.Models;
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
    public class CompanyController : ControllerBase
    {
        private readonly individuali_veiklaContext _db;

        public CompanyController(individuali_veiklaContext context)
        {
            _db = context;
        }

        public IEnumerable<TrumpalaikisDarbas> GetAllWorkOffers()
        {
            return _db.TrumpalaikisDarbas;
        }
        public IEnumerable<TrumpalaikisDarbas> GetAllWorkOffersByCompanyId(int id)
        {
            return _db.TrumpalaikisDarbas.Where(offer => offer.FkImoneidImone == id).ToList();
        }
        public TrumpalaikisDarbas GetWorkOfferById(int id)
        {
            return _db.TrumpalaikisDarbas.Find(id);
        }
    }
}
