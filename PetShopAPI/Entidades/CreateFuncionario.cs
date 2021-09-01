using System;

namespace PetShopAPI.Entidades
{
    public class CreateFuncionario
    {
        public int? FuncionarioId { get; set; }
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Email { get; set; }
        public int? GerenteId { get; set; }
        public int? EmpresaId { get; set; }
        public int? AuthenticationId { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
