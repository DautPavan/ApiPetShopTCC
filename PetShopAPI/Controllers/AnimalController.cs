using AutoMapper;
using Dados;
using Dados.Services;
using Dominio.Entidades;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PetShopAPI.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PetShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : Controller
    {
        private ApplicationDbContext _contexto;
        protected readonly IMapper _mapper;

        public AnimalController(ApplicationDbContext contexto, IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;

        }

        [HttpPost]
        [Route("Create")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CreateAnimal([FromBody] CreateAnimal body)
        {
            try
            {
                if (body == null)
                      return BadRequest(JsonConvert.SerializeObject(new { message = "A solicitação não contem corpo" }));

                if (body.RacaId == null)
                    return BadRequest(JsonConvert.SerializeObject(new { message = "A solicitação não contem a Raça" }));

                var pessoa = _contexto.Dono.Where(dono => dono.AuthenticationId.ToString() == User.Identity.Name).FirstOrDefault();

                AnimalServices animalServices = new AnimalServices(_contexto);
                DonoAnimalServices donoAnimalServices = new DonoAnimalServices(_contexto);

                var animal = _mapper.Map<Animal>(body);
                var donoAnimal = _mapper.Map<DonoAnimal>(body);

                donoAnimal.DonoId = pessoa.Id;

                animalServices.Adicionar(animal);
                animalServices.Commit();


                donoAnimal.AnimalId = animal.Id;
                donoAnimalServices.Adicionar(donoAnimal);
                donoAnimalServices.Commit();

                return Ok(JsonConvert.SerializeObject(new { message = "Animal criada com Sucesso!" }));

            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(new { menssage = "Ocorreu algum erro: " + ex.InnerException.Message }));
            }
        }

        [HttpGet]
        [Route("Buscar")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> BuscarAnimal()
        {
            try
            {
                var pessoa = _contexto.Dono.Where(dono => dono.AuthenticationId.ToString() == User.Identity.Name).FirstOrDefault();

                var animalList = _contexto.DonoAnimal.Where(
                                                        DonoAnimal => DonoAnimal.DonoId == pessoa.Id
                                                    )
                                                    .Include(DonoAnimal => DonoAnimal.Animal)
                                                        .ThenInclude(animal => animal.Raca)
                                                    .Select((DonoAnimal) => new Animal
                                                    {
                                                        Id = DonoAnimal.Animal.Id,
                                                        Nome = DonoAnimal.Animal.Nome,
                                                        Idade = DonoAnimal.Animal.Idade,
                                                        Peso = DonoAnimal.Animal.Peso,
                                                        GeneroBiologico = DonoAnimal.Animal.GeneroBiologico,
                                                        PorteAnimal = DonoAnimal.Animal.PorteAnimal,
                                                        RacaId = DonoAnimal.Animal.RacaId,
                                                        Raca = DonoAnimal.Animal.Raca,
                                                    })
                                                    .ToList();



                return Ok(JsonConvert.SerializeObject(animalList));

            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(new { menssage = "Ocorreu algum erro: " + ex.InnerException.Message }));
            }
        }

        [HttpDelete]
        [Route("Deletar/{id:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Deletar(int id)
        {
            try
            {

                AgendaServices agendaServices = new AgendaServices(_contexto);
                DonoAnimalServices donoAnimalServices = new DonoAnimalServices(_contexto);
                AnimalServices animalServices = new AnimalServices(_contexto);

                agendaServices.Deletar(agend => agend.AnimalId == id);
                donoAnimalServices.Deletar(agend => agend.AnimalId == id);
                animalServices.Deletar(agend => agend.Id == id);

                agendaServices.Commit();
                donoAnimalServices.Commit();
                animalServices.Commit();

                return Ok(JsonConvert.SerializeObject(new { messagem =  "ok" }));

            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(new { menssage = "Ocorreu algum erro: " + ex.InnerException.Message }));
            }
        }
    }
}
