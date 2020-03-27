using System.Collections.Generic;
using spmedgroup.Domains;

namespace spmedgroup.Interfaces
{
    public interface IConsultaRepository
    {
        List<Consulta> ListarTodasConsulta();
        List<Consulta> ListarPorPaciente(int id);
        List<Consulta> ListarPorMedico(int id);
        void Cadastrar(Consulta consultaJson);
        void Atualizar(int id, Consulta consultaJson);
        void Deletar(int id);
    }
}