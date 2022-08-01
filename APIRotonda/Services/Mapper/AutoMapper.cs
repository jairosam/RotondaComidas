using APIRotonda.DTO.Cliente;
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
            CreateMap<PlatoCreacionDTO, Plato>();
            CreateMap<Plato, PlatoConsultaDTO>();
            CreateMap<TipoPlatoCreacionDTO, TipoPlato>();
            CreateMap<TipoPlato, TipoPlatoConsultaDTO>();
            CreateMap<PedidoCreacionDTO, Pedido>()
                .ForMember(pedido => pedido.PedidoPlato, opciones => opciones.MapFrom(MapPedidoPlato));
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
