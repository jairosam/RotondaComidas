using System.ComponentModel.DataAnnotations;

namespace APIRotonda.Models
{
    public class TipoPlato
    {
        [Key]
        public int id { get; set; }
        public string tipo { get; set; }

        // Propiedades de navegación
        public List<Plato> Plato { get; set; }
    }
}
