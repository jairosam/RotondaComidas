using APIRotonda.Context;
using APIRotonda.DTO.Cliente;
using APIRotonda.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIRotonda.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ClienteController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly UserManager<IdentityUser> userManager;

        public ClienteController(ApplicationDbContext context, IMapper mapper,
            UserManager<IdentityUser> userManager)
        {
            this.context = context;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClienteCreacionDTO clienteDTO)
        {
            var emailClaim = HttpContext.User.Claims.Where(claim => claim.Type == "email").FirstOrDefault();
            var email = emailClaim.Value;
            var user = await userManager.FindByEmailAsync(email);
            var userId = user.Id;
            var existeUser = await context.Cliente.AnyAsync(x => x.userId.Equals(userId));
            if (existeUser) return BadRequest("Este correo ya se encuentra asociado a un cliente");
            var existe = await context.Cliente.AnyAsync(x => x.cedula.Equals(clienteDTO.cedula));
            if (existe) return BadRequest($"Ya existe un usuario con identificador {clienteDTO.cedula}");
            var cliente = mapper.Map<Cliente>(clienteDTO);
            cliente.userId = userId;
            context.Add(cliente);
            await context.SaveChangesAsync();
            return Ok($"Created At Route api/clientes/{cliente.id}");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put([FromBody] ClienteCreacionDTO clienteDTO,[FromRoute] int id)
        {
            var existe = await context.Cliente.AnyAsync(x => x.id == id);
            if (existe) return NotFound($"no existe el cliente con id {id}");
            var cliente = mapper.Map<Cliente>(clienteDTO);
            cliente.id = id;
            context.Update(cliente);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<ClienteConsultaDTO>>> Get()
        {
            var clientes = await context.Cliente.ToListAsync();
            return mapper.Map<List<ClienteConsultaDTO>>(clientes);
        }


        [HttpGet("clienteLogin")]
        public async Task<ActionResult<ClienteConsultaDTO>> GetCliente()
        {
            var emailClaim = HttpContext.User.Claims.Where(claim => claim.Type == "email").FirstOrDefault();
            var email = emailClaim.Value;
            var user = await userManager.FindByEmailAsync(email);
            var userId = user.Id;
            var cliente = await context.Cliente.FirstOrDefaultAsync(x => x.userId.Equals(userId));
            return mapper.Map<ClienteConsultaDTO>(cliente);
            
        }

        [HttpGet("{cedula}")]
        public async Task<ActionResult<ClienteConsultaDTO>> GetCedula([FromRoute] string cedula)
        {
            var cliente = await context.Cliente.FirstOrDefaultAsync(x => x.cedula.Equals(cedula));
            if (cliente == null) return NotFound($"cliente con identificador {cedula} no encontrado");
            return mapper.Map<ClienteConsultaDTO>(cliente);
        }
    }
}
