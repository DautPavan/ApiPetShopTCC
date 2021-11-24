using Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopAPI.DTO
{
    public class GridDTO
    {
        public int Id { get; set; }
        public DateTime HoraAgendada  { get; set; }
        public string NomeServico { get; set; }
        public double Valor { get; set; }
        public string Descricao { get; set; }
        public string NomeDono { get; set; }
        public string Email { get; set; }
        public string NomeAnimal { get; set; }
        public Porte PorteAnimal { get; set; }
        public GeneroBiologico GeneroBiologico { get; set; }
        public string NomeRaca { get; set; }
        public StatusService Status { get; set; }

    }
}
