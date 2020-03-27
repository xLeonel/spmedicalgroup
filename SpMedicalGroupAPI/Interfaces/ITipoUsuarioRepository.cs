using spmedgroup.Domains;

namespace spmedgroup.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        void Cadastrar(TipoUsuario tipoUsuario);
        void Deletar(int id);
        void Atualizar(int id, TipoUsuario tipoUsuario);
    }
}