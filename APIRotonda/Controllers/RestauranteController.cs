using APIRotonda.Context;
using APIRotonda.DTO.Restaurante;
using APIRotonda.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIRotonda.Controllers
{
    [ApiController]
    [Route("api/restaurante")]
    public class RestauranteController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public RestauranteController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RestauranteCreacionDTO restauranteDTO)
        {
            var existe = await context.Restaurante.AnyAsync(x => x.nit.Equals(restauranteDTO.nit));
            if (existe) return BadRequest($"ya existe restaurante con número de identificación {restauranteDTO.nit}");
            var restaurante = mapper.Map<Restaurante>(restauranteDTO);
            context.Add(restaurante);
            await context.SaveChangesAsync();
            return Ok("Restaurante Creado");
        }

        [HttpGet]
        public async Task<ActionResult<List<RestauranteConsultaDTO>>> Get()
        {
            var restaurantes = await context.Restaurante.ToListAsync();
            return mapper.Map<List<RestauranteConsultaDTO>>(restaurantes);
        }

        [HttpGet("{nit}")]
        public async Task<ActionResult<RestauranteConsultaDTO>> Get([FromRoute] string nit)
        {
            var restaurante = await context.Restaurante.FirstOrDefaultAsync(x => x.nit.Equals(nit));
            if (restaurante == null) return NotFound($"No se encuentran restaurantes con nit {nit}");
            return mapper.Map<RestauranteConsultaDTO>(restaurante);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put([FromBody] RestauranteCreacionDTO restauranteDTO, [FromRoute] int id)
        {
            var existe = await context.Restaurante.AnyAsync(x => x.id == id);
            if (!existe) return NotFound($"No se encuentra restaurante con id {id}");
            var restaurante = mapper.Map<Restaurante>(restauranteDTO);
            restaurante.id = id;
            context.Update(restaurante);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
