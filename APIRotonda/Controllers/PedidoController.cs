using APIRotonda.Context;
using APIRotonda.DTO.Pedido;
using APIRotonda.DTO.Plato;
using APIRotonda.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIRotonda.Controllers
{
    [ApiController]
    [Route("api/{idCliente:int}/pedido")]
    public class PedidoController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PedidoController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromRoute] int idCliente, [FromBody] PedidoCreacionDTO pedidoDTO)
        {
            if (pedidoDTO.platosId == null) return BadRequest("No es posible hacer un pedido sin platos");
            var platosIds = await context.Plato.Where(x => pedidoDTO.platosId.Contains(x.id)).Select(x => x.id).ToListAsync();
            if (pedidoDTO.platosId.Count != platosIds.Count) return BadRequest("Uno de los platos ingresados no existe");
            var pedido = mapper.Map<Pedido>(pedidoDTO);
            pedido.fkCliente = idCliente;
            context.Add(pedido);
            await context.SaveChangesAsync();
            return Ok("Pedido realizado correctamente");
        }

        [HttpGet]
        public async Task<ActionResult<List<PedidoConsultaDTO>>> GetPedidos([FromRoute] int idCliente)
        {
            var existeCliente = await context.Cliente.AnyAsync(x => x.id == idCliente);
            if (!existeCliente)
            {
                return BadRequest($"No existe cliente con id {idCliente}");
            }
            var pedido = await context.Pedido.Where(x => x.fkCliente == idCliente).ToListAsync();
            return mapper.Map<List<PedidoConsultaDTO>>(pedido);
        }
    }
}
