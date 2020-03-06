using InLockFirstDataBase.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InLockFirstDataBase.Interface
{

        interface IEstudioRepository
        {
            /// <summary>
            /// Lista todos os estúdios
            /// </summary>
            /// <returns>Uma lista de estúdios</returns>
            List<Estudio> Listar();

            /// <summary>
            /// Busca um estúdio através do ID
            /// </summary>
            /// <param name="id">ID do estúdio que será buscado</param>
            /// <returns>Um estúdio buscado</returns>
            Estudio BuscarPorId(int id);

            /// <summary>
            /// Cadastra um novo estúdio
            /// </summary>
            /// <param name="novoEstudio">Objeto novoEstudio que será cadastrado</param>
            void Cadastrar(Estudio novoEstudio);

            void Deletar(int id);
        }
    }
