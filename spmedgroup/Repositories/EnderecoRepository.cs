using System;
using System.Threading.Tasks;
using Refit;
using spmedgroup.Domains;
using spmedgroup.Interfaces;

namespace spmedgroup.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        public async Task<Endereco> GetAdress(string cep)
        {
            var cepApi = RestService.For<IEnderecoRepository>("https://viacep.com.br/");
            var enderecoRetornado = await cepApi.GetAdress(cep);

            return enderecoRetornado;
        }
    }
}