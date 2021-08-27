using Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Animal
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public double Peso { get; set; }
        public GeneroBiologico GeneroBiologico { get; set; }
        public Porte PorteAnimal { get; set; }
        public int RacaId { get; set; }
        public Raca Raca { get; set; }


        public ICollection<DonoAnimal> DonoAnimais { get; set; }
        public ICollection<Agenda> Agenda { get; set; }
    }
}
