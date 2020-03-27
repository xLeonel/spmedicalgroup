using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace spmedgroup.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            Medico = new HashSet<Medico>();
        }

        public int IdClinica { get; set; }

        [Required(ErrorMessage = "É necessário informar o nome da clinica")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "É necessário informar o cnpj da clinica")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "É necessário informar a razao social da clinica")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "É necessário informar a rua")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "É necessário informar o bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "É necessário informar o cep")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "É necessário informar o numero")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "É necessário informar o estado")]
        public string Uf { get; set; }

        [Required(ErrorMessage = "É necessário informar o municipio")]
        public string Localidade { get; set; }

        [Required(ErrorMessage = "É necessário informar o complemento", AllowEmptyStrings = true)]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "É necessário informar o telefone")]
        public string Telefone { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}")]
        public TimeSpan HorarioAbre { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}")]
        public TimeSpan HorarioFecha { get; set; }

        public ICollection<Medico> Medico { get; set; }
    }
}
