using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using spmedgroup.Domains;
using spmedgroup.Interfaces;
using spmedgroup.Repositories;

namespace spmedgroup.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

       /// <summary>
       /// Lista de todos os usuarios
       /// </summary>
       /// <returns>retorna uma lista de todos os usuarios</returns>
        [HttpGet]
        public ActionResult ListarTodosUser()
        {
            return Ok(_usuarioRepository.ListarTodosUsers());
        }

        /// <summary>
        /// Lista de todos os medicos
        /// </summary>
        /// <returns>retorna uma lista de todos os medicos</returns>
        [HttpGet("Medicos")]
        public ActionResult ListarTodosMedicos()
        {
            return Ok(_usuarioRepository.ListarTodosMedicos());
        }

        /// <summary>
        /// Lista de todos os pacientes
        /// </summary>
        /// <returns>retorna uma lista de todos os pacientes</returns>
        [HttpGet("Pacientes")]
        public ActionResult ListarTodosPacientes()
        {
            return Ok(_usuarioRepository.ListarTodosPaciente());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// Cadastra um Usuario
        /// </summary>
        /// <param name="userjson"></param>
        /// <returns>retorna um usuario cadastrado</returns>
        [HttpPost]
        public IActionResult Cadastrar(Usuario userjson)
        {
            _usuarioRepository.Cadastrar(userjson);
            return Created("Criado",userjson);
        }

        /// <summary>
        /// Atualiza um Usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userjson"></param>
        /// <returns>retorna uma mensagem de atualizaçao</returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Usuario userjson)
        {
            _usuarioRepository.Atualizar(id,userjson);
            return Ok("Atualizado");
        }

        /// <summary>
        /// Deleta um usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns>retorna uma mensagem</returns>
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _usuarioRepository.Deletar(id);
            return Ok("Deletado");
        }
    }
}
