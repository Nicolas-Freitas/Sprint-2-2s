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
    public class TiposUsuarioController
    {
        [Produces("application/json")]

        // Define que a rota de uma requisição será no formato domínio/api/NomeController
        [Route("api/[controller]")]

        // Define que é um controlador de API
        [ApiController]
        public class UsuariosController : ControllerBase
        {
            /// <summary>
            /// Cria um objeto _estudioRepository que irá receber todos os métodos definidos na interface
            /// </summary>
            private IUsuarioRepository _usuarioRepository;

            /// <summary>
            /// Instancia este objeto para que haja a referência aos métodos no repositório
            /// </summary>
            public UsuariosController()
            {
                _usuarioRepository = new UsuarioRepository();
            }

            /// <summary>
            /// Lista todos os estúdios
            /// </summary>
            /// <returns>Uma lista de estúdios e um status code 200 - Ok</returns>
            [HttpGet]
            public IActionResult Get()
            {
                // Retora a resposta da requisição fazendo a chamada para o método
                return Ok(_usuarioRepository.Listar());
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
                return Ok(_usuarioRepository.BuscarPorId(id));
            }

            /// <summary>
            /// Cadastra um novo estúdio
            /// </summary>
            /// <param name="novousuario">Objeto novousuario que será cadastrado</param>
            /// <returns>Um status code 201 - Created</returns>
            [HttpPost]
            public IActionResult Post(Usuario novoUsuario)
            {
                // Faz a chamada para o método
                _usuarioRepository.Cadastrar(novoUsuario);

                // Retorna um status code
                return StatusCode(201);
            }

            [HttpDelete("{id}")]
            public IActionResult Deletar(int id)
            {
                _usuarioRepository.Deletar(id);
                return Ok();
            }

        }
    }
}
