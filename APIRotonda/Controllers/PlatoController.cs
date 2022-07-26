﻿using APIRotonda.Context;
using APIRotonda.DTO.Plato;
using APIRotonda.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIRotonda.Controllers
{
    [ApiController]
    [Route("api/{idRestaurante:int}/platos")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PlatoController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public PlatoController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PlatoCreacionDTO platoDTO, [FromRoute] int idRestaurante)
        {
            var existeRestaurante = await context.Restaurante.AnyAsync(x => x.id == idRestaurante);
            if (!existeRestaurante) return NotFound($"El restaurante con id {idRestaurante} no fue encontrado");
            var ingredientesIds = await context.Ingrediente.Where(x => platoDTO.ingredientes.Contains(x.id)).Select(x => x.id).ToListAsync();
            if (ingredientesIds.Count != platoDTO.ingredientes.Count) return NotFound("Uno de los ingredientes solicitados no se encuentra en la base de datos"); 
            var plato = mapper.Map<Plato>(platoDTO);
            plato.fkRestaurante = idRestaurante;
            context.Add(plato);
            await context.SaveChangesAsync();
            return Ok("Elemento creado");
        }

        [HttpGet]
        public async Task<ActionResult<List<PlatoConsultaDTO>>> Get([FromRoute] int idRestaurante)
        {
            var existe = await context.Restaurante.AnyAsync(x => x.id == idRestaurante);
            if (!existe) return NotFound($"El restaurante con id {idRestaurante} no fue encontrado");
            var query = await context.Plato.Where(x => x.fkRestaurante == idRestaurante).ToListAsync();
            return mapper.Map<List<PlatoConsultaDTO>>(query);
        }

        [HttpGet("{idPlato:int}")]
        public async Task<ActionResult<PlatoConIngredientesDTO>> GetPlato([FromRoute] int idRestaurante, [FromRoute] int idPlato)
        {
            var restaurante = await context.Restaurante.FirstOrDefaultAsync(x => x.id == idRestaurante);
            if (restaurante == null) return NotFound($"No se encuentra el restaurante con id {idRestaurante}");
            var plato = await context.Plato
                .Include(x => x.IngredientePlato)
                .ThenInclude(x => x.Ingrediente)
                .FirstOrDefaultAsync(x => x.id == idPlato);
            if (plato == null) return NotFound($"No se encuentra el plato con id {idPlato}");
            if (plato.fkRestaurante != restaurante.id) return NotFound($"El plato solicitado no pertenece al restaurante");
            var retorno = mapper.Map<PlatoConIngredientesDTO>(plato);
            return retorno;
        }

    }
}
