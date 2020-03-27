using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace spmedgroup.Domains
{
    public partial class Especialidade
    {
        public Especialidade()
        {
            Medico = new HashSet<Medico>();
        }

        public int IdEspecialidade { get; set; }
        
        [Required(ErrorMessage = "é necessário inserir uma especialidade")]
        public string NomeEspecialidade { get; set; }

        public ICollection<Medico> Medico { get; set; }
    }
}
