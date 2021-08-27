using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Empresa
    {
        public int Id { get; set; }
        public string CNPJ { get; set; }
        public string NomeEmpresa { get; set; }
        public string RazaoSocial { get; set; }
        public string Email { get; set; }


        public ICollection<Contato> Contato { get; set; }
        public ICollection<Servico> Servico { get; set; }
        public ICollection<Produto> Produto { get; set; }
        public ICollection<Funcionario> Funcionario { get; set; }
        public ICollection<Agenda> Agenda { get; set; }

    }
}
