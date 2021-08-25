using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.MapEntidade
{
    class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            //Table
            builder.ToTable("Empresas");


            //PK e FK
            builder.HasKey(emp => emp.Id)
                .HasName("PK_Empresas_Id");

            //index 
            builder.HasIndex(emp => emp.Id)
                .HasDatabaseName("I_Empresas_Id");

            builder.HasIndex(emp => emp.NomeEmpresa)
                .HasDatabaseName("I_Empresas_NomeEmpresa");

            builder.HasIndex(emp => emp.CNPJ)
                .HasDatabaseName("I_Empresas_CNPJ");


            //campos
            builder.Property(emp => emp.Id)
                .HasColumnName("EmpresaID")
                .IsRequired();
        }
    }
}
