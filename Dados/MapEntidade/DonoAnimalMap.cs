using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.MapEntidade
{
    public class DonoAnimalMap : IEntityTypeConfiguration<DonoAnimal>
    {
        public void Configure(EntityTypeBuilder<DonoAnimal> builder)
        {
            //Tabela
            builder.ToTable("DonosAnimais");


            //PK e FK
            builder.HasKey(donoAnimal => new { donoAnimal.AnimalId, donoAnimal.DonoId})
                .HasName("PK_DonosAnimais");

            builder.HasOne(donoAnimal => donoAnimal.Dono)
                .WithMany(dono => dono.DonoAnimais)
                .HasForeignKey(donoAnimal => donoAnimal.DonoId)
                .HasConstraintName("FK_DonoAnimal_DonoIdXDonos_ID")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(donoAnimal => donoAnimal.Animal)
                .WithMany(animal => animal.DonoAnimais)
                .HasForeignKey(donoAnimal => donoAnimal.AnimalId)
                .HasConstraintName("FK_DonoAnimal_AnimalIdXAnimais_ID")
                .OnDelete(DeleteBehavior.Restrict);


            //Index
            builder.HasIndex(donoAnimal => donoAnimal.AnimalId)
                .HasDatabaseName("I_DonosAnimais_IdAnimal");

            builder.HasIndex(donoAnimal => donoAnimal.DonoId)
                .HasDatabaseName("I_DonosAnimais_IdDono");


            //Campos            
            builder.Property(donoAnimal => donoAnimal.AnimalId)
                .IsRequired();

            builder.Property(donoAnimal => donoAnimal.DonoId)
                .IsRequired();

        }
    }
}
