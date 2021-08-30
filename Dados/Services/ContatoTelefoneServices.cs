using Dominio.Entidades;
using Dominio.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.Services
{
    public class ContatoTelefoneServices : Repositorio<ContatoTelefone>, IContatoTelefoneServices
    {
        public ContatoTelefoneServices(ApplicationDbContext context) : base(context)
        {
        }
    }
}
