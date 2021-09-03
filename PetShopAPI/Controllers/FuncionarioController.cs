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
    public class FuncionarioController : Controller
    {
        private ApplicationDbContext _contexto;
        protected readonly IMapper _mapper;

        public FuncionarioController(ApplicationDbContext contexto, IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;

        }

        [HttpGet("{id}")]
        [Route("Buscar/{funcionarioId:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> BuscarFuncionario(int funcionarioId)
        {
            try
            {
                FuncionarioServices funcionarioServices = new FuncionarioServices(_contexto);

                var listFunc = funcionarioServices.Get(
                                                        func => func.Id == funcionarioId)
                                                    .Select((func) => new Funcionario
                                                    {
                                                        Id = func.Id,
                                                        NomeCompleto = func.NomeCompleto,
                                                        DataNascimento = func.DataNascimento,
                                                        Sexo = func.Sexo,
                                                        CPF = func.CPF,
                                                        RG = func.RG,
                                                        Email = func.Email,
                                                        GerenteId = func.GerenteId,
                                                        EmpresaId = func.EmpresaId,
                                                        AuthenticationId = func.AuthenticationId
                                                    })
                                                    .FirstOrDefault();

                return Ok(JsonConvert.SerializeObject(listFunc));

            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(new { menssage = "Ocorreu algum erro: " + ex.InnerException.Message }));
            }
        }


        [HttpGet]
        [Route("ListaFuncionario/{empresaId:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult ListaFuncionario(int empresaId)
        {
            try
            {
                FuncionarioServices funcionarioServices = new FuncionarioServices(_contexto);

                List<Funcionario> listFunc = funcionarioServices.Get(
                                                                    func => func.EmpresaId == empresaId)
                                                                .Select((func) => new Funcionario {
                                                                    Id = func.Id,
                                                                    NomeCompleto = func.NomeCompleto,
                                                                    DataNascimento = func.DataNascimento,
                                                                    Sexo = func.Sexo,
                                                                    CPF = func.CPF,
                                                                    RG = func.RG,
                                                                    Email = func.Email,
                                                                    GerenteId = func.GerenteId,
                                                                    EmpresaId = func.EmpresaId,
                                                                    AuthenticationId = func.AuthenticationId
                                                                })
                                                                .ToList();

                return Ok(JsonConvert.SerializeObject(listFunc));

            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(new { menssage = "Ocorreu algum erro: " + ex.InnerException.Message }));
            }
        }
    }
}
