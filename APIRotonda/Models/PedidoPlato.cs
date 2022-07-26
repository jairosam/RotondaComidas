using System.ComponentModel.DataAnnotations.Schema;

namespace APIRotonda.Models
{
    public class PedidoPlato
    {
        [ForeignKey("Plato")]
        public int fkPlato { get; set; }
        public Plato Plato { get; set; }

        [ForeignKey("Pedido")]
        public int fkPedido { get; set; }
        public Pedido Pedido { get; set; }
    }
}
