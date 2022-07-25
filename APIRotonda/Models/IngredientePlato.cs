using System.ComponentModel.DataAnnotations.Schema;

namespace APIRotonda.Models
{
    #pragma warning disable
    public class IngredientePlato
    {
        [ForeignKey("Plato")]
        public int fkPlato { get; set; }
        public Plato Plato { get; set; }


        [ForeignKey("Ingrediente")]
        public int fkIngrediente { get; set; }
        public Ingrediente Ingrediente { get; set; }

    }
}
