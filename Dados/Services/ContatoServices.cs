using Dominio.Entidades;
using Dominio.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.Services
{
    public class ContatoServices : Repositorio<Contato>, IContatoServices
    {
        public ContatoServices(ApplicationDbContext context) : base(context)
        {
        }
    }
}
