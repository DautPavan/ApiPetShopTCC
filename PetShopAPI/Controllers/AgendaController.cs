using AutoMapper;
using Dados;
using Dados.Services;
using Dominio.Entidades;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PetShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : Controller
    {
        private ApplicationDbContext _contexto;
        protected readonly IMapper _mapper;

        public AgendaController(ApplicationDbContext contexto, IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;

        }

        [HttpPost]
        [Route("Create")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CreateAgenda([FromBody] Agenda body)
        {
            try
            {
                if (body == null)
                    return BadRequest(JsonConvert.SerializeObject(new { message = "A solicitação não contem corpo" }));


                AgendaServices agendaServices = new AgendaServices(_contexto);

                agendaServices.Adicionar(body);
                agendaServices.Commit();

                return Ok(JsonConvert.SerializeObject(new { message = "Horario cadastrado com sucesso!" }));

            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(new { menssage = "Ocorreu algum erro: " + ex.InnerException.Message }));
            }
        }

        [HttpGet]
        [Route("Buscar/{id:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> BuscarAgenda(int id)
        {
            try
            {
                AgendaServices agendaServices = new AgendaServices(_contexto);

                var servico = agendaServices.Get(agend => agend.Id == id).FirstOrDefault();

                return Ok(JsonConvert.SerializeObject(servico));

            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(new { menssage = "Ocorreu algum erro: " + ex.InnerException.Message }));
            }
        }

        [HttpGet]
        [Route("Lista/{id:int}/{data}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ListaAgenda(int id, DateTime data)
        {
            try
            {
                AgendaServices agendaServices = new AgendaServices(_contexto);

                List<Agenda> listAgenda = agendaServices.Get(agend =>
                                                                agend.EmpresaId == id &&
                                                                agend.HoraAgendada.Year == data.Year &&
                                                                agend.HoraAgendada.Month == data.Month &&
                                                                agend.HoraAgendada.Day == data.Day 
                                                            )
                                                            .Include(agend => agend.Animal)
                                                            .Include(agend => agend.Dono)
                                                            .Include(agend => agend.Funcionario)
                                                            .ToList();

                return Ok(JsonConvert.SerializeObject(listAgenda, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));

            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(new { menssage = "Ocorreu algum erro: " + ex.InnerException.Message }));
            }
        }

        [HttpPut]
        [Route("Alter")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> AlterAgenda([FromBody] Agenda body)
        {
            try
            {
                if (body == null)
                    return BadRequest(JsonConvert.SerializeObject(new { message = "A solicitação não contem corpo" }));

                if (String.IsNullOrEmpty(body.Id.ToString()) || body.Id == 0)
                    return BadRequest(JsonConvert.SerializeObject(new { message = "A solicitação precisa ter o Id do serviço ou ele tem que ser diferente de 0" }));


                AgendaServices agendaServices = new AgendaServices(_contexto);

                agendaServices.Atualizar(body);
                agendaServices.Commit();

                return Ok(JsonConvert.SerializeObject(new { message = "Serviço alterado com Sucesso!" }));

            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(new { menssage = "Ocorreu algum erro: " + ex.InnerException.Message }));
            }
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DeletarAgenda(int id)
        {
            try
            {
                AgendaServices agendaServices = new AgendaServices(_contexto);

                agendaServices.Deletar(serv => serv.Id == id);
                agendaServices.Commit();

                return Ok(JsonConvert.SerializeObject(new { message = "Horario deletado com Sucesso!" }));

            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(new { menssage = "Ocorreu algum erro: " + ex.InnerException.Message }));
            }
        }
    }
}
