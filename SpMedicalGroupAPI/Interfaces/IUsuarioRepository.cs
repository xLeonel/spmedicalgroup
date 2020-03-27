using System.Collections.Generic;
using spmedgroup.Domains;

namespace spmedgroup.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuario> ListarTodosUsers();
        List<Usuario> ListarTodosMedicos();
        List<Usuario> ListarTodosPaciente();
        Usuario BuscarUsuario(string email, string senha);
        void Cadastrar(Usuario userjson);
        void Atualizar(int id, Usuario userjson);
        void Deletar(int id);
    }
}