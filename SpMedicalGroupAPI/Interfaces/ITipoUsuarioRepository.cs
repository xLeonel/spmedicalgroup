using System.Collections.Generic;
using spmedgroup.Domains;

namespace spmedgroup.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        List<TipoUsuario> Listar();
        void Cadastrar(TipoUsuario tipoUsuario);
        void Deletar(int id);
        void Atualizar(int id, TipoUsuario tipoUsuario);
    }
}