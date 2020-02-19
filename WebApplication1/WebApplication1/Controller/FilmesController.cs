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
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private IFilmeRepository _filmeRepository { get; set; }

        public FilmesController()
        {
            _filmeRepository = new FilmeRepository();
        }
        [HttpGet]
        public IEnumerable<FilmeDomain> Get()
        {
            return _filmeRepository.Listar();
        }

        [HttpPost]
        public IActionResult Cadastrar(FilmeDomain filmeDomain)
        {
            _filmeRepository.Cadastrar(filmeDomain);
            return Ok();
        }

        [HttpPut("{id}")]

        public IActionResult Alterar(FilmeDomain filmeDomain, int id)
        {
            filmeDomain.IdFilme = id;
            _filmeRepository.Alterar(filmeDomain);
            return Ok();
        }

        [HttpDelete("{id}")]

        public IActionResult Deletar(int id)
        {
            _filmeRepository.Deletar(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);

            if (filmeBuscado == null)
            {
                return NotFound("Nenhum filme encontrado");
            }

            return Ok(filmeBuscado);
        }
    }
}