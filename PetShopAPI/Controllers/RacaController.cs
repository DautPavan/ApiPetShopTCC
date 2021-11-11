using AutoMapper;
using Dados;
using Dados.Services;
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
    }
}
