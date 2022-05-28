using Microsoft.EntityFrameworkCore;
using Conexao.Models;


namespace Conexao.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Contato> Contato { get; set; }
        public DbSet<Pagamento> Pagamento { get; set; }
        public DbSet<Registro> Registro { get; set; }
        public DbSet<Relacionamento> Relacionamento { get; set; }
        public DbSet<TipoRelacionamento> TipoRelacionamento { get; set; }
        public DbSet<TiposOcorrencias> TiposOcorrencias { get; set; }
        public DbSet<StatusPagamento> StatusPagamentos { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoRelacionamento>().HasData
            (
                new TipoRelacionamento() {Id = 1, DsTipoRelacionamento ="Standard"},
                new TipoRelacionamento() {Id = 2, DsTipoRelacionamento= "Premium"}
            );

            modelBuilder.Entity<TiposOcorrencias>().HasData
            (
                new TiposOcorrencias() {Id = 1, dsTiposOcorrencias = "Furto"},
                new TiposOcorrencias() {Id = 2, dsTiposOcorrencias = "Agressão"},
                new TiposOcorrencias() {Id = 3, dsTiposOcorrencias = "Assédio"},
                new TiposOcorrencias() {Id = 4, dsTiposOcorrencias = "Roubo"}
            );

            /*modelBuilder.Entity<StatusPagamento>().HasData
            (
                
                new StatusPagamento() {dsStatusPagamento = "Agendado"},
                new StatusPagamento() {Id= 2, dsStatusPagamento = "Cancelado"},
                new StatusPagamento() {Id= 3, dsStatusPagamento = "Recebido"},
                new StatusPagamento() {Id= 1, dsStatusPagamento = "Pendente"}
            );*/


        }
    }
}