using Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopAPI.Entidades
{
    public class CreateAnimal
    {
        public int? AnimalId { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public double Peso { get; set; }
        public GeneroBiologico GeneroBiologico { get; set; }
        public Porte PorteAnimal { get; set; }
        public int? RacaId { get; set; }
        public int? DonoId { get; set; }
    }
}
