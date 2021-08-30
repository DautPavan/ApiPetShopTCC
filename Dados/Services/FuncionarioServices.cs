using Dominio.Entidades;
using Dominio.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.Services
{
    public class FuncionarioServices : Repositorio<Funcionario>, IFuncionarioServices
    {
        public FuncionarioServices(ApplicationDbContext context) : base(context)
        {
        }
    }
}
