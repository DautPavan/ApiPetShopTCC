﻿// <auto-generated />
using System;
using Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dados.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dominio.Entidades.Agenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AgendaID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.Property<int>("DonoId")
                        .HasColumnType("int");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("int");

                    b.Property<DateTime>("HoraAgendada")
                        .HasColumnType("datetime2");

                    b.Property<int>("ServicoId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_Agendas_ID");

                    b.HasIndex("AnimalId")
                        .HasDatabaseName("I_Agendas_AnimalId");

                    b.HasIndex("DonoId")
                        .HasDatabaseName("I_Agendas_DonoId");

                    b.HasIndex("EmpresaId")
                        .HasDatabaseName("I_Agendas_EmpresaId");

                    b.HasIndex("FuncionarioId");

                    b.HasIndex("Id")
                        .HasDatabaseName("I_Agendas_Id");

                    b.HasIndex("ServicoId")
                        .HasDatabaseName("I_Agendas_ServicoId");

                    b.ToTable("Agendas");
                });

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
                        .HasName("PK_Animal_ID");

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

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_Contatos");

                    b.HasIndex("DonoId")
                        .HasDatabaseName("I_Contatos_DonoPK");

                    b.HasIndex("EmpresaId");

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

            modelBuilder.Entity("Dominio.Entidades.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EmpresaID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CNPJ")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeEmpresa")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RazaoSocial")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_Empresas_Id");

                    b.HasIndex("CNPJ")
                        .HasDatabaseName("I_Empresas_CNPJ");

                    b.HasIndex("Id")
                        .HasDatabaseName("I_Empresas_Id");

                    b.HasIndex("NomeEmpresa")
                        .HasDatabaseName("I_Empresas_NomeEmpresa");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("Dominio.Entidades.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("FuncionarioID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<int?>("GerenteId")
                        .HasColumnType("int");

                    b.Property<string>("NomeCompleto")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_Funcionarios_ID");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("GerenteId")
                        .HasDatabaseName("I_Funcionarios_GerenteId");

                    b.HasIndex("Id")
                        .HasDatabaseName("I_Funcionarios_Id");

                    b.HasIndex("NomeCompleto")
                        .HasDatabaseName("I_Funcionarios_NomeCompleto");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("Dominio.Entidades.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProdutoID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("PrecoUnit")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(16, 2)
                        .HasColumnType("float(16)")
                        .HasDefaultValue(0.0);

                    b.Property<string>("Unidade")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_Produtos_Id");

                    b.HasIndex("EmpresaId")
                        .HasDatabaseName("I_Produtos_EmpresaId");

                    b.HasIndex("Id")
                        .HasDatabaseName("I_Produtos_Id");

                    b.HasIndex("Nome")
                        .HasDatabaseName("I_Produtos_Nome");

                    b.ToTable("Produtos");
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

            modelBuilder.Entity("Dominio.Entidades.Servico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ServicoID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("NomeServico")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PorteAnimal")
                        .HasColumnType("int");

                    b.Property<int>("RacaId")
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(16, 2)
                        .HasColumnType("float(16)")
                        .HasDefaultValue(0.0);

                    b.HasKey("Id")
                        .HasName("PK_Servicos_Id");

                    b.HasIndex("EmpresaId")
                        .HasDatabaseName("I_Servicos_EmpresaId");

                    b.HasIndex("Id")
                        .HasDatabaseName("I_Servicos_Id");

                    b.HasIndex("NomeServico")
                        .HasDatabaseName("I_Servicos_NomeServico");

                    b.HasIndex("RacaId");

                    b.ToTable("Servicos");
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

            modelBuilder.Entity("Dominio.Entidades.Agenda", b =>
                {
                    b.HasOne("Dominio.Entidades.Animal", "Animal")
                        .WithMany("Agenda")
                        .HasForeignKey("AnimalId")
                        .HasConstraintName("FK_Agendas_AnimalIDXAnimal_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Dominio.Entidades.Dono", "Dono")
                        .WithMany("Agenda")
                        .HasForeignKey("DonoId")
                        .HasConstraintName("FK_Agendas_DonoIDXDono_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Dominio.Entidades.Empresa", "Empresa")
                        .WithMany("Agenda")
                        .HasForeignKey("EmpresaId")
                        .HasConstraintName("FK_Agendas_EmpresaIDXEmpresa_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Dominio.Entidades.Funcionario", "Funcionario")
                        .WithMany("Agenda")
                        .HasForeignKey("FuncionarioId")
                        .HasConstraintName("FK_Agendas_FuncionarioIDXFuncionario_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Dominio.Entidades.Servico", "Servico")
                        .WithMany("Agenda")
                        .HasForeignKey("ServicoId")
                        .HasConstraintName("FK_Agendas_ServicoIDXServico_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Dono");

                    b.Navigation("Empresa");

                    b.Navigation("Funcionario");

                    b.Navigation("Servico");
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
                        .HasConstraintName("FK_Contatos_DonoIdXDono_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Dominio.Entidades.Empresa", "Empresa")
                        .WithMany("Contato")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dono");

                    b.Navigation("Empresa");
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

            modelBuilder.Entity("Dominio.Entidades.Funcionario", b =>
                {
                    b.HasOne("Dominio.Entidades.Empresa", "Empresa")
                        .WithMany("Funcionario")
                        .HasForeignKey("EmpresaId")
                        .HasConstraintName("FK_Funcionarios_EmpresaIDXEmpresa_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Dominio.Entidades.Funcionario", "Gerente")
                        .WithMany("Funcionarios")
                        .HasForeignKey("GerenteId")
                        .HasConstraintName("FK_Funcionarios_IDXFuncionarios_GerenteID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Empresa");

                    b.Navigation("Gerente");
                });

            modelBuilder.Entity("Dominio.Entidades.Produto", b =>
                {
                    b.HasOne("Dominio.Entidades.Empresa", "Empresa")
                        .WithMany("Produto")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("Dominio.Entidades.Servico", b =>
                {
                    b.HasOne("Dominio.Entidades.Empresa", "Empresa")
                        .WithMany("Servico")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Dominio.Entidades.Raca", "Raca")
                        .WithMany("Servico")
                        .HasForeignKey("RacaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");

                    b.Navigation("Raca");
                });

            modelBuilder.Entity("Dominio.Entidades.Animal", b =>
                {
                    b.Navigation("Agenda");

                    b.Navigation("DonoAnimais");
                });

            modelBuilder.Entity("Dominio.Entidades.Contato", b =>
                {
                    b.Navigation("ContatoTelefone");
                });

            modelBuilder.Entity("Dominio.Entidades.Dono", b =>
                {
                    b.Navigation("Agenda");

                    b.Navigation("Contato");

                    b.Navigation("DonoAnimais");
                });

            modelBuilder.Entity("Dominio.Entidades.Empresa", b =>
                {
                    b.Navigation("Agenda");

                    b.Navigation("Contato");

                    b.Navigation("Funcionario");

                    b.Navigation("Produto");

                    b.Navigation("Servico");
                });

            modelBuilder.Entity("Dominio.Entidades.Funcionario", b =>
                {
                    b.Navigation("Agenda");

                    b.Navigation("Funcionarios");
                });

            modelBuilder.Entity("Dominio.Entidades.Raca", b =>
                {
                    b.Navigation("Animais");

                    b.Navigation("Servico");
                });

            modelBuilder.Entity("Dominio.Entidades.Servico", b =>
                {
                    b.Navigation("Agenda");
                });

            modelBuilder.Entity("Dominio.Entidades.Telefone", b =>
                {
                    b.Navigation("ContatoTelefone");
                });
#pragma warning restore 612, 618
        }
    }
}
