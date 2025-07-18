﻿// <auto-generated />
using System;
using Fiap.Api.Energy.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace Fiap.Api.Energy.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20250615214726_EnergyEntities")]
    partial class EnergyEntities
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Fiap.Api.Energy.Models.ClienteModel", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClienteId"));

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Observacao")
                        .HasMaxLength(500)
                        .HasColumnType("NVARCHAR2(500)");

                    b.Property<int>("RepresentanteId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("ClienteId");

                    b.HasIndex("RepresentanteId");

                    b.ToTable("Clientes", (string)null);
                });

            modelBuilder.Entity("Fiap.Api.Energy.Models.CustoEquipamentoModel", b =>
                {
                    b.Property<int>("CustoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustoId"));

                    b.Property<decimal>("CustoEquipamentoDia")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("CustoEquipamentoMensal")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("EquipamentoId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<decimal>("ValorKwh")
                        .HasColumnType("decimal(10,4)");

                    b.HasKey("CustoId");

                    b.HasIndex("EquipamentoId");

                    b.ToTable("CustosEquipamento", (string)null);
                });

            modelBuilder.Entity("Fiap.Api.Energy.Models.EquipamentoModel", b =>
                {
                    b.Property<int>("EquipamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EquipamentoId"));

                    b.Property<string>("EquipamentoNome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<decimal>("Potencia")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("UsoMinutoDia")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("EquipamentoId");

                    b.ToTable("Equipamentos", (string)null);
                });

            modelBuilder.Entity("Fiap.Api.Energy.Models.FornecedorModel", b =>
                {
                    b.Property<int>("FornecedorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FornecedorId"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("FornecedorId");

                    b.ToTable("Fornecedores", (string)null);
                });

            modelBuilder.Entity("Fiap.Api.Energy.Models.LojaModel", b =>
                {
                    b.Property<int>("LojaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LojaId"));

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("LojaId");

                    b.ToTable("Lojas", (string)null);
                });

            modelBuilder.Entity("Fiap.Api.Energy.Models.PedidoProdutoModel", b =>
                {
                    b.Property<int>("PedidoId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("PedidoId", "ProdutoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("PedidoProdutos");
                });

            modelBuilder.Entity("Fiap.Api.Energy.Models.ProdutoModel", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProdutoId"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("FornecedorId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("NUMBER(18,2)");

                    b.HasKey("ProdutoId");

                    b.HasIndex("FornecedorId");

                    b.ToTable("Produtos", (string)null);
                });

            modelBuilder.Entity("Fiap.Api.Energy.Models.RepresentanteModel", b =>
                {
                    b.Property<int>("RepresentanteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RepresentanteId"));

                    b.Property<string>("Cpf")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("NomeRepresentante")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("RepresentanteId");

                    b.HasIndex("Cpf")
                        .IsUnique()
                        .HasFilter("\"Cpf\" IS NOT NULL");

                    b.ToTable("Representantes", (string)null);
                });

            modelBuilder.Entity("PedidoModel", b =>
                {
                    b.Property<int>("PedidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PedidoId"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime>("DataPedido")
                        .HasColumnType("DATE");

                    b.Property<int>("LojaId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("PedidoId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("LojaId");

                    b.ToTable("Pedidos", (string)null);
                });

            modelBuilder.Entity("Fiap.Api.Energy.Models.ClienteModel", b =>
                {
                    b.HasOne("Fiap.Api.Energy.Models.RepresentanteModel", "Representante")
                        .WithMany()
                        .HasForeignKey("RepresentanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Representante");
                });

            modelBuilder.Entity("Fiap.Api.Energy.Models.CustoEquipamentoModel", b =>
                {
                    b.HasOne("Fiap.Api.Energy.Models.EquipamentoModel", "Equipamento")
                        .WithMany()
                        .HasForeignKey("EquipamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipamento");
                });

            modelBuilder.Entity("Fiap.Api.Energy.Models.PedidoProdutoModel", b =>
                {
                    b.HasOne("PedidoModel", "Pedido")
                        .WithMany("PedidoProdutos")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fiap.Api.Energy.Models.ProdutoModel", "Produto")
                        .WithMany("PedidoProdutos")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Fiap.Api.Energy.Models.ProdutoModel", b =>
                {
                    b.HasOne("Fiap.Api.Energy.Models.FornecedorModel", "Fornecedor")
                        .WithMany("Produtos")
                        .HasForeignKey("FornecedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fornecedor");
                });

            modelBuilder.Entity("PedidoModel", b =>
                {
                    b.HasOne("Fiap.Api.Energy.Models.ClienteModel", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fiap.Api.Energy.Models.LojaModel", "Loja")
                        .WithMany("Pedidos")
                        .HasForeignKey("LojaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Loja");
                });

            modelBuilder.Entity("Fiap.Api.Energy.Models.FornecedorModel", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("Fiap.Api.Energy.Models.LojaModel", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("Fiap.Api.Energy.Models.ProdutoModel", b =>
                {
                    b.Navigation("PedidoProdutos");
                });

            modelBuilder.Entity("PedidoModel", b =>
                {
                    b.Navigation("PedidoProdutos");
                });
#pragma warning restore 612, 618
        }
    }
}
