using System;
using System.Collections.Generic;
using System.Text;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dados.MapEntidade
{
    public class RacaMap : IEntityTypeConfiguration<Raca>
    {
        public void Configure(EntityTypeBuilder<Raca> builder)
        {
            //Tabela
            builder.ToTable("Racas");

            //PK e FK
            builder.HasKey(raca => raca.Id)
                .HasName("PK_Racas");


            //Index
            builder.HasIndex(raca => raca.Id)
                .HasDatabaseName("I_Racas_Id");

            builder.HasIndex(raca => raca.Nome)
                .HasDatabaseName("I_Racas_Nome");

            //Campos
            builder.Property(raca => raca.Id)
                .HasColumnName("RacaID")
                .IsRequired();
        }
    }
}
