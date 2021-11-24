using AutoMapper;
using Dados;
using Dados.Services;
using Dominio.Entidades;
using Dominio.Enum;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PetShopAPI.DTO;
using PetShopAPI.Entidades;
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
        public async Task<IActionResult> CreateAgenda([FromBody]CreateHorario body)
        {
            try
            {
                if (body == null)
                    return BadRequest(JsonConvert.SerializeObject(new { message = "A solicitação não contem corpo" }));

                var pessoa = _contexto.Dono.Where(dono => dono.AuthenticationId.ToString() == User.Identity.Name).FirstOrDefault();

                AgendaServices agendaServices = new AgendaServices(_contexto);
                Agenda agenda = new Agenda();
                agenda.HoraAgendada = body.HoraAgendada;
                agenda.ServicoId = body.ServicoId;
                agenda.AnimalId = body.AnimalId;
                agenda.DonoId = pessoa.Id;

                agendaServices.Adicionar(agenda);
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
                                                                agend.HoraAgendada.Year == data.Year &&
                                                                agend.HoraAgendada.Month == data.Month &&
                                                                agend.HoraAgendada.Day == data.Day 
                                                            )
                                                            .Include(agend => agend.Animal)
                                                            .Include(agend => agend.Dono)
                                                            .OrderBy(agend => agend.HoraAgendada)
                                                            .ThenBy(agend => agend.Animal.Nome)
                                                            .ToList();

                return Ok(JsonConvert.SerializeObject(listAgenda, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));

            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(new { menssage = "Ocorreu algum erro: " + ex.InnerException.Message }));
            }
        }

        [HttpGet]
        [Route("ListaMobiPessoa")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ListaMobiPessoa()
        {
            try
            {
                var pessoa = _contexto.Dono.Where(dono => dono.AuthenticationId.ToString() == User.Identity.Name).FirstOrDefault();

                AgendaServices agendaServices = new AgendaServices(_contexto);

                List<Agenda> listAgenda = agendaServices.Get(agend => agend.DonoId == pessoa.Id &&
                                                             agend.HoraAgendada.Date >= DateTime.Now.Date)
                                                            .Include(agend => agend.Animal)
                                                            .Include(agend => agend.Dono)
                                                            .Include(agend => agend.Servico)
                                                            .OrderBy(agend => agend.HoraAgendada)
                                                            .ThenBy(agend => agend.Animal.Nome)
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
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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

        [HttpGet]
        [Route("Iniciar/{id:int}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> IniciarAgenda(int id)
        {
            try
            {
                AgendaServices agendaServices = new AgendaServices(_contexto);

                var agend = agendaServices.Get(serv => serv.Id == id).FirstOrDefault();
                agend.Status = StatusService.Iniciado;

                agendaServices.Atualizar(agend);
                agendaServices.Commit();

                return Ok(JsonConvert.SerializeObject(new { message = "Horario Iniciado com Sucesso." }));

            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(new { menssage = "Ocorreu algum erro: " + ex.InnerException.Message }));
            }
        }

        [HttpGet]
        [Route("Finalizar/{id:int}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> FinalizarAgenda(int id)
        {
            try
            {
                AgendaServices agendaServices = new AgendaServices(_contexto);

                var agend = agendaServices.Get(serv => serv.Id == id).FirstOrDefault();
                agend.Status = StatusService.Finalizado;

                agendaServices.Atualizar(agend);
                agendaServices.Commit();

                return Ok(JsonConvert.SerializeObject(new { message = "Horario finalizado com Sucesso!" }));

            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(new { menssage = "Ocorreu algum erro: " + ex.InnerException.Message }));
            }
        }

        [HttpGet]
        [Route("MontarGrid")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> MontarGrid([FromQuery]DateTime Data)
        {
            try
            {
                AgendaServices agendaServices = new AgendaServices(_contexto);

                List<GridDTO> listAgenda = agendaServices.Get(agend =>
                                                                agend.HoraAgendada.Year == Data.Year &&
                                                                agend.HoraAgendada.Month == Data.Month &&
                                                                agend.HoraAgendada.Day == Data.Day
                                                            )
                                                            .Include(agend => agend.Animal)
                                                            .Include(agend => agend.Dono)
                                                            .Include(agend => agend.Servico)
                                                            .Include(agend => agend.Animal.Raca)
                                                            .Select(agend => new GridDTO {
                                                                Id = agend.Id,
                                                                HoraAgendada = agend.HoraAgendada,
                                                                NomeServico = agend.Servico.NomeServico,
                                                                Valor = agend.Servico.Valor,
                                                                Descricao = agend.Servico.Descricao,
                                                                NomeDono = agend.Dono.Nome,
                                                                Email = agend.Dono.Email,
                                                                NomeAnimal = agend.Animal.Nome,
                                                                PorteAnimal = agend.Animal.PorteAnimal,
                                                                GeneroBiologico = agend.Animal.GeneroBiologico,
                                                                NomeRaca = agend.Animal.Raca.Nome,
                                                                Status = agend.Status
                                                            })
                                                            .OrderBy(agend => agend.HoraAgendada)
                                                            .ThenBy(agend => agend.NomeServico)
                                                            .ThenBy(agend => agend.NomeDono)
                                                            .ThenBy(agend => agend.NomeAnimal)
                                                            .ToList();

                return Ok(JsonConvert.SerializeObject(listAgenda, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));

            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(new { menssage = "Ocorreu algum erro: " + ex.InnerException.Message }));
            }
        }
    }
}
