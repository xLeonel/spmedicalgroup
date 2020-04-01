using System.Threading.Tasks;
using Refit;
using SpMedicalGroupAPI.Domains;

namespace SpMedicalGroupAPI.Interfaces
{
    public interface ICrmApiRepository
    {
        [Get("/index.php?tipo=crm&uf={uf}&q={crm}&chave=8543407019&destino=json")]
        Task<CrmApi> GetCRM(string uf,string crm);
    }
}