using APIRotonda.DTO.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIRotonda.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration configuration;
        private readonly SignInManager<IdentityUser> signInManager;

        public UsersController(UserManager<IdentityUser> userManager, IConfiguration configuration,
            SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.signInManager = signInManager;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<AuthenticationResponse>> Register([FromBody] UserCredentials userCredentials)
        {
            var usuario = new IdentityUser { UserName = userCredentials.email, Email = userCredentials.email };
            var resultado = await userManager.CreateAsync(usuario, userCredentials.password);
            if (resultado.Succeeded)
            {
                return CreateToken(userCredentials);
            }
            else
            {
                return BadRequest(resultado.Errors);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthenticationResponse>> Login([FromBody] UserCredentials userCredentials)
        {
            var resultado = await signInManager.PasswordSignInAsync(userCredentials.email, userCredentials.password
                , isPersistent: false, lockoutOnFailure: false);
            if (resultado.Succeeded)
            {
                return CreateToken(userCredentials);
            }
            else
            {
                return BadRequest("Wrong Login");
            }
        }

        private AuthenticationResponse CreateToken(UserCredentials userCredentials)
        {
            var claims = new List<Claim>()
            {
                new Claim("email", userCredentials.email),
            };

            var llaveJwt = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["llavejwt"]));
            var credentials = new SigningCredentials(llaveJwt, SecurityAlgorithms.HmacSha256);
            var expire = DateTime.UtcNow.AddHours(3);
            var securityToken = new JwtSecurityToken(issuer: null, audience: null, claims: claims,
                expires: expire, signingCredentials: credentials);
            return new AuthenticationResponse()
            {
                token = new JwtSecurityTokenHandler().WriteToken(securityToken),
                expiration = expire
            };
        }
    }
}
