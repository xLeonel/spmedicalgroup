using System.Collections.Generic;
using spmedgroup.Domains;

namespace spmedgroup.Interfaces
{
    public interface IEspecialidadeRepository
    {
        void Cadastrar(Especialidade especialidade);
        void Deletar(int id);
        void Atualizar(int id, Especialidade especialidade);

        List<Especialidade> Listar();
    }
}