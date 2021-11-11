using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.MapEntidade
{
    public class AgendaMap : IEntityTypeConfiguration<Agenda>
    {
        public void Configure(EntityTypeBuilder<Agenda> builder)
        {
            //Table
            builder.ToTable("Agendas");

            //PK e FK
            builder.HasKey(agen => agen.Id)
                .HasName("PK_Agendas_ID");

            builder.HasOne(agen => agen.Dono)
                .WithMany(dono => dono.Agenda)
                .HasForeignKey(dono => dono.DonoId)
                .HasConstraintName("FK_Agendas_DonoIDXDono_Id")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(agen => agen.Animal)
                .WithMany(animal => animal.Agenda)
                .HasForeignKey(agen => agen.AnimalId)
                .HasConstraintName("FK_Agendas_AnimalIDXAnimal_Id")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(agen => agen.Servico)
                .WithMany(serv => serv.Agenda)
                .HasForeignKey(agen => agen.ServicoId)
                .HasConstraintName("FK_Agendas_ServicoIDXServico_Id")
                .OnDelete(DeleteBehavior.Restrict);


            //index 
            builder.HasIndex(agen => agen.Id)
                .HasDatabaseName("I_Agendas_Id");

            builder.HasIndex(agen => agen.DonoId)
                .HasDatabaseName("I_Agendas_DonoId");
            
            builder.HasIndex(agen => agen.ServicoId)
                .HasDatabaseName("I_Agendas_ServicoId");

            builder.HasIndex(agen => agen.AnimalId)
                .HasDatabaseName("I_Agendas_AnimalId");

            //campos
            builder.Property(agen => agen.Id)
                .HasColumnName("AgendaID")
                .IsRequired();

        }
    }
}
