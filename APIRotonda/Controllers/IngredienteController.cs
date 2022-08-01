using APIRotonda.Context;
using APIRotonda.DTO.Ingrediente;
using APIRotonda.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APIRotonda.Controllers
{
    [ApiController]
    [Route("api/ingredientes")]
    public class IngredienteController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public IngredienteController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        
    }
}
