using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.MapEntidade
{
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            //Table
            builder.ToTable("Funcionarios");


            //PK e FK
            builder.HasKey(func => func.Id)
                .HasName("PK_Funcionarios_ID");

            builder.HasOne(func => func.Gerente)
                .WithMany(func => func.Funcionarios)
                .HasForeignKey(func => func.GerenteId)
                .HasConstraintName("FK_Funcionarios_IDXFuncionarios_GerenteID")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(func => func.Empresa)
                .WithMany(emp => emp.Funcionario)
                .HasForeignKey(func => func.EmpresaId)
                .HasConstraintName("FK_Funcionarios_EmpresaIDXEmpresa_ID")
                .OnDelete(DeleteBehavior.Restrict);


            //index 
            builder.HasIndex(func => func.Id)
                .HasDatabaseName("I_Funcionarios_Id");

            builder.HasIndex(func => func.NomeCompleto)
                .HasDatabaseName("I_Funcionarios_NomeCompleto");

            builder.HasIndex(func => func.GerenteId)
                .HasDatabaseName("I_Funcionarios_GerenteId");


            //campos
            builder.Property(func => func.Id)
                .HasColumnName("FuncionarioID")
                .IsRequired();
        }
    }
}
