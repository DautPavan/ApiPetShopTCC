using Dominio.Entidades;
using Dominio.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.Services
{
    public class DonoServices : Repositorio<Dono>, IDonoServices
    {
        public DonoServices(ApplicationDbContext context) : base(context)
        {
        }
    }
}
