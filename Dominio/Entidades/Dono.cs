using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Dono
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        //public string CPF { get; set; }
        //public string RG { get; set; }
        public string Email { get; set; }
        public int? AuthenticationId { get; set; }
        public Authentication Authentication { get; set; }


        public ICollection<Contato> Contato { get; set; }
        public ICollection<DonoAnimal> DonoAnimais { get; set; }
        public ICollection<Agenda> Agenda { get; set; }

    }
}
