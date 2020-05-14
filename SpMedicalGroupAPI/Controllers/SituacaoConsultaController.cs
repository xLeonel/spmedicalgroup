using Microsoft.AspNetCore.Mvc;
using spmedgroup.Domains;
using spmedgroup.Interfaces;
using spmedgroup.Repositories;

namespace SpMedicalGroupAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SituacaoConsultaController : ControllerBase
    {
        private ISituacaoConsultaRepository _situacaoConsultaRepository;

        public SituacaoConsultaController()
        {
            _situacaoConsultaRepository = new SituacaoConsultaRepository();
        }

        [HttpPost]
        public IActionResult Cadastrar(SituacaoConsulta situacaoConsultaJson)
        {
            _situacaoConsultaRepository.Cadastrar(situacaoConsultaJson);
            return Created("Criado",situacaoConsultaJson);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, SituacaoConsulta situacaoConsultaJson)
        {
            _situacaoConsultaRepository.Atualizar(id,situacaoConsultaJson);
            return Ok("Atualizado");
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _situacaoConsultaRepository.Deletar(id);
            return Ok("Deletado");
        }

    }
}