using Dominio.Entidades;
using Dominio.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.Services
{
    public class EmpresaServices : Repositorio<Empresa>, IEmpresaServices
    {
        public EmpresaServices(ApplicationDbContext context) : base(context)
        {
        }
    }
}
