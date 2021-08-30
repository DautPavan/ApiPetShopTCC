using Dominio.Entidades;
using Dominio.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.Services
{
    public class ProdutoServices : Repositorio<Produto>, IProdutoServices
    {
        public ProdutoServices(ApplicationDbContext context) : base(context)
        {
        }
    }
}
