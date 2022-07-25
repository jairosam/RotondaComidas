namespace APIRotonda.Models
{
    #pragma warning disable
    public class Restaurante
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string nit { get; set; }
        public string direccion { get; set; }
        public string ciudad { get; set; }

        // Propiedades de navegación
        public List<Plato> Plato { get; set; }
        
    }
}
