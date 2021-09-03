using AutoMapper;
using Dados;
using Dados.Services;
using Dominio.Entidades;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : Controller
    {
        private ApplicationDbContext _contexto;
        protected readonly IMapper _mapper;

        public ServicoController(ApplicationDbContext contexto, IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("Create")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CreateService([FromBody] Servico body)
        {
            try
            {
                if (body == null)
                    return BadRequest(JsonConvert.SerializeObject(new { message = "A solicitação não contem corpo" }));


                ServicoServices servicoServices = new ServicoServices(_contexto);

                servicoServices.Adicionar(body);
                servicoServices.Commit();

                return Ok(JsonConvert.SerializeObject(new { message = "Serviço criado com Sucesso!" }));

            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(new { menssage = "Ocorreu algum erro: " + ex.InnerException.Message }));
            }
        }

        [HttpGet]
        [Route("Buscar/{id:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> BuscarServico(int id)
        {
            try
            {
                ServicoServices servicoServices = new ServicoServices(_contexto);

                var servico = servicoServices.Get(serv => serv.Id == id).FirstOrDefault();

                return Ok(JsonConvert.SerializeObject(servico));

            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(new { menssage = "Ocorreu algum erro: " + ex.InnerException.Message }));
            }
        }

        [HttpGet]
        [Route("ListaServicos/{id:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ListaFuncionario(int id)
        {
            try
            {
                ServicoServices servicoServices = new ServicoServices(_contexto);

                List<Servico> listServico = servicoServices.Get(serv => serv.EmpresaId == id).ToList();

                return Ok(JsonConvert.SerializeObject(listServico));

            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(new { menssage = "Ocorreu algum erro: " + ex.InnerException.Message }));
            }
        }

    }
}
