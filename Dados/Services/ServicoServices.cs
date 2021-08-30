using Dominio.Entidades;
using Dominio.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.Services
{
    public class ServicoServices : Repositorio<Servico>, IServicoServices
    {
        public ServicoServices(ApplicationDbContext context) : base(context)
        {
        }
    }
}
