using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace spmedgroup.Domains
{
    public partial class SituacaoConsulta
    {
        public SituacaoConsulta()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdSituacaoConsulta { get; set; }

        [Required(ErrorMessage = "É necessário inserir um titulo")]
        public string NomeSituacaoConsulta { get; set; }

        public ICollection<Consulta> Consulta { get; set; }
    }
}
