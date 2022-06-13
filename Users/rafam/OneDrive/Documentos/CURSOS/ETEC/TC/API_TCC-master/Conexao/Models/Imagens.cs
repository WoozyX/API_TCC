namespace Conexao.Models
{
    public class Imagens
    {
        public int Id { get; set; }
        public string? Imagem { get; set; }
        public Cliente? Cliente { get; set; }
        public int ClienteId { get; set; }


    }
}