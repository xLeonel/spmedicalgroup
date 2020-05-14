using Microsoft.AspNetCore.Mvc;
using spmedgroup.Domains;
using spmedgroup.Interfaces;
using spmedgroup.Repositories;

namespace SpMedicalGroupAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadeController : ControllerBase
    {
        private IEspecialidadeRepository _especialidadeRepository;

        public EspecialidadeController()
        {
            _especialidadeRepository = new EspecialidadeRepository();
        }

        [HttpGet]
        public IActionResult ListarTodasEspecialidade()
        {
            return Ok(_especialidadeRepository.Listar());
        }

        [HttpPost]
        public IActionResult CadastrarEspecialidade(Especialidade especialidadeJson)
        {
            _especialidadeRepository.Cadastrar(especialidadeJson);
            return Created("Criado",especialidadeJson);
        }

        [HttpDelete]
        public IActionResult DeletarEspecialidade(int id)
        {
            _especialidadeRepository.Deletar(id);
            return Ok("Deletado");
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarEspecialidade(int id, Especialidade especialidadeJson)
        {
            _especialidadeRepository.Atualizar(id,especialidadeJson);
            return Ok("Atualizado");
        }
        
    }
}