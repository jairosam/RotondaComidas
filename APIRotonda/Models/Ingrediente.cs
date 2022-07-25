using System.ComponentModel.DataAnnotations.Schema;

namespace APIRotonda.Models
{
#pragma warning disable
    public class Ingrediente
    {
        public int id { get; set; }
        public string tipo { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal costoUnitario { get; set; }

        public List<IngredientePlato> IngredientePlato { get; set; } 
    }
}
