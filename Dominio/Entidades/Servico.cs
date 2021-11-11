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

        public ICollection<Agenda> Agenda { get; set; }
    }
}
