using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Email { get; set; }
        public int? GerenteId { get; set; }
        public Funcionario Gerente { get; set; }
        public ICollection<Funcionario> Funcionarios { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public int? AuthenticationId { get; set; }
        public Authentication Authentication { get; set; }

        public ICollection<Agenda> Agenda { get; set; }

    }
}
