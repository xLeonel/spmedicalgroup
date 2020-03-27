using spmedgroup.Contexts;
using spmedgroup.Domains;
using spmedgroup.Interfaces;

namespace spmedgroup.Repositories
{
    public class SituacaoConsultaRepository : ISituacaoConsultaRepository
    {
        SpMedicalGroupContext ctx = new SpMedicalGroupContext();

        public void Atualizar(int id,SituacaoConsulta situacaoConsulta)
        {
            SituacaoConsulta situacaoConsultaSelect = ctx.SituacaoConsulta.Find(id);

            situacaoConsultaSelect.NomeSituacaoConsulta = situacaoConsulta.NomeSituacaoConsulta;

            ctx.SituacaoConsulta.Update(situacaoConsultaSelect);
            ctx.SaveChanges();
        }

        public void Cadastrar(SituacaoConsulta situacaoConsulta)
        {
            ctx.SituacaoConsulta.Add(situacaoConsulta);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.SituacaoConsulta.Remove(ctx.SituacaoConsulta.Find(id));
            ctx.SaveChanges();
        }
    }
}