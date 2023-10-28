using Microsoft.AspNetCore.Mvc;
using SistemaGestionBusiness;
using SistemaGestionEntities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace SistemaGestionWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly string secretKey = "SistemaGestionWebAPISistemaGestionWebAPISistemaGestionWebAPISistemaGestionWebAPI";
        private readonly double tokenExpirationMinutes = 60;

        // POST: api/Session/Login
        [HttpPost("Login", Name = "Login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            Usuario authenticatedUser = AuthenticateUser(loginRequest);

            if (authenticatedUser == null)
            {
                return Unauthorized();
            }

            // Genera un token JWT
            string jwtToken = GenerateJwtToken(authenticatedUser);

            return Ok(new { Token = jwtToken });
        }

        // Método para autenticar al usuario
        private Usuario AuthenticateUser(LoginRequest loginRequest)
        {
            Usuario user = UsuarioBusiness.ObtenerUsuarioPorNombreUsuario(loginRequest.NombreUsuario);

            //salt estatica para encriptar contraseña
            byte[] salt = Encoding.ASCII.GetBytes("SistemaGestion");

            //encriptar contraseña
            string hashedPassword = UsuarioBusiness.HashedPassword(loginRequest.Contraseña, salt);

            if (user != null && user.Contraseña == hashedPassword)
            {
                return user;
            }
            return null;
        }

        // Metodo para generar un token JWT
        private string GenerateJwtToken(Usuario user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.NombreUsuario)
                }),
                Expires = DateTime.UtcNow.AddMinutes(tokenExpirationMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        // POST: api/Session/Register
        [HttpPost("Register", Name = "Register")]
        public IActionResult Register([FromBody] Usuario registerRequest)
        {
            Usuario newUser = new Usuario
            {
                Nombre = registerRequest.Nombre,
                Apellido = registerRequest.Apellido,
                NombreUsuario = registerRequest.NombreUsuario,
                Contraseña = registerRequest.Contraseña,
                Mail = registerRequest.Mail
            };

            UsuarioBusiness.CrearUsuario(newUser);

            return CreatedAtRoute("GetUsuario", new { id = newUser.Id }, newUser);
        }

        // POST: api/Session/Logout
        [HttpPost("Logout", Name = "Logout")]
        public IActionResult Logout()
        {
            return Ok("Logged out successfully");
        }
    }
}
