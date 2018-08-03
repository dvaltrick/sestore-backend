using Microsoft.EntityFrameworkCore;
using softstoreapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace softstoreapi.Database
{
    public class DBContext: DbContext
    {
        public DbSet<Imposto> Impostos { get; set; }

        public DbSet<TipoProduto> TiposProduto { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Venda> Vendas { get; set; }

        public DbSet<TipoProdutoImposto> TipoProdutoImposto {get; set;}


        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DBContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var config = DBConfigService.Carregar();
            //optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=softstore;User Id=postgres;Password=postgre;");
            optionsBuilder.UseNpgsql($"Server={config.Server};Port={config.Port};Database={config.Database};User Id={config.User};Password={config.Password};");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoProdutoImposto>()
                        .HasKey(key => new { key.TipoProdutoId, key.ImpostoId });
            modelBuilder.Entity<TipoProdutoImposto>()
                .HasOne(tp => tp.TipoProduto)
                .WithMany("TiposProdutosImpostos");
            
            modelBuilder.Entity<TipoProdutoImposto>()
                .HasOne(imp => imp.Imposto)
                .WithMany("TiposProdutosImpostos");
        }
    }
}
