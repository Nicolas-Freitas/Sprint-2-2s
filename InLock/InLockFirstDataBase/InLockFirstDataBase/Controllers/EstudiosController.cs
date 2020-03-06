using InLockFirstDataBase.Domains;
using InLockFirstDataBase.Interface;
using InLockFirstDataBase.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InLockFirstDataBase.Controllers
{
        [Produces("application/json")]

        // Define que a rota de uma requisição será no formato domínio/api/NomeController
        [Route("api/[controller]")]

        // Define que é um controlador de API
        [ApiController]
        public class EstudiosController : ControllerBase
        {
            /// <summary>
            /// Cria um objeto _estudioRepository que irá receber todos os métodos definidos na interface
            /// </summary>
            private IEstudioRepository _estudioRepository;

            /// <summary>
            /// Instancia este objeto para que haja a referência aos métodos no repositório
            /// </summary>
            public EstudiosController()
            {
                _estudioRepository = new EstudioRepository();
            }

            /// <summary>
            /// Lista todos os estúdios
            /// </summary>
            /// <returns>Uma lista de estúdios e um status code 200 - Ok</returns>
            [HttpGet]
            public IActionResult Get()
            {
                // Retora a resposta da requisição fazendo a chamada para o método
                return Ok(_estudioRepository.Listar());
            }

            /// <summary>
            /// Busca um estúdio através do ID
            /// </summary>
            /// <param name="id">ID do estúdio que será buscado</param>
            /// <returns>Um estúdio buscado e um status code 200 - Ok</returns>
            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                // Retora a resposta da requisição fazendo a chamada para o método
                return Ok(_estudioRepository.BuscarPorId(id));
            }

            /// <summary>
            /// Cadastra um novo estúdio
            /// </summary>
            /// <param name="novoEstudio">Objeto novoEstudio que será cadastrado</param>
            /// <returns>Um status code 201 - Created</returns>
            [HttpPost]
            public IActionResult Post(Estudio novoEstudio)
            {
                // Faz a chamada para o método
                _estudioRepository.Cadastrar(novoEstudio);

                // Retorna um status code
                return StatusCode(201);
            }

            [HttpDelete("{id}")]
            public IActionResult Deletar(int id)
            {
                _estudioRepository.Deletar(id);
                return Ok();
            }

        }
    }
