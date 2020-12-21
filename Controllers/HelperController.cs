using is_backend.Dto;
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
    public class HelperController : ControllerBase
    {
        private readonly individuali_veiklaContext _db;

        public HelperController(individuali_veiklaContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<GET_VeiklosTipas> getJobTypes()
        {
            var temp = _db.VeiklosTipas.Select(a =>  mapToGet(a)).ToHashSet();
            return temp;
        }

        private static GET_VeiklosTipas mapToGet(VeiklosTipas a)
        {
            return new GET_VeiklosTipas() { Id = a.IdVeiklosTipas, Pavadinimas = a.Pavadinimas };
        }
    }
}
