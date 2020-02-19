using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Domain;

namespace WebApplication1.Interfaces
{
    interface IGeneroRepository
    {
        /// <summary>
        /// Lista todos os gêneros
        /// </summary>
        /// <returns>Retorna uma lista de gêneros</returns>
        List<GeneroDomain> Listar();
        void Cadastrar(GeneroDomain generoDomain);
        void Alterar(GeneroDomain generoDomain);
        void Deletar(int id);
        GeneroDomain BuscarPorId(int id);
    }
}

