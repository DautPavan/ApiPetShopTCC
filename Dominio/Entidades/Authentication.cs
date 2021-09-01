using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Authentication
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }


        public ICollection<Funcionario> Funcionario { get; set; }
        public ICollection<Dono> Dono { get; set; }
    }
}
