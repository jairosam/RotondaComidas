using APIRotonda.DTO.Cliente;
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
        }
    }
}
