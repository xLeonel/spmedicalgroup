using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace spmedgroup.Domains
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int IdTipoUsuario { get; set; }

        [Required(ErrorMessage = "É necessário inserir um titulo")]
        public string NomeTipoUsuario { get; set; }

        public ICollection<Usuario> Usuario { get; set; }
    }
}
