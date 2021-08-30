using Dominio.Entidades;
using Dominio.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.Services
{
    public class TelefoneServices : Repositorio<Telefone>, ITelefoneServices
    {
        public TelefoneServices(ApplicationDbContext context) : base(context)
        {
        }
    }
}
