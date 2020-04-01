using Newtonsoft.Json;

namespace SpMedicalGroupAPI.Domains
{
    public class CrmDomain
    {
        // CRM / CREA 
        public string Tipo { get; set; }

        // NOME
        public string Nome { get; set; }

        // NUMERO DO CRM
        public string Numero { get; set; }

        // ESPECIALIDADE
        public string Profissao { get; set; }

        // ESTADO
        public string Uf { get; set; }

        // SITUAÇAO DO TIPO
        public string Situacao { get; set; }

    }
}