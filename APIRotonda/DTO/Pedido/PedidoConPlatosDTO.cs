using APIRotonda.DTO.Plato;

namespace APIRotonda.DTO.Pedido
{
    public class PedidoConPlatosDTO : PedidoConsultaDTO
    {
        public List<PlatoConsultaDTO> Platos { get; set;}
    }
}
