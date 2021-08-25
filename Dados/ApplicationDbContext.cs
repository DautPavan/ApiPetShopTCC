using Dados.MapEntidade;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dados
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Animal> Animal { get; set; }
        public DbSet<Contato> Contato { get; set; }
        public DbSet<ContatoTelefone> ContatoTelefone { get; set; }
        public DbSet<Dono> Dono { get; set; }
        public DbSet<DonoAnimal> DonoAnimal { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Raca> Raca { get; set; }
        public DbSet<Servico> Servico { get; set; }
        public DbSet<Telefone> Telefone { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnimalMap());
            modelBuilder.ApplyConfiguration(new ContatoMap());
            modelBuilder.ApplyConfiguration(new ContatoTelefoneMap());
            modelBuilder.ApplyConfiguration(new DonoMap());
            modelBuilder.ApplyConfiguration(new DonoAnimalMap());
            modelBuilder.ApplyConfiguration(new EmpresaMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new RacaMap());
            modelBuilder.ApplyConfiguration(new ServicoMap());
            modelBuilder.ApplyConfiguration(new TelefoneMap());
        }
    }
}
