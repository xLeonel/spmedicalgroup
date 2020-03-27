using System.Collections.Generic;
using System.Linq;
using spmedgroup.Contexts;
using spmedgroup.Domains;
using spmedgroup.Interfaces;

namespace spmedgroup.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        SpMedicalGroupContext ctx = new SpMedicalGroupContext();

        EnderecoRepository end = new EnderecoRepository();

        public void Atualizar(int id, Usuario userjson)
        {
            Usuario userSelect = ctx.Usuario.Find(id);

            userSelect.Nome = userjson.Nome;
            userSelect.Rg = userjson.Rg;
            userSelect.Cpf = userjson.Cpf;
            userSelect.DataNascimento = userjson.DataNascimento;
            userSelect.Email = userjson.Email;
            userSelect.Senha = userjson.Senha;
            userSelect.Rua = userjson.Rua;
            userSelect.Bairro = userjson.Bairro;
            userSelect.Cep = userjson.Cep;
            userSelect.Numero = userjson.Numero;
            userSelect.Estado = userjson.Estado;
            userSelect.Municipio = userjson.Municipio;
            userSelect.Complemento = userjson.Complemento;
            userSelect.Telefone = userjson.Telefone;
            userSelect.IdTipoUsuario = userjson.IdTipoUsuario;

            ctx.Usuario.Update(userSelect);
            ctx.SaveChanges();
        }

        public Usuario BuscarUsuario(string email, string senha)
        {
            return ctx.Usuario.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

        public async void Cadastrar(Usuario userjson)
        {
            var endereco = await end.GetAdress(userjson.Cep);
            userjson.Rua = endereco.Logradouro;
            userjson.Bairro = endereco.Bairro;
            ctx.Usuario.Add(userjson);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Remove(ctx.Usuario.Find(id));
            ctx.SaveChanges();
        }

        public List<Usuario> ListarTodosMedicos()
        {
            return ctx.Usuario.ToList().FindAll(u => u.IdTipoUsuario == 3); // 3 = medico
        }

        public List<Usuario> ListarTodosPaciente()
        {
            return ctx.Usuario.ToList().FindAll(u => u.IdTipoUsuario == 1); // 1 = paciente
        }

        public List<Usuario> ListarTodosUsers()
        {
            return ctx.Usuario.ToList();
        }
    }
}