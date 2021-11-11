using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Agenda
    {
        public int Id { get; set; }
        public DateTime HoraAgendada { get; set; }
        public int? ServicoId { get; set; }
        public Servico Servico { get; set; }
        public int? DonoId { get; set; }
        public Dono Dono { get; set; }
        public int? AnimalId { get; set; }
        public Animal Animal { get; set; }

    }
}
