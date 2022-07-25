using APIRotonda.Context;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APIRotonda.Controllers
{
    [ApiController]
    [Route("api/pedido")]
    public class PedidoController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PedidoController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
    }
}
