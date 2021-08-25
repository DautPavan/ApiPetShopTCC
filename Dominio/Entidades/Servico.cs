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

        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
    }
}
