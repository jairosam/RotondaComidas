using APIRotonda.Context;
using APIRotonda.DTO.TipoPlato;
using APIRotonda.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIRotonda.Controllers
{
    [ApiController]
    [Route("api/tipoPlato")]
    public class TipoPlatoController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public TipoPlatoController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TipoPlatoCreacionDTO tipoPlatoDTO)
        {
            var existe = await context.TipoPlato.AnyAsync(x => x.tipo.Equals(tipoPlatoDTO.tipo));
            if (existe) return BadRequest($"Ya hay un tipo de plato con nombre {tipoPlatoDTO.tipo}");
            var tipoPlato = mapper.Map<TipoPlato>(tipoPlatoDTO);
            context.Add(tipoPlato);
            await context.SaveChangesAsync();
            return Ok("Tipo Plato Creado");
        }

        [HttpGet]
        public async Task<ActionResult<List<TipoPlatoConsultaDTO>>> Get()
        {
            var listado = await context.TipoPlato.ToListAsync();
            return mapper.Map<List<TipoPlatoConsultaDTO>>(listado);
        }
    }
}
