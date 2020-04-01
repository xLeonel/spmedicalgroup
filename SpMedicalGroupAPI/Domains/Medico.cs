using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace spmedgroup.Domains
{
    public partial class Medico
    {
        public Medico()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdMedico { get; set; }

        [StringLength(8, MinimumLength = 1, ErrorMessage = "crm deve ter entre 1 e 8 caracteres (12345-SP) ")]
        [Required(ErrorMessage = "É necessário informar o crm")]
        public string Crm { get; set; }

        [Required(ErrorMessage = "É necessário informar a clinica do medico")]
        public int? IdClinica { get; set; }

        // [Required(ErrorMessage = "É necessário informar a especialidade do medico")]
        public int? IdEspecialidade { get; set; }

        // [Required(ErrorMessage = "É necessário informar a as informaçoes do medico", AllowEmptyStrings = true)]
        public int? IdUsuario { get; set; }

        public Clinica IdClinicaNavigation { get; set; }
        public Especialidade IdEspecialidadeNavigation { get; set; }
        public Usuario IdUsuarioNavigation { get; set; }
        public ICollection<Consulta> Consulta { get; set; }
    }
}
