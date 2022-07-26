namespace APIRotonda.Models
{
    public class TipoPlato
    {
        public int id { get; set; }
        public string tipo { get; set; }

        // Propiedades de navegación
        public List<Plato> Plato { get; set; }
    }
}
