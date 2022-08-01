using APIRotonda.DTO.Cliente;
using APIRotonda.DTO.Restaurante;
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
        }
    }
}
