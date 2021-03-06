// <auto-generated />
using System;
using Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dados.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210825144513_versao1")]
    partial class versao1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dominio.Entidades.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AnimalID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GeneroBiologico")
                        .HasColumnType("int");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Peso")
                        .HasColumnType("float");

                    b.Property<int>("PorteAnimal")
                        .HasColumnType("int");

                    b.Property<int>("RacaId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("ID");

                    b.HasIndex("Id")
                        .HasDatabaseName("I_Animais_Id");

                    b.HasIndex("Nome")
                        .HasDatabaseName("I_Animais_Nome");

                    b.HasIndex("RacaId")
                        .HasDatabaseName("I_Animais_RacaId");

                    b.ToTable("Animais");
                });

            modelBuilder.Entity("Dominio.Entidades.Contato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ContatoID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DonoId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_Contatos");

                    b.HasIndex("DonoId")
                        .HasDatabaseName("I_Contatos_DonoPK");

                    b.HasIndex("Id")
                        .HasDatabaseName("I_Contatos_Id");

                    b.ToTable("Contatos");
                });

            modelBuilder.Entity("Dominio.Entidades.ContatoTelefone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ContatoTelefoneID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContatoId")
                        .HasColumnType("int");

                    b.Property<int>("TelefoneId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_ContatosTelefonesID");

                    b.HasIndex("ContatoId");

                    b.HasIndex("Id")
                        .HasDatabaseName("I_ContatosTelefones_Id");

                    b.HasIndex("TelefoneId")
                        .HasDatabaseName("I_ContatosTelefones_TelefoneId");

                    b.ToTable("ContatosTelefones");
                });

            modelBuilder.Entity("Dominio.Entidades.Dono", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("DonoID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_Donos");

                    b.HasIndex("Id")
                        .HasDatabaseName("I_Donos_Id");

                    b.HasIndex("Nome")
                        .HasDatabaseName("I_Donos_Nome");

                    b.ToTable("Donos");
                });

            modelBuilder.Entity("Dominio.Entidades.DonoAnimal", b =>
                {
                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.Property<int>("DonoId")
                        .HasColumnType("int");

                    b.HasKey("AnimalId", "DonoId")
                        .HasName("PK_DonosAnimais");

                    b.HasIndex("AnimalId")
                        .HasDatabaseName("I_DonosAnimais_IdAnimal");

                    b.HasIndex("DonoId")
                        .HasDatabaseName("I_DonosAnimais_IdDono");

                    b.ToTable("DonosAnimais");
                });

            modelBuilder.Entity("Dominio.Entidades.Raca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RacaID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PorteRaca")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_Racas");

                    b.HasIndex("Id")
                        .HasDatabaseName("I_Racas_Id");

                    b.HasIndex("Nome")
                        .HasDatabaseName("I_Racas_Nome");

                    b.ToTable("Racas");
                });

            modelBuilder.Entity("Dominio.Entidades.Telefone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("telefoneID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DDD")
                        .HasColumnType("int");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id")
                        .HasName("PK_telefones");

                    b.HasIndex("Id")
                        .HasDatabaseName("I_telefones_Id");

                    b.HasIndex("Numero")
                        .HasDatabaseName("I_telefones_Numero");

                    b.ToTable("Telefones");
                });

            modelBuilder.Entity("Dominio.Entidades.Animal", b =>
                {
                    b.HasOne("Dominio.Entidades.Raca", "Raca")
                        .WithMany("Animais")
                        .HasForeignKey("RacaId")
                        .HasConstraintName("FK_Animal_RacaIdXRaca_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Raca");
                });

            modelBuilder.Entity("Dominio.Entidades.Contato", b =>
                {
                    b.HasOne("Dominio.Entidades.Dono", "Dono")
                        .WithMany("Contato")
                        .HasForeignKey("DonoId")
                        .HasConstraintName("FK_Contato_DonoIdXDono_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Dono");
                });

            modelBuilder.Entity("Dominio.Entidades.ContatoTelefone", b =>
                {
                    b.HasOne("Dominio.Entidades.Contato", "Contato")
                        .WithMany("ContatoTelefone")
                        .HasForeignKey("ContatoId")
                        .HasConstraintName("FK_ContatosTelefones_ContatoIDXTelefone_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Dominio.Entidades.Telefone", "Telefone")
                        .WithMany("ContatoTelefone")
                        .HasForeignKey("TelefoneId")
                        .HasConstraintName("FK_ContatosTelefones_IDXTelefone_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Contato");

                    b.Navigation("Telefone");
                });

            modelBuilder.Entity("Dominio.Entidades.DonoAnimal", b =>
                {
                    b.HasOne("Dominio.Entidades.Animal", "Animal")
                        .WithMany("DonoAnimais")
                        .HasForeignKey("AnimalId")
                        .HasConstraintName("FK_DonoAnimal_AnimalIdXAnimais_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Dominio.Entidades.Dono", "Dono")
                        .WithMany("DonoAnimais")
                        .HasForeignKey("DonoId")
                        .HasConstraintName("FK_DonoAnimal_DonoIdXDonos_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Dono");
                });

            modelBuilder.Entity("Dominio.Entidades.Animal", b =>
                {
                    b.Navigation("DonoAnimais");
                });

            modelBuilder.Entity("Dominio.Entidades.Contato", b =>
                {
                    b.Navigation("ContatoTelefone");
                });

            modelBuilder.Entity("Dominio.Entidades.Dono", b =>
                {
                    b.Navigation("Contato");

                    b.Navigation("DonoAnimais");
                });

            modelBuilder.Entity("Dominio.Entidades.Raca", b =>
                {
                    b.Navigation("Animais");
                });

            modelBuilder.Entity("Dominio.Entidades.Telefone", b =>
                {
                    b.Navigation("ContatoTelefone");
                });
#pragma warning restore 612, 618
        }
    }
}
