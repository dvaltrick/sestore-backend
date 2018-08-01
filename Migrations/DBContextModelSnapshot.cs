﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using softstoreapi.Database;

namespace softstoreapi.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("softstoreapi.Models.Imposto", b =>
                {
                    b.Property<int>("ImpostoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.Property<float>("Percentual");

                    b.HasKey("ImpostoId");

                    b.ToTable("Impostos");
                });

            modelBuilder.Entity("softstoreapi.Models.ItemVenda", b =>
                {
                    b.Property<int>("ItemVendaId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ProdutoId");

                    b.Property<float>("Quantidade");

                    b.Property<float>("TotalImpostos");

                    b.Property<float>("TotalItem");

                    b.Property<int?>("VendaId");

                    b.HasKey("ItemVendaId");

                    b.HasIndex("ProdutoId");

                    b.HasIndex("VendaId");

                    b.ToTable("ItemVenda");
                });

            modelBuilder.Entity("softstoreapi.Models.Produto", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CodigoBarras");

                    b.Property<string>("Nome");

                    b.Property<int?>("TipoProdutoId");

                    b.Property<float>("ValorUnitario");

                    b.HasKey("ProdutoId");

                    b.HasIndex("TipoProdutoId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("softstoreapi.Models.TipoProduto", b =>
                {
                    b.Property<int>("TipoProdutoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("TipoProdutoId");

                    b.ToTable("TiposProduto");
                });

            modelBuilder.Entity("softstoreapi.Models.TipoProdutoImposto", b =>
                {
                    b.Property<int>("TipoProdutoId");

                    b.Property<int>("ImpostoId");

                    b.HasKey("TipoProdutoId", "ImpostoId");

                    b.HasIndex("ImpostoId");

                    b.ToTable("TipoProdutoImposto");
                });

            modelBuilder.Entity("softstoreapi.Models.Venda", b =>
                {
                    b.Property<int>("VendaId")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Total");

                    b.Property<float>("TotalImpostos");

                    b.HasKey("VendaId");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("softstoreapi.Models.ItemVenda", b =>
                {
                    b.HasOne("softstoreapi.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId");

                    b.HasOne("softstoreapi.Models.Venda")
                        .WithMany("Itens")
                        .HasForeignKey("VendaId");
                });

            modelBuilder.Entity("softstoreapi.Models.Produto", b =>
                {
                    b.HasOne("softstoreapi.Models.TipoProduto", "Tipo")
                        .WithMany()
                        .HasForeignKey("TipoProdutoId");
                });

            modelBuilder.Entity("softstoreapi.Models.TipoProdutoImposto", b =>
                {
                    b.HasOne("softstoreapi.Models.Imposto", "Imposto")
                        .WithMany("TiposProdutosImpostos")
                        .HasForeignKey("ImpostoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("softstoreapi.Models.TipoProduto", "TipoProduto")
                        .WithMany("TiposProdutosImpostos")
                        .HasForeignKey("TipoProdutoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
