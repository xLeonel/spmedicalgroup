using System.Collections.Generic;
using spmedgroup.Domains;

namespace spmedgroup.Interfaces
{
    public interface ISituacaoConsultaRepository
    {
        List<SituacaoConsulta> Listar();
        void Cadastrar(SituacaoConsulta situacaoConsulta);
        void Deletar(int id);
        void Atualizar(int id, SituacaoConsulta situacaoConsulta);
    }
}