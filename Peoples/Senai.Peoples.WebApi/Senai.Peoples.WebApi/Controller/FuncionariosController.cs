using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domaing;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;

namespace Senai.Peoples.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private IFuncionarioRepository _funcionarioRepository { get; set; }

        public FuncionariosController()
        {
            _funcionarioRepository = new FuncionarioRepository();
        }
        [HttpGet]
        public IEnumerable<FuncionarioDomain> Get()
        {
            return _funcionarioRepository.Listar();
        }
        [HttpPost]
        public IActionResult Cadastrar(FuncionarioDomain FuncionarioDomain)
        {
            _funcionarioRepository.Cadastrar(FuncionarioDomain);
            return Ok();
        }

        [HttpPut("{id}")]

        public IActionResult Alterar(FuncionarioDomain FuncionarioDomain, int id)
        {
            FuncionarioDomain.IdFuncionario = id;
            _funcionarioRepository.Alterar(FuncionarioDomain);
            return Ok();
        }

        [HttpDelete("{id}")]

        public IActionResult Deletar(int id)
        {
            _funcionarioRepository.Deletar(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(id);

            if (funcionarioBuscado == null)
            {
                return NotFound("Nenhum funcionario encontrado");
            }

            return Ok(funcionarioBuscado);
        }
    }
}
    