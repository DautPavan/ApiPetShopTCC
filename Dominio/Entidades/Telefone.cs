using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Telefone
    {
        public int Id { get; set; }
        public int DDD { get; set; }
        public string Numero { get; set; }


        public ICollection<ContatoTelefone> ContatoTelefone { get; set; }
    }
}
