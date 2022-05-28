namespace Conexao.Models
{
    public class Relacionamento
    {
        public int Id { get; set; }
        public string? InRelacionamento { get; set; }
        public string? FimRelacionamento { get; set; }

        public TipoRelacionamento? TipoRelacionamento {get; set;}
        public int TipoRelacionamentoId { get; set; }
        
        public Cliente? Cliente { get; set; }
        public int ClienteId { get; set; }
    }
}