using APIRotonda.Context;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APIRotonda.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClienteController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ClienteController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
    }
}
