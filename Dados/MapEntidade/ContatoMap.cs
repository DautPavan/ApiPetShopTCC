using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.MapEntidade
{
    public class ContatoMap : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            //Tabela
            builder.ToTable("Contatos");


            //PK e FK
            builder.HasKey(contato => contato.Id)
                .HasName("PK_Contatos");

            builder.HasOne(contato => contato.Dono)
                .WithMany(dono => dono.Contato)
                .HasForeignKey(contato => contato.DonoId)
                .HasConstraintName("FK_Contato_DonoIdXDono_ID")
                .OnDelete(DeleteBehavior.Restrict);


            //Index
            builder.HasIndex(contato => contato.Id)
                .HasDatabaseName("I_Contatos_Id");

            builder.HasIndex(contato => contato.DonoId)
                .HasDatabaseName("I_Contatos_DonoPK");


            //Campos
            builder.Property(contato => contato.Id)
                .HasColumnName("ContatoID")
                .IsRequired();

            builder.Property(contato => contato.DonoId)
                .IsRequired();
        }
    }
}
