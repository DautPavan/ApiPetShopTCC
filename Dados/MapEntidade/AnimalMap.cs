using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.MapEntidade
{
    class AnimalMap : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            //Table
            builder.ToTable("Animais");


            //PK e FK
            builder.HasKey(animal => animal.Id)
                .HasName("PK_Animal_ID");

            builder.HasOne(animal => animal.Raca)
                .WithMany(raca => raca.Animais)
                .HasForeignKey(animal => animal.RacaId)
                .HasConstraintName("FK_Animal_RacaIdXRaca_Id")
                .OnDelete(DeleteBehavior.Restrict);


            //index 
            builder.HasIndex(animal => animal.Id)
                .HasDatabaseName("I_Animais_Id");

            builder.HasIndex(animal => animal.Nome)
                .HasDatabaseName("I_Animais_Nome");

            builder.HasIndex(animal => animal.RacaId)
                .HasDatabaseName("I_Animais_RacaId");


            //campos
            builder.Property(animal => animal.Id)
                .HasColumnName("AnimalID")
                .IsRequired();

            builder.Property(animal => animal.Nome)
                .IsRequired();

            builder.Property(animal => animal.Idade)
                .IsRequired();

            builder.Property(animal => animal.PorteAnimal)
                .IsRequired();

            builder.Property(animal => animal.GeneroBiologico)
                .IsRequired();
        }
    }
}
