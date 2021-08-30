using Dominio.Entidades;
using Dominio.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.Services
{
    public class DonoAnimalServices : Repositorio<DonoAnimal>, IDonoAnimalServices
    {
        public DonoAnimalServices(ApplicationDbContext context) : base(context)
        {
        }
    }
}
