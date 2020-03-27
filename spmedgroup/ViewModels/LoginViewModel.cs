using System.ComponentModel.DataAnnotations;

namespace spmedgroup.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Insira o e-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Insira o sua senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}