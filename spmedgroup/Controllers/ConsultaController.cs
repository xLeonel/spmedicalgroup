using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using spmedgroup.Domains;
using spmedgroup.Interfaces;
using spmedgroup.Repositories;

namespace spmedgroup.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private IConsultaRepository _consultaRepository; 

        public ConsultaController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        /// <summary>
        /// Lista todas as consultas
        /// </summary>
        /// <returns>retorna uma lista de todas as consultas</returns>
        [HttpGet]
        public IActionResult ListarTodasConsulta()
        {
            return Ok(_consultaRepository.ListarTodasConsulta());
        }

        /// <summary>
        /// Lista as Consultas pelo id do paciente
        /// </summary>
        /// <param name="id"></param>
        /// <returns>retorna uma lista das consultas do paciente</returns>
        [HttpGet("Paciente/{id}")]
        public IActionResult ListarPorPaciente(int id)
        {          
            return Ok(_consultaRepository.ListarPorPaciente(id));
        }

        /// <summary>
        /// Lista as Consultas pelo id do medico
        /// </summary>
        /// <param name="id"></param>
        /// <returns>retorna uma lista das consultas do medico</returns>
        [HttpGet("Medico/{id}")]
        public IActionResult ListarPorMedico(int id)
        {
            return Ok(_consultaRepository.ListarPorMedico(id));
        }

        /// <summary>
        /// Cadastra uma consulta
        /// </summary>
        /// <param name="consultaJson"></param>
        /// <returns>retorna uma consulta</returns>
        [HttpPost]
        public IActionResult Cadastrar(Consulta consultaJson)
        {
            _consultaRepository.Cadastrar(consultaJson);
            return Created("Consulta Cadastrada", consultaJson);
        }
    }
}