using Fiap.Api.Energy.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Fiap.Api.Energy.Data.Contexts
{
    public class DatabaseContext : DbContext
    {

        
        public virtual DbSet<EquipamentoModel> Equipamento { get; set; }
        public virtual DbSet<CustoEquipamentoModel> CustoEquipamento { get; set; }
      


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            // Configuração para EquipamentoModel
            modelBuilder.Entity<EquipamentoModel>(entity =>
            {
                entity.ToTable("Equipamentos");

                entity.HasKey(e => e.EquipamentoId);

                entity.Property(e => e.EquipamentoNome)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(e => e.Potencia)
                      .IsRequired()
                      .HasColumnType("decimal(10,2)");

                entity.Property(e => e.UsoMinutoDia)
                      .IsRequired();
            });

            // Configuração para CustoEquipamentoModel
            modelBuilder.Entity<CustoEquipamentoModel>(entity =>
            {
                entity.ToTable("CustosEquipamento");

                entity.HasKey(c => c.CustoId);

                entity.Property(c => c.ValorKwh)
                      .IsRequired()
                      .HasColumnType("decimal(10,4)");

                entity.Property(c => c.CustoEquipamentoDia)
                      .HasColumnType("decimal(10,2)");

                entity.Property(c => c.CustoEquipamentoMensal)
                      .HasColumnType("decimal(10,2)");

                // Relacionamento com EquipamentoModel (1:N)
                entity.HasOne(c => c.Equipamento)
                      .WithMany()
                      .HasForeignKey(c => c.EquipamentoId)
                      .OnDelete(DeleteBehavior.Cascade);
            });


        }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
        protected DatabaseContext()
        {
        }
    }
}