using Microsoft.EntityFrameworkCore;
using API_Pagamento.Models;

namespace API_Pagamento.Data{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<PagamentoCartao> PagamentoCartao { get; set; }
        public DbSet<PagamentoPix> PagamentosPix { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PagamentoCartao>().HasData(
                new PagamentoCartao() {numero_cartao = 1, valor = 230, nome_titular = "HENRIQUE N SILVA", codigo_seguranca = 245, cpf_titular = "12345678912"},
                new PagamentoCartao() {numero_cartao = 2, valor = 240, nome_titular = "EMILLY R SILVA", codigo_seguranca = 254, cpf_titular = "32165498732"}

            );
            modelBuilder.Entity<PagamentoPix>().HasData(
                new PagamentoPix() {id_pagamento = "1", valor = 100, chave_pix = "minha chave pix", data_pagamento = DateTime.Now, nome_emissor="Henrique N Silva", nome_receptor="Emilly R Silva"},
                new PagamentoPix() {id_pagamento = "2", valor = 120, chave_pix = "sua chave pix", data_pagamento = DateTime.Now, nome_emissor="Emilly R Silva", nome_receptor="Henrique N Silva"}

            );
        }
    }
}