using APIRotonda.Context;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APIRotonda.Controllers
{
    [ApiController]
    [Route("api/ingredientes")]
    public class IngredienteController : Controller
    {
        private readonly ApplicationDbContext context;

        public IngredienteController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
        }
    }
}
