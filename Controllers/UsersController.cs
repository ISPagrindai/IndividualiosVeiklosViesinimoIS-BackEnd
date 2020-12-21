using is_backend.Entities;
using is_backend.Helpers;
using is_backend.Models;
using is_backend.Models_2;
using is_backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace is_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private readonly AppSettings _appSettings;
        private readonly individuali_veiklaContext _db;

        public UsersController(IUserService userService, IOptions<AppSettings> appSettings, individuali_veiklaContext db)
        {
            _userService = userService;
            _appSettings = appSettings.Value;
            _db = db;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateModel model)
        {
            var user = _userService.Authenticate(model.Email, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var role = _db.VartotojoTipas.FirstOrDefault(x => x.IdVartotojoTipas == user.FkTipas).Pavadinimas;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            string name = null;
            if (user.FkVartotojasId == null && user.FkImoneId == null)
                return StatusCode(StatusCodes.Status500InternalServerError);

            if (user.FkVartotojasId != null)
                name = user.FkVartotojasId.ToString();
            else
                name = user.FkImoneId.ToString();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, name),
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new
            {
                Epastas = user.Epastas,
                Role = role,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]RegisterModel model)
        {
            try
            {
                _userService.Create(model, model.Slaptazodis);
                return Ok();
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost("registerCompany")]
        public IActionResult Register([FromBody]RegisterCompanyModel model)
        {
            try
            {
                _userService.CreateCompany(model, model.Slaptazodis);
                return Ok();
            }
            catch(AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost("registerAdmin")]
        public IActionResult RegisterAdmin([FromBody]RegisterModel model)
        {
            try
            {
                _userService.CreateAdmin(model, model.Slaptazodis);
                return Ok();
            }
            catch(AppException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
