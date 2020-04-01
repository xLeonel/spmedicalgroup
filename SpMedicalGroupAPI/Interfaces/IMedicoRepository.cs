using System.Collections.Generic;
using spmedgroup.Domains;

namespace SpMedicalGroupAPI.Interfaces
{
    public interface IMedicoRepository
    {
        List<Medico> Listar();
        void Cadastrar(Medico json);
    }
}