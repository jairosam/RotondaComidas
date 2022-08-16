using APIRotonda.DTO.Ingrediente;

namespace APIRotonda.DTO.Plato
{
    public class PlatoConIngredientesDTO : PlatoConsultaDTO
    {
        public List<IngredienteConsultaDTO> Ingredientes { get; set; }
    }
}
