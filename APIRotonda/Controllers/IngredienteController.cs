﻿using APIRotonda.Context;
using APIRotonda.DTO.Ingrediente;
using APIRotonda.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIRotonda.Controllers
{
    [ApiController]
    [Route("api/ingredientes")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class IngredienteController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public IngredienteController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] IngredienteCreacionDTO ingredienteDTO)
        {
            var existe = await context.Ingrediente.AnyAsync(x => x.nombre.Equals(ingredienteDTO.nombre));
            if (existe)
            {
                return BadRequest($"Ya existe un ingrediente con el nombre {ingredienteDTO.nombre}");
            }
            var ingrediente = mapper.Map<Ingrediente>(ingredienteDTO);
            context.Add(ingrediente);
            await context.SaveChangesAsync();
            return Ok("Ingrediente creado correctamente");
        }

        [HttpGet]
        public async Task<ActionResult<List<IngredienteConsultaDTO>>> Get()
        {
            var listado = await context.Ingrediente.ToListAsync();
            return mapper.Map<List<IngredienteConsultaDTO>>(listado);
        }
    }
}
