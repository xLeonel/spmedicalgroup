using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using spmedgroup.Contexts;
using spmedgroup.Domains;
using spmedgroup.Repositories;
using SpMedicalGroupAPI.Domains;
using SpMedicalGroupAPI.Interfaces;
using SpMedicalGroupAPI.ViewModels;

namespace SpMedicalGroupAPI.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        SpMedicalGroupContext ctx = new SpMedicalGroupContext();
        UsuarioRepository _userRepository = new UsuarioRepository();
        CrmApiRepository _crmApiRepository = new CrmApiRepository();
        EspecialidadeRepository _especialidadeRepository = new EspecialidadeRepository();

        public void Atualizar(int id, MedicoViewModel json)
        {
            Medico medicoSelect = ctx.Medico.Find(id);

            medicoSelect.IdClinica = json.IdClinica;
            medicoSelect.IdEspecialidade = json.IdEspecialidade;

            ctx.Medico.Update(medicoSelect);
            ctx.SaveChanges();

        }

        public async void Cadastrar(Medico json)
        {
            var crmSplitado = json.Crm.Split("-", 2);

            var crmObjeto = await _crmApiRepository.GetCRM(crmSplitado[1], crmSplitado[0]);

            CrmDomain crm = new CrmDomain();
            foreach (var item in crmObjeto.item)
            {
                crm.Tipo = item.Tipo;
                crm.Nome = item.Nome;
                crm.Numero = item.Numero;
                crm.Profissao = item.Profissao;
                crm.Uf = item.Uf;
                crm.Situacao = item.Situacao;
            }


            //DEIXA A PROFISSAO VINDA DA API NO PADRAO Q TA NO BANCO 'Anestologia'
            string[] especialidadeSplitado = crm.Profissao.ToLower().Split();
            string primeiraLetra = especialidadeSplitado[0];
            primeiraLetra = primeiraLetra.Length > 1 ? char.ToUpper(primeiraLetra[0]) + primeiraLetra.Substring(1) : primeiraLetra.ToUpper();


            //VERIFICA SE A PROFISSAO EXISTE E SE N EXISTE CRIA ELA NO BANCO
            List<Especialidade> especialidadesAtuais = _especialidadeRepository.Listar();
            if (!especialidadesAtuais.Exists(e => e.NomeEspecialidade == primeiraLetra))
            {
                Especialidade especialidade = new Especialidade();

                especialidade.NomeEspecialidade = primeiraLetra;
                _especialidadeRepository.Cadastrar(especialidade);
            }

            if (string.IsNullOrEmpty(crm.Profissao))
            {
                json.IdEspecialidade = 1;
            }
            else
            {
                //PROCURA A ESPECIALIDADE E PEGA O ID DELA E ATRIBUI AO MEU OBJETO JSON
                Especialidade especialidadeSelect = especialidadesAtuais.Find(e => e.NomeEspecialidade == primeiraLetra);
                json.IdEspecialidade = especialidadeSelect.IdEspecialidade;
            }


            Usuario usuario = new Usuario();

            Random num = new Random();

            usuario.Nome = crm.Nome;
            usuario.Rg = $"{num.Next(0, 9)}{num.Next(0, 9)}.{num.Next(0, 9)}{num.Next(0, 9)}{num.Next(0, 9)}.{num.Next(0, 9)}{num.Next(0, 9)}{num.Next(0, 9)}-{num.Next(0, 9)}";
            usuario.Cpf = $"{num.Next(0, 9)}{num.Next(0, 9)}{num.Next(0, 9)}.{num.Next(0, 9)}{num.Next(0, 9)}{num.Next(0, 9)}.{num.Next(0, 9)}{num.Next(0, 9)}{num.Next(0, 9)}-{num.Next(0, 9)}{num.Next(0, 9)}";
            usuario.DataNascimento = Convert.ToDateTime("02/02/0002");

            var nomeSplit = crm.Nome.ToLower().Split(' ');
            usuario.Email = $"{nomeSplit[0] + nomeSplit[1]}@email.com";
            usuario.Senha = $"{crmSplitado[0]}";
            usuario.Rua = "";
            usuario.Bairro = "";
            usuario.Cep = "03807300";
            usuario.Numero = 0;
            usuario.Uf = "";
            usuario.Localidade = "";
            usuario.Complemento = "";
            usuario.Telefone = "1111-2222";
            usuario.IdTipoUsuario = 3;

            _userRepository.Cadastrar(usuario);

            await Task.Delay(2000);

            List<Usuario> usuariosAtuais = _userRepository.ListarTodosUsers();
            Usuario userSelect = usuariosAtuais.FirstOrDefault(i => i.Senha == usuario.Senha);

            json.IdUsuario = userSelect.IdUsuario;

            ctx.Medico.Add(json);
            ctx.SaveChanges();

        }

        public void Deletar(int id)
        {
            Medico medico = ctx.Medico.Find(id);

            ctx.Medico.Remove(medico);
            ctx.SaveChanges();
            
            _userRepository.Deletar(medico.IdUsuario.GetValueOrDefault());
        }

        public List<Medico> Listar()
        {
            return ctx.Medico.ToList();
        }
    }
}