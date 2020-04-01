using System.Threading.Tasks;
using Refit;
using SpMedicalGroupAPI.Domains;
using SpMedicalGroupAPI.Interfaces;

namespace SpMedicalGroupAPI.Repositories
{
    public class CrmApiRepository : ICrmApiRepository
    {
        public async Task<CrmApi> GetCRM(string uf, string crm)
        {
            var crmApi = RestService.For<ICrmApiRepository>("https://www.consultacrm.com.br/api");
            var crmRetornado = await crmApi.GetCRM(uf,crm);

            return crmRetornado;
        }
    }
}