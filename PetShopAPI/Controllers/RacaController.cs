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
    public class RacaController : Controller
    {
        private ApplicationDbContext _contexto;
        protected readonly IMapper _mapper;

        public RacaController(ApplicationDbContext contexto, IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;

        }


        [HttpGet]
        [Route("Buscar")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> BuscarRaca()
        {
            try
            {
                RacaServices racaServices = new RacaServices(_contexto);

                var servico = racaServices.GetTodos();

                return Ok(JsonConvert.SerializeObject(servico));
            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(new { menssage = "Ocorreu algum erro: " + ex.InnerException.Message }));
            }
        }

        [HttpPost]
        [Route("Create")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CreateRaca([FromBody]Raca body)
        {
            try
            {
                if(body == null)
                    return BadRequest(JsonConvert.SerializeObject(new { messagem = "A solicitação não contem corpo" }));

                RacaServices racaServices = new RacaServices(_contexto);

                racaServices.Adicionar(body);
                racaServices.Commit();

                return Ok(JsonConvert.SerializeObject(new { messagem = "Raça criado com Sucesso!" }));
            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(new { messagem = "Ocorreu algum erro: " + ex.InnerException.Message }));
            }
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeletarRaca(int id)
        {
            try
            {
                AnimalServices animalServices = new AnimalServices(_contexto);
                RacaServices racaServices = new RacaServices(_contexto);

                var AnimalPossuiRaca = animalServices.Get(el => el.RacaId == id).ToList();
                if (AnimalPossuiRaca.Count > 0)
                    return BadRequest(JsonConvert.SerializeObject(new { messagem = "Existe animais com essa Raça cadastrados." }));
                    

                racaServices.Deletar(serv => serv.Id == id);
                racaServices.Commit();

                return Ok(JsonConvert.SerializeObject(new { messagem = "Raça deletado com Sucesso!" }));

            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(new { messagem = "Ocorreu algum erro: " + ex.InnerException.Message }));
            }
        }
    }
}
