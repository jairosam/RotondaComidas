using APIRotonda.Context;
using APIRotonda.DTO.Plato;
using APIRotonda.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIRotonda.Controllers
{
    [ApiController]
    [Route("api/{idRestaurante:int}/platos")]
    public class PlatoController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PlatoController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PlatoCreacionDTO platoDTO, [FromRoute] int idRestaurante)
        {
            var existeRestaurante = await context.Restaurante.AnyAsync(x => x.id == idRestaurante);
            if (!existeRestaurante) return NotFound($"El restaurante con id {idRestaurante} no fue encontrado");
            var plato = mapper.Map<Plato>(platoDTO);
            plato.fkRestaurante = idRestaurante;
            context.Add(plato);
            await context.SaveChangesAsync();
            return Ok("Elemento creado");
        }

        [HttpGet]
        public async Task<ActionResult<List<PlatoConsultaDTO>>> Get([FromRoute] int idRestaurante)
        {
            var existe = await context.Restaurante.AnyAsync(x => x.id == idRestaurante);
            if (!existe) return NotFound($"El restaurante con id {idRestaurante} no fue encontrado");
            var query = await context.Plato.Where(x => x.fkRestaurante == idRestaurante).ToListAsync();
            return mapper.Map<List<PlatoConsultaDTO>>(query);
        }
    }
}
