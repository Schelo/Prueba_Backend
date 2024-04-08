using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Prueba_Backend.Modelo;

using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

using System.Text;

namespace Prueba_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionController : ControllerBase
    {
        private readonly string secretKey;

        public AutenticacionController(IConfiguration config) {
            secretKey = config.GetSection("settings").GetSection("secretkey").ToString();
        }
        [HttpPost]
        [Route("Validar")]

        public IActionResult Validar([FromBody] Usuario request) {

            if (request.correo == "m@mail.com" && request.clave == "123asd")
            {

                var keyBytes = Encoding.ASCII.GetBytes(secretKey);
                var claims = new ClaimsIdentity();

                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, request.correo));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature),
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenConfigo = tokenHandler.CreateToken(tokenDescriptor);

                string tokencreado = tokenHandler.WriteToken(tokenConfigo);

                return StatusCode(StatusCodes.Status200OK, new { token = tokencreado });

            }
            else {
                return StatusCode(StatusCodes.Status401Unauthorized, new { token = "" });
            }
        }
    }
}
