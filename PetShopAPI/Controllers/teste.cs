using Dados;
using Dados.Services;
using Dominio.Entidades;
using Dominio.Enum;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class teste : Controller
    {

        private ApplicationDbContext _contexto;

        public teste(ApplicationDbContext contexto)
        {
            _contexto = contexto;

        }

        [HttpGet]
        public async Task<IActionResult> Teste()
        {
            RacaServices services = new RacaServices(_contexto);

            Raca a = new Raca();
            a.Id = 2;
            a.Nome = "cachorro2";
            a.PorteRaca = Porte.Medio;

            services.Atualizar(a);
            services.Commit();

            return Ok("OK");
        }
    }
}
