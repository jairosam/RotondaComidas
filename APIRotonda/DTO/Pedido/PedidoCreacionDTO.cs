namespace APIRotonda.DTO.Pedido
{
    public class PedidoCreacionDTO
    {
        public decimal numeroPedido { get; set; }
        public string ciudad { get; set; }
        public string direccionEntrega { get; set; }
        public DateTime fecha { get; set; }
        public string comentarios { get; set; }
        public bool estado { get; set; }
        public List<int> platosId { get; set; } 
    }
}
