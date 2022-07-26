namespace APIRotonda.Models
{
    public class Cliente
    {
        public int id { get; set; }
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string ciudad { get; set; }

        public List<Pedido> Pedido { get; set; }
    }
}
