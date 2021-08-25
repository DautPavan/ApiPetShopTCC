using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class DonoAnimal
    {
        public int DonoId { get; set; }
        public int AnimalId { get; set; }
        
        public Dono Dono { get; set; }
        public Animal Animal { get; set; }

    }
}
