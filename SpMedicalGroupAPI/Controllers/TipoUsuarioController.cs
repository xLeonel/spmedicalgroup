using Microsoft.AspNetCore.Mvc;
using spmedgroup.Domains;
using spmedgroup.Interfaces;
using spmedgroup.Repositories;

namespace SpMedicalGroupAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository;

        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_tipoUsuarioRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(TipoUsuario tipoUsuarioJson)
        {
            _tipoUsuarioRepository.Cadastrar(tipoUsuarioJson);
            return Created("Criado",tipoUsuarioJson);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, TipoUsuario tipoUsuarioJson)
        {
            _tipoUsuarioRepository.Atualizar(id,tipoUsuarioJson);
            return Ok("Atualizado");
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _tipoUsuarioRepository.Deletar(id);
            return Ok("Deletado");
        }
    }
}