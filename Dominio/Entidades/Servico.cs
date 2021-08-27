using Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Servico
    {
        public int Id { get; set; }
        public string NomeServico { get; set; }
        public double Valor { get; set; }
        public string Descricao { get; set; }
        public Porte PorteAnimal { get; set; }

        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }

        public int RacaId { get; set; }
        public Raca Raca { get; set; }

        public ICollection<Agenda> Agenda { get; set; }
    }
}
