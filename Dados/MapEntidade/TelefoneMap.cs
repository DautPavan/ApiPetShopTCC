using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.MapEntidade
{
    public class TelefoneMap : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            //Tabela
            builder.ToTable("Telefones");


            //PK e FK
            builder.HasKey(telefone => telefone.Id)
                .HasName("PK_telefones");


            //Index
            builder.HasIndex(telefone => telefone.Id)
                .HasDatabaseName("I_telefones_Id");

            builder.HasIndex(telefone => telefone.Numero)
                .HasDatabaseName("I_telefones_Numero");


            //Campos
            builder.Property(telefone => telefone.Id)
                .HasColumnName("telefoneID")
                .IsRequired();
        }
    }
}
