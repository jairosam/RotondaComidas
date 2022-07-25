using APIRotonda.Context;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

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
    }
}
