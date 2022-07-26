using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIRotonda.Models
{
    public class Plato
    {
        public int id { get; set; }

        [Required]
        public string nombrePlato { get; set; }

        // Asignación de foraneas
        [ForeignKey("Restaurante")]
        public int fkRestaurante { get; set; }
        public Restaurante Restaurante { get; set; }

        [ForeignKey("TipoPlato")]
        public int fkTipo { get; set; }
        public TipoPlato TipoPlato { get; set; }

        //Propiedades de navegación
        public List<IngredientePlato> IngredientePlato { get; set; }
        public List<PedidoPlato> PedidoPlato { get; set; }
    }
}
