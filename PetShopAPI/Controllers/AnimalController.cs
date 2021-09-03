using AutoMapper;
using Dados;
using Dados.Services;
using Dominio.Entidades;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

                if (body.DonoId == null)
                    return BadRequest(JsonConvert.SerializeObject(new { message = "A solicitação não contem o Dono" }));

                if (body.RacaId == null)
                    return BadRequest(JsonConvert.SerializeObject(new { message = "A solicitação não contem a Raça" }));



                AnimalServices animalServices = new AnimalServices(_contexto);
                DonoAnimalServices donoAnimalServices = new DonoAnimalServices(_contexto);

                var animal = _mapper.Map<Animal>(body);
                var donoAnimal = _mapper.Map<DonoAnimal>(body);

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
               

              

                return Ok(JsonConvert.SerializeObject(new { message = "Animal criada com Sucesso!" }));

            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(new { menssage = "Ocorreu algum erro: " + ex.InnerException.Message }));
            }
        }

    }
}
