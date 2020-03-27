using spmedgroup.Domains;

namespace spmedgroup.Interfaces
{
    public interface ISituacaoConsultaRepository
    {
        void Cadastrar(SituacaoConsulta situacaoConsulta);
        void Deletar(int id);
        void Atualizar(int id, SituacaoConsulta situacaoConsulta);
    }
}