namespace APIRotonda.DTO.Plato
{
    public class PlatoCreacionDTO
    {
        public string nombrePlato { get; set; }
        public string foto { get; set; }
        public List<int> ingredientes { get; set; }
        public int fkTipo { get; set; }
    }
}
