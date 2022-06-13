namespace Conexao.Models
{
    public class Pagamento
    {
        public int Id { get; set; }
        public string? MrPagamento { get; set; }
        public string? DtPagamento { get; set; }
        public string? PxPagamento { get; set; }
        public float? VlPagamento { get; set; }
        public Cliente? CLiente { get; set; }
        public int ClienteId { get; set; }
        public StatusPagamento? StatusPagamento { get; set; }
        public int StatusPagId { get; set; }

    }
}