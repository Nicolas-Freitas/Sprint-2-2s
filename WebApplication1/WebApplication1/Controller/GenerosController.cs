using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Domain;
using WebApplication1.Interfaces;
using WebApplication1.Repositories;


namespace WebApplication1.Controller
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private IGeneroRepository _generoRepository { get; set; }

        public GenerosController()
        {
            _generoRepository = new GeneroRepository();
        }

        [HttpGet]
        public IEnumerable <GeneroDomain> Get()
        {
            return _generoRepository.Listar();
        }

        [HttpPost]
        public IActionResult Cadastrar(GeneroDomain generoDomain)
        {
            _generoRepository.Cadastrar(generoDomain);
            return Ok();
        }

        [HttpPut("{id}")]

        public IActionResult Alterar(GeneroDomain generoDomain, int id)
        {
            generoDomain.IdGenero = id;
            _generoRepository.Alterar(generoDomain);
            return Ok();
        }

        [HttpDelete("{id}")]

        public IActionResult Deletar(int id)
        {
            _generoRepository.Deletar(id);
            return Ok();
        }
    }
}