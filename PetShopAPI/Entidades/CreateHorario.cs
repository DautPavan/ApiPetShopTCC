using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopAPI.Entidades
{
    public class CreateHorario
    {
        public int AnimalId { get; set; }
        public DateTime HoraAgendada { get; set; }
        public int ServicoId { get; set; }
    }
}
