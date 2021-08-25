using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.MapEntidade
{
    public class ContatoTelefoneMap : IEntityTypeConfiguration<ContatoTelefone>
    {
        public void Configure(EntityTypeBuilder<ContatoTelefone> builder)
        {
            //Table
            builder.ToTable("ContatosTelefones");


            //PK e FK
            builder.HasKey(contatoTelefone => contatoTelefone.Id)
                .HasName("PK_ContatosTelefonesID");

            builder.HasOne(contatoTelefone => contatoTelefone.Telefone)
                .WithMany(telefone => telefone.ContatoTelefone)
                .HasForeignKey(contatoTelefone => contatoTelefone.TelefoneId)
                .HasConstraintName("FK_ContatosTelefones_IDXTelefone_Id")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(contatoTelefone => contatoTelefone.Contato)
                .WithMany(contato => contato.ContatoTelefone)
                .HasForeignKey(contatoTelefone => contatoTelefone.ContatoId)
                .HasConstraintName("FK_ContatosTelefones_ContatoIDXTelefone_Id")
                .OnDelete(DeleteBehavior.Restrict);

            //index 
            builder.HasIndex(contatoTelefone => contatoTelefone.Id)
                .HasDatabaseName("I_ContatosTelefones_Id");

            builder.HasIndex(contatoTelefone => contatoTelefone.TelefoneId)
                .HasDatabaseName("I_ContatosTelefones_TelefoneId");


            //campos
            builder.Property(contatoTelefone => contatoTelefone.Id)
                .HasColumnName("ContatoTelefoneID")
                .IsRequired();
            
            builder.Property(contatoTelefone => contatoTelefone.TelefoneId)
                .IsRequired();

            builder.Property(contatoTelefone => contatoTelefone.ContatoId)
                .IsRequired();
        }
    }
}
