using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double PrecoUnit { get; set; }
        public string Unidade { get; set; }

        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
    }
}
