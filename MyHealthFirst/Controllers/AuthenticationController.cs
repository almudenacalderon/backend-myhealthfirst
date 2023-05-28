using DB;
using DB.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyHealthFirst.Configuration;
using MyHealthFirst.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyHealthFirst.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtConfig _jwtConfig;
        private readonly ProjectDBContext _context;

        public AuthenticationController(UserManager<IdentityUser> userManager,
            IOptions <JwtConfig> jwtConfig, ProjectDBContext context)
        {
            _userManager = userManager;
            _jwtConfig = jwtConfig.Value;
            _context = context;

        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequestDto request)
        {
            if(!ModelState.IsValid) return BadRequest();

            //verificar si el email existe
            var emailExits = await _userManager.FindByEmailAsync(request.EmailAddress);

            if(emailExits != null)
                return BadRequest(new AuthResult()
                {
                    Result = false,
                    Errors = new List<string>()
                    {
                        "El email ya existe"
                    }
                });
            //creamos el usuario
            var user = new IdentityUser()
            {
                Email = request.EmailAddress,
                UserName = request.EmailAddress
            };
            var isCreated = await _userManager.CreateAsync(user, request.Password);
            if(isCreated.Succeeded)
            {   // Asignar el rol al usuario
                await _userManager.AddToRoleAsync(user, request.Role);

                // Crear entidad en función del rol
                switch (request.Role)
                {
                    case "Cliente":
                        var cliente = new Client()
                        {
                            UserId = user.Id,
                            User = user,
                            Nombre = request.Name,
                            Email = request.EmailAddress,
                            Password = request.Password
                            
                        };
                        _context.Clients.Add(cliente);
                        await _context.SaveChangesAsync();
                        break;
                    case "Entrenador":
                        var entrenador = new Trainer()
                        {
                            UserId = user.Id,
                            User = user,
                            Nombre = request.Name,
                            Email = request.EmailAddress,
                            Password = request.Password
                           
                        };
                        _context.Trainers.Add(entrenador);
                        await _context.SaveChangesAsync();
                        break;
                    case "Nutricionista":
                        var nutricionista = new Nutricionist()
                        {
                            UserId = user.Id,
                            User = user,
                            Nombre = request.Name,
                            Email = request.EmailAddress,
                            Password = request.Password
                            
                        };
                        _context.Nutricionists.Add(nutricionista);
                        await _context.SaveChangesAsync();
                        break;
                    default:
                        // Caso de rol no reconocido
                        return BadRequest(new AuthResult()
                        {
                            Result = false,
                            Errors = new List<string>()
                {
                    "Rol no válido"
                }
                        });
                }
                var token = GenerateToken(user);
                return Ok(new AuthResult()
                {
                    Result = true,
                    Token = token
                });
            }
            else
            {
                var errors = new List<string>();
                foreach (var err in isCreated.Errors)
                    errors.Add(err.Description);
                return BadRequest(new AuthResult()
                {
                    Result = false,
                    Errors = errors
                });
            }
            
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestDto request)
        {
            if (!ModelState.IsValid) return BadRequest();

            //comprobar si el user existe

            var existingUser = await _userManager.FindByEmailAsync(request.Email);
            if (existingUser == null)
                return BadRequest(new AuthResult
                {
                    Errors = new List<string> { "Invalid payload" },
                    Result = false
                });

            var checkUserAndPass = await _userManager.CheckPasswordAsync(existingUser, request.Password);
            if (!checkUserAndPass)
                return BadRequest(new AuthResult
                {
                    Errors = new List<string> { "Invalid credentials" },
                    Result = false
                });

            var token = GenerateToken(existingUser); 
            return Ok(new AuthResult { Token = token, Result = true });
        }
        private string GenerateToken(IdentityUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtConfig.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new ClaimsIdentity(new[]
               {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString())
                })),
               Expires = DateTime.Now.AddHours(1),
               SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
              };
             var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);

        }

    }
}
