using AutoMapper;
using Dados;
using Dados.Services;
using Dominio.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : Controller
    {
        private ApplicationDbContext _contexto;
        protected readonly IMapper _mapper;

        public EmpresaController(ApplicationDbContext contexto, IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;

        }


        [HttpPost]
        [Route("Create")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateEmpresa([FromBody] Empresa body)
        {
            try
            {
                if (body == null)
                    return BadRequest(new { message = "A solicitação não contem corpo" });


                EmpresaServices empresaServices = new EmpresaServices(_contexto);
                empresaServices.Adicionar(body);
                empresaServices.Commit();

                return Ok("Empresa criada com Sucesso!");

            } catch (Exception ex) {
                return BadRequest("Ocorreu algum erro: " + ex.InnerException.Message);
            }
        }

    }
}
