namespace APIRotonda.DTO.Pedido
{
    public class PedidoConsultaDTO
    {
        public int id { get; set; }
        public decimal numeroPedido { get; set; }
        public string ciudad { get; set; }
        public string direccionEntrega { get; set; }
        public DateTime fecha { get; set; }
        public string comentarios { get; set; }
        public bool estado { get; set; }
    }
}
