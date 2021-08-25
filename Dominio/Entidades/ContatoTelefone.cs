using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class ContatoTelefone
    {
        public int Id { get; set; }
        
        public int TelefoneId { get; set; }
        public Telefone Telefone { get; set; }

        public int ContatoId { get; set; }
        public Contato Contato { get; set; }

    }
}
