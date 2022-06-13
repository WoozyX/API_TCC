namespace Conexao.Models
{
    public class Contato
    {
        public int Id { get; set; }
        public string? Nome_Contato { get; set; }
        public string? Tel_contato{ get; set; }
        public Cliente? Cliente { get; set; }
        public int ClienteId { get; set; }
    }
}