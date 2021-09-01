using Dominio.Entidades;
using Dominio.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.Services
{
    public class AuthenticationServices : Repositorio<Authentication>, IAuthenticationServices
    {
        public AuthenticationServices(ApplicationDbContext context) : base(context)
        {
        }
    }
}
