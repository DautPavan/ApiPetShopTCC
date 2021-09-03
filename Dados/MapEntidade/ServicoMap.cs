using Dados.Utils;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.MapEntidade
{
    public class ServicoMap : IEntityTypeConfiguration<Servico>
    {
        public void Configure(EntityTypeBuilder<Servico> builder)
        {
            //Table
            builder.ToTable("Servicos");


            //PK e FK
            builder.HasKey(servic => servic.Id)
                .HasName("PK_Servicos_Id");

            builder.HasOne(servic => servic.Empresa)
                .WithMany(emp => emp.Servico)
                .HasForeignKey(servic => servic.EmpresaId)
                .OnDelete(DeleteBehavior.Restrict);


            //index 
            builder.HasIndex(servic => servic.Id)
                .HasDatabaseName("I_Servicos_Id");

            builder.HasIndex(servic => servic.EmpresaId)
                .HasDatabaseName("I_Servicos_EmpresaId");

            builder.HasIndex(servic => servic.NomeServico)
                .HasDatabaseName("I_Servicos_NomeServico");


            //campos
            builder.Property(servic => servic.Id)
                .HasColumnName("ServicoID")
                .IsRequired();

            builder.Property(servic => servic.EmpresaId)
                .IsRequired();
            
            builder.Property(servic => servic.Valor)
                .HasColumnType("decimal")
                .HasPrecision(ValorPrecision.Precision, ValorPrecision.Scale)
                .HasDefaultValue(0)
                .IsRequired();

        }
    }
}
