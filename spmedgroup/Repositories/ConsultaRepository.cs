using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using spmedgroup.Contexts;
using spmedgroup.Domains;
using spmedgroup.Interfaces;

namespace spmedgroup.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        SpMedicalGroupContext ctx = new SpMedicalGroupContext();

        public void Atualizar(int id, Consulta consultaJson)
        {
            Consulta consultaSelect = ctx.Consulta.Find(id);

            consultaSelect.DataConsulta = consultaJson.DataConsulta;
            consultaSelect.DescricaoPaciente = consultaJson.DescricaoPaciente;
            consultaSelect.IdMedico = consultaJson.IdMedico;
            consultaSelect.IdUsuario = consultaJson.IdUsuario;
            consultaSelect.IdSituacaoConsulta = consultaJson.IdSituacaoConsulta;

            ctx.Consulta.Update(consultaSelect);
            ctx.SaveChanges();
        }

        public void Cadastrar(Consulta consultaJson)
        {
            ctx.Consulta.Add(consultaJson);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Remove(ctx.Consulta.Find(id));
            ctx.SaveChanges();
        }

        public List<Consulta> ListarPorMedico(int id)
        {
            return ctx.Consulta.ToList().FindAll(c => c.IdMedico == id); 
        }

        public List<Consulta> ListarPorPaciente(int id)
        {
            return ctx.Consulta.ToList().FindAll(c => c.IdUsuario == id);
        }

        public List<Consulta> ListarTodasConsulta()
        {
            return ctx.Consulta.ToList();
        }
    }
}