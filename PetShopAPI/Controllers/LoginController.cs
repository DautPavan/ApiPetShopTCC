using AutoMapper;
using Dados;
using Dados.Services;
using Dominio.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PetShopAPI.Entidades;
using PetShopAPI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private ApplicationDbContext _contexto;
        protected readonly IMapper _mapper;

        public LoginController(ApplicationDbContext contexto, IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;

        }

        [HttpPost]
        [Route("CreateUserSite")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateFuncionario([FromBody] CreateFuncionario body)
        {
            try
            {
                if (body == null)
                    return BadRequest(JsonConvert.SerializeObject(new { message = "A solicitação não contem corpo" }));

                if (body.Login == null)
                    return BadRequest(JsonConvert.SerializeObject(new { message = "A solicitação não contem login" }));

                if (body.Senha == null)
                    return BadRequest(JsonConvert.SerializeObject(new { message = "A solicitação não contem senha" }));

                AuthenticationServices authenticationServices = new AuthenticationServices(_contexto);
                FuncionarioServices funcionarioServices = new FuncionarioServices(_contexto);

                var funcionario = _mapper.Map<Funcionario>(body);
                var authentication = _mapper.Map<Authentication>(body);

                authenticationServices.Adicionar(authentication);
                authenticationServices.Commit();

                funcionario.AuthenticationId = authentication.Id;
                funcionarioServices.Adicionar(funcionario);
                funcionarioServices.Commit();

                return StatusCode(StatusCodes.Status201Created, JsonConvert.SerializeObject( new { menssage = "Funcionario criado com sucesso" }));

            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject( new { menssage = "Ocorreu algum erro: " + ex.InnerException.Message }));
            }
        }

        [HttpPost]
        [Route("CreateUserMobile")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateDono([FromBody]CreateDono body) 
        {
            try
            {
                if (body == null)
                    return BadRequest(JsonConvert.SerializeObject(new { message = "A solicitação não contem corpo" }));

                if (body.Login == null)
                    return BadRequest(JsonConvert.SerializeObject(new { message = "A solicitação não contem login" }));

                if (body.Senha == null)
                    return BadRequest(JsonConvert.SerializeObject(new { message = "A solicitação não contem senha" }));

                AuthenticationServices authenticationServices = new AuthenticationServices(_contexto);
                DonoServices donoServices = new DonoServices(_contexto);

                var dono = _mapper.Map<Dono>(body);
                var authentication = _mapper.Map<Authentication>(body);

                authenticationServices.Adicionar(authentication);
                authenticationServices.Commit();

                dono.AuthenticationId = authentication.Id;
                donoServices.Adicionar(dono);
                donoServices.Commit();

                return StatusCode(StatusCodes.Status201Created, "Usuario criado com sucesso");

            } catch (Exception ex) 
            {
                return BadRequest(JsonConvert.SerializeObject(new { menssage = "Ocorreu algum erro: " + ex.InnerException.Message }));
            }
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] Authentication body)
        {
            try
            {
                if (body == null)
                    return BadRequest(JsonConvert.SerializeObject(new { message = "A solicitação não contem corpo" }));

                if (body.Login == null)
                    return BadRequest(JsonConvert.SerializeObject(new { message = "A solicitação não contem login" }));

                if (body.Senha == null)
                    return BadRequest(JsonConvert.SerializeObject(new { message = "A solicitação não contem senha" }));

                AuthenticationServices authenticationServices = new AuthenticationServices(_contexto);


                var result = authenticationServices.Primeiro(
                        aut => aut.Login.ToLower().Contains(body.Login) && 
                        aut.Senha.Contains(body.Senha)
                );


                if (result == null)
                    return NotFound(JsonConvert.SerializeObject(new { menssage = "Usuario não encontrado" }));


                var token = TokenService.GerarToken(result);

                var obj = new { 
                                Id = result.Id, 
                                Login = result.Login, 
                                Token = token 
                            };

                return Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(JsonConvert.SerializeObject(new { menssage = "Ocorreu algum erro: " + ex.InnerException.Message }));
            }
        }

    }
}
