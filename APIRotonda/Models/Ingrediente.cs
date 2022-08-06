using System.ComponentModel.DataAnnotations.Schema;

namespace APIRotonda.Models
{
    public class Ingrediente
    {
        public int id { get; set; }
        public string nombre { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal costoUnitario { get; set; }

        public List<IngredientePlato> IngredientePlato { get; set; } 
    }
}
