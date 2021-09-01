using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.MapEntidade
{
    public class AuthenticationMap : IEntityTypeConfiguration<Authentication>
    {
        public void Configure(EntityTypeBuilder<Authentication> builder)
        {
            //Table
            builder.ToTable("Authentication");


            //PK e FK
            builder.HasKey(aut => aut.Id)
                .HasName("PK_Authentication_ID");

            //index 
            builder.HasIndex(aut => aut.Id)
                .HasDatabaseName("I_Authentication_Id");

            //campos
            builder.Property(aut => aut.Id)
                .HasColumnName("AuthenticationID")
                .IsRequired();

        }
    }
}
