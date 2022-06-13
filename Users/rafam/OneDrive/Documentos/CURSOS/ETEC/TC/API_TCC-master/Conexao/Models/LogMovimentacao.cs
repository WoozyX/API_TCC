namespace Conexao.Models
{
    public class LogMovimentacao
    {
        public int Id { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public Cliente? Cliente { get; set; }
        public int ClienteId { get; set; }
        
    }
}