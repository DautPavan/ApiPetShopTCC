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

        [HttpPut]
        [Route("Alter")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> AlterFuncionario(CreateFuncionario body)
        {
            try
            {
                if (body == null)
                    return BadRequest(JsonConvert.SerializeObject(new { message = "A solicitação não contem corpo" }));

                if (String.IsNullOrEmpty(body.FuncionarioId.ToString()) || body.FuncionarioId == 0)
                    return BadRequest(JsonConvert.SerializeObject(new { message = "A solicitação precisa ter o Id do serviço ou ele tem que ser diferente de 0" }));

                var funcionario = _mapper.Map<Funcionario>(body);

                AuthenticationServices authenticationServices = new AuthenticationServices(_contexto);
                FuncionarioServices funcionarioServices = new FuncionarioServices(_contexto);

                int AuthenticationId = funcionarioServices.Get(func => func.Id == body.FuncionarioId)
                                                            .Include(func => func.Authentication)
                                                            .Select(func => func.Authentication.Id)
                                                            .FirstOrDefault();



                funcionario.AuthenticationId = AuthenticationId;
                

                funcionarioServices.Atualizar(funcionario);
                funcionarioServices.Commit();

                return Ok(JsonConvert.SerializeObject(new { message = "Funcionario alterado com Sucesso!" }));

            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(new { menssage = "Ocorreu algum erro: " + ex.InnerException.Message }));
            }
        }

        [HttpDelete]
        [Route("Delete/{id:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ExcluirFuncionario(int id)
        {
            try
            {
                FuncionarioServices funcionarioServices = new FuncionarioServices(_contexto);

                funcionarioServices.Deletar(serv => serv.Id == id);
                funcionarioServices.Commit();

                return Ok(JsonConvert.SerializeObject(new { message = "Funcionario deletado com Sucesso!" }));

            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(new { menssage = "Ocorreu algum erro: " + ex.InnerException.Message }));
            }
        }

    }
}
