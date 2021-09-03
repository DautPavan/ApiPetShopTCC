using Dados.Utils;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.MapEntidade
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            //Table
            builder.ToTable("Produtos");


            //PK e FK
            builder.HasKey(prod => prod.Id)
                .HasName("PK_Produtos_Id");

            builder.HasOne(prod => prod.Empresa)
                .WithMany(emp => emp.Produto)
                .HasForeignKey(prod => prod.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);

            //index 
            builder.HasIndex(prod => prod.Id)
                .HasDatabaseName("I_Produtos_Id");

            builder.HasIndex(prod => prod.EmpresaId)
                .HasDatabaseName("I_Produtos_EmpresaId");

            builder.HasIndex(prod => prod.Nome)
                .HasDatabaseName("I_Produtos_Nome");


            //campos
            builder.Property(prod => prod.Id)
                .HasColumnName("ProdutoID")
                .IsRequired();

            builder.Property(prod => prod.EmpresaId)
                .IsRequired();

            builder.Property(prod => prod.PrecoUnit)
                .HasColumnType("decimal")
                .HasPrecision(ValorPrecision.Precision, ValorPrecision.Scale)
                .HasDefaultValue(0)
                .IsRequired();

        }
    }
}
