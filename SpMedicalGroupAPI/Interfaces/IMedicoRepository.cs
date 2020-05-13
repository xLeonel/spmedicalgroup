using System.Collections.Generic;
using spmedgroup.Domains;
using SpMedicalGroupAPI.ViewModels;

namespace SpMedicalGroupAPI.Interfaces
{
    public interface IMedicoRepository
    {
        List<Medico> Listar();
        void Cadastrar(Medico json);
        void Deletar(int id);
        void Atualizar(int id, MedicoViewModel json);
    }
}