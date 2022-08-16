using APIRotonda.DTO.Cliente;
using APIRotonda.DTO.Ingrediente;
using APIRotonda.DTO.Pedido;
using APIRotonda.DTO.Plato;
using APIRotonda.DTO.Restaurante;
using APIRotonda.DTO.TipoPlato;
using APIRotonda.Models;
using AutoMapper;

namespace APIRotonda.Services.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<ClienteCreacionDTO, Cliente>();
            CreateMap<Cliente, ClienteConsultaDTO>();
            
            CreateMap<RestauranteCreacionDTO, Restaurante>();
            CreateMap<Restaurante, RestauranteConsultaDTO>();
            
            CreateMap<PlatoCreacionDTO, Plato>()
                .ForMember(plato => plato.IngredientePlato, opciones => opciones.MapFrom(MapIngredientePlato));
            CreateMap<Plato, PlatoConsultaDTO>();
            CreateMap<Plato, PlatoConIngredientesDTO>();


            CreateMap<Pedido, PedidoConPlatosDTO>()
                .ForMember(pedido => pedido.Platos, opciones => opciones.MapFrom(MapPedidoConPlato));

            CreateMap<Plato, PlatoConIngredientesDTO>()
                .ForMember(plato => plato.Ingredientes, opciones => opciones.MapFrom(MapPlatoConIngredientes));

            CreateMap<TipoPlatoCreacionDTO, TipoPlato>();
            CreateMap<TipoPlato, TipoPlatoConsultaDTO>();
            
            CreateMap<PedidoCreacionDTO, Pedido>()
                .ForMember(pedido => pedido.PedidoPlato, opciones => opciones.MapFrom(MapPedidoPlato));
            CreateMap<Pedido, PedidoConsultaDTO>();

            CreateMap<IngredienteCreacionDTO, Ingrediente>();
            CreateMap<Ingrediente, IngredienteConsultaDTO>();
        }

        private List<IngredienteConsultaDTO> MapPlatoConIngredientes(Plato plato, PlatoConsultaDTO platoDTO)
        {
            var ingredientesDTO = new List<IngredienteConsultaDTO>();
            if (plato.IngredientePlato == null) return null;
            foreach (var ingredientePlato in plato.IngredientePlato)
            {
                ingredientesDTO.Add(new IngredienteConsultaDTO
                {
                    id = ingredientePlato.Ingrediente.id,
                    nombre = ingredientePlato.Ingrediente.nombre,
                    costoUnitario = ingredientePlato.Ingrediente.costoUnitario
                });
            }
            return ingredientesDTO;
        }

        private List<PlatoConsultaDTO> MapPedidoConPlato(Pedido pedido, PedidoConsultaDTO pedidoDTO)
        {
            var platosdto = new List<PlatoConsultaDTO>();
            if (pedido.PedidoPlato == null) return null;
            foreach (var pedidoPlato in pedido.PedidoPlato)
            {
                platosdto.Add(new PlatoConsultaDTO
                {
                    id = pedidoPlato.Plato.id,
                    nombrePlato = pedidoPlato.Plato.nombrePlato,
                    fkTipo = pedidoPlato.Plato.fkTipo
                });
            }
            return platosdto;
        }

        private List<IngredientePlato> MapIngredientePlato(PlatoCreacionDTO platoDTO, Plato plato)
        {
            var resultado = new List<IngredientePlato>();
            if (platoDTO.ingredientes == null) return resultado;

            foreach (var ingredienteId in platoDTO.ingredientes)
            {
                resultado.Add(new IngredientePlato() { fkIngrediente = ingredienteId});
            }

            return resultado;
        }

        private List<PedidoPlato> MapPedidoPlato(PedidoCreacionDTO pedidoDTO, Pedido pedido)
        {
            var resultado = new List<PedidoPlato>();

            if (pedidoDTO.platosId == null) return resultado;

            foreach (var platoId in pedidoDTO.platosId)
            {
                resultado.Add(new PedidoPlato() { fkPlato = platoId});
            }

            return resultado;
        }
    }
}
