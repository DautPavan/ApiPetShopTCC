using Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Raca
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Porte PorteRaca { get; set; }


        public ICollection<Animal> Animais { get; set; }
    }
}
