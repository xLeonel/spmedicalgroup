using spmedgroup.Contexts;
using spmedgroup.Domains;
using spmedgroup.Interfaces;

namespace spmedgroup.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        SpMedicalGroupContext ctx = new SpMedicalGroupContext();

        public void Atualizar(int id, Especialidade especialidade)
        {
            Especialidade especialidadeSelect = ctx.Especialidade.Find(id);

            especialidadeSelect.NomeEspecialidade = especialidade.NomeEspecialidade;

            ctx.Especialidade.Update(especialidadeSelect);
            ctx.SaveChanges();
        }

        public void Cadastrar(Especialidade especialidade)
        {
            ctx.Especialidade.Add(especialidade);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Especialidade.Remove(ctx.Especialidade.Find(id));
            ctx.SaveChanges();
        }
    }
}