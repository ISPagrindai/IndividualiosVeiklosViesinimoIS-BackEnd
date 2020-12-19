using is_backend.IV_Models;
using is_backend.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace is_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors]
    public class IndividualiVeiklaController : Controller
    {
        private readonly individuali_veiklaContext _db;

        public IndividualiVeiklaController(individuali_veiklaContext context)
        {
            _db = context;
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post(PostIW post)
        {
            try
            {
                var veikla = new IndividualiVeikla()
                {
                    IdIndividualiVeikla = 1,
                    Pavadinimas = post.Pavadinimas,
                    Aprasymas = post.Aprasymas,
                    Kaina = post.Kaina,
                    Grafikas = post.Grafikas,
                    ArUzsaldytas = false,
                    Vip = 0,
                    Miestas = post.Miestas,
                    FkVeiklosTipasidVeiklosTipas = post.VeiklosTipas,
                    FkVartotojasidVartotojas = post.UserId
                };
                await _db.IndividualiVeikla.AddAsync(veikla);
                await _db.SaveChangesAsync();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent("Individual Event Post failed.", System.Text.Encoding.UTF8, "text/plain"),
                };
            }
        }

        [HttpGet]
        public IEnumerable<IndividualiVeikla> Get()
        {
            return _db.IndividualiVeikla.ToList();
        }
    }
}
