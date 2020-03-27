using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace spmedgroup.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Consulta = new HashSet<Consulta>();
            Medico = new HashSet<Medico>();
        }

        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "É necessário informar o nome do usuario")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "É necessário informar o rg")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "É necessário informar o cpf")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "É necessário informar a data de nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "É necessário informar o email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "É necessário informar a senha")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Senha deve ter entre 5 e 30 caracteres")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "É necessário informar a rua")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "É necessário informar o bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "É necessário informar o cep")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "É necessário informar o numero")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "É necessário informar o estado")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "É necessário informar o municipio")]
        public string Municipio { get; set; }

        [Required(ErrorMessage = "É necessário informar o complemento", AllowEmptyStrings = true)]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "É necessário informar o telefone")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "É necessário informar o tipo do usuario")]
        public int IdTipoUsuario { get; set; }

        public TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public ICollection<Consulta> Consulta { get; set; }
        public ICollection<Medico> Medico { get; set; }
    }
}
