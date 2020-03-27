using System.Threading.Tasks;
using Refit;
using spmedgroup.Domains;

namespace spmedgroup.Interfaces
{
    public interface IEnderecoRepository
    {
        [Get("/ws/{cep}/json")]
        Task<Endereco> GetAdress(string cep);
    }
}