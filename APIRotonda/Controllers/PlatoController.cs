using APIRotonda.Context;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APIRotonda.Controllers
{
    [ApiController]
    [Route("api/platos")]
    public class PlatoController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PlatoController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
    }
}
