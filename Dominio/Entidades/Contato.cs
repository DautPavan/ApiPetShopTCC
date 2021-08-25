using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Contato
    {
        public int Id { get; set; }
        

        public int DonoId { get; set; }
        public Dono Dono { get; set; }

        public ICollection<ContatoTelefone> ContatoTelefone { get; set; }
    }
}
