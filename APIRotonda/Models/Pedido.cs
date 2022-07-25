﻿using System.ComponentModel.DataAnnotations.Schema;

namespace APIRotonda.Models
{
    #pragma warning disable
    public class Pedido
    {
        public int id { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal numeroPedido { get; set; }
        public string ciudad { get; set; }
        public string direccionEntrega { get; set; }
        public DateTime fecha { get; set; }
        public string comentarios { get; set; }
        public bool estado { get; set; }

        [ForeignKey("Cliente")]
        public int fkCliente { get; set; }
        public Cliente Cliente { get; set; }

        public List<PedidoPlato> PedidoPlato { get; set; }
    }
}
