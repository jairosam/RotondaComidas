using APIRotonda.Context;
using APIRotonda.DTO.Pedido;
using APIRotonda.DTO.Plato;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIRotonda.Controllers
{
    [ApiController]
    [Route("pedido/plato/{idPedido:int}")]
    public class PedidoPlatoController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PedidoPlatoController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<PedidoConPlatosDTO>> Get([FromRoute] int idPedido)
        {
            var existe = await context.Pedido.AnyAsync(x => x.id == idPedido);
            if (!existe) return BadRequest($"El pedido con id {idPedido} no existe");
            var pedido = await context.Pedido
                .Include(x => x.PedidoPlato)
                .ThenInclude(x => x.Plato)
                .FirstOrDefaultAsync(x => x.id == idPedido);
            var PlatoConsulta = mapper.Map<PedidoConPlatosDTO>(pedido);
            return PlatoConsulta;
        }

    }
}
