using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using spmedgroup.Domains;
using spmedgroup.Interfaces;
using spmedgroup.Repositories;
using spmedgroup.ViewModels;

namespace spmedgroup.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
         private IUsuarioRepository _usuarioRepository;

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Retorna um Token efetivando o login</returns>
        [HttpPost]
        public IActionResult Login(LoginViewModel user)
        {
            Usuario userSelect = _usuarioRepository.BuscarUsuario(user.Email,user.Senha);

            if (userSelect == null)
            {
                return NotFound("Email ou Senha inválidos");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, userSelect.Email),
                new Claim(JwtRegisteredClaimNames.Jti, userSelect.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, userSelect.IdTipoUsuario.ToString())
            };

            // Define a chave de acesso ao token
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("senai_SpMedicalGroup_VitorLeonel_key_auth"));

            // Define as credenciais do token - Header
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Gera o token
            var token = new JwtSecurityToken(
                issuer: "SpMedicalGroup.WebApi",                // emissor do token
                audience: "SpMedicalGroup.WebApi",              // destinatário do token
                claims: claims,                          // dados definidos acima
                expires: DateTime.Now.AddMinutes(30),    // tempo de expiração
                signingCredentials: creds                // credenciais do token
            );

            // Retorna Ok com o token
            return Ok( new {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}