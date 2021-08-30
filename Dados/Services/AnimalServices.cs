using Dominio.Entidades;
using Dominio.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.Services
{
    public class AnimalServices : Repositorio<Animal>, IAnimalServices
    {
        public AnimalServices(ApplicationDbContext context) : base(context)
        {
        }
    }
}
