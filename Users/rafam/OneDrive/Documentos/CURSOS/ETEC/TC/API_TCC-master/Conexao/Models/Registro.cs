namespace Conexao.Models
{
    public class Registro
    {
        public int Id { get; set; }
        public string? Latitude { get; set; }  
        public string? Longitude { get; set; }
        public string? MtRegistro { get; set; }
        public string? MtRegistrado { get; set; }
        public string? dsRegistro { get; set; }
        public TiposOcorrencias? TiposOcorrencias { get; set; } 
        public int TiposOcorrenciasId { get; set; }

    }
}