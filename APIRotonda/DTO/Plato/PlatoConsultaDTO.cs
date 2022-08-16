namespace APIRotonda.DTO.Plato
{
    public class PlatoConsultaDTO
    {
        public int id { get; set; }
        public string nombrePlato { get; set; }
        public int costo { get; set; }
        public int fkTipo { get; set; }
    }
}
