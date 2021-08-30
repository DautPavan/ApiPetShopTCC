using Dominio.Entidades;
using Dominio.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.Services
{
    public class AgendaServices : Repositorio<Agenda>, IAgendaServices
    {
        public AgendaServices(ApplicationDbContext context) : base(context)
        {
        }
    }
}
