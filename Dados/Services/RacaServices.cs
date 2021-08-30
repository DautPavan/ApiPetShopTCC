using Dominio.Entidades;
using Dominio.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.Services
{
    public class RacaServices : Repositorio<Raca>, IRacaServices
    {
        public RacaServices(ApplicationDbContext context) : base(context)
        {
        }
    }
}
