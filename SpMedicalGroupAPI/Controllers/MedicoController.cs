using Microsoft.AspNetCore.Mvc;
using spmedgroup.Domains;
using SpMedicalGroupAPI.Interfaces;
using SpMedicalGroupAPI.Repositories;
using SpMedicalGroupAPI.ViewModels;

namespace SpMedicalGroupAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private IMedicoRepository _medicoRepository;

        public MedicoController()
        {
            _medicoRepository = new MedicoRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_medicoRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Medico json)
        {
            _medicoRepository.Cadastrar(json);
            return Created("Cadastrado",json);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _medicoRepository.Deletar(id);
            return Ok("Deletado");
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, MedicoViewModel json)
        {
            _medicoRepository.Atualizar(id, json);
            return Ok("Atualizado");
        }
    }
}