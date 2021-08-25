using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.MapEntidade
{
    public class DonoMap : IEntityTypeConfiguration<Dono>
    {
        public void Configure(EntityTypeBuilder<Dono> builder)
        {
            //Tabela
            builder.ToTable("Donos");


            //PK e FK
            builder.HasKey(dono => dono.Id)
                .HasName("PK_Donos");


            //Index
            builder.HasIndex(dono => dono.Id)
                .HasDatabaseName("I_Donos_Id");

            builder.HasIndex(dono => dono.Nome)
                .HasDatabaseName("I_Donos_Nome");


            //Campos
            builder.Property(dono => dono.Id)
                .HasColumnName("DonoID")
                .IsRequired();
        }
    }
}
