using System.Collections.Generic;
using System.Linq;
using spmedgroup.Contexts;
using spmedgroup.Domains;
using spmedgroup.Interfaces;

namespace spmedgroup.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        SpMedicalGroupContext ctx = new SpMedicalGroupContext();

        public void Atualizar(int id, TipoUsuario tipoUsuario)
        {
            TipoUsuario tipoUsuarioSelect = ctx.TipoUsuario.Find(id);

            tipoUsuarioSelect.NomeTipoUsuario = tipoUsuario.NomeTipoUsuario;

            ctx.TipoUsuario.Update(tipoUsuarioSelect);
            ctx.SaveChanges();
        }

        public void Cadastrar(TipoUsuario tipoUsuario)
        {
            ctx.TipoUsuario.Add(tipoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.TipoUsuario.Remove(ctx.TipoUsuario.Find(id));
            ctx.SaveChanges();
        }

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuario.ToList();
        }
    }
}