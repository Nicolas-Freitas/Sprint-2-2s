using System;
using System.Collections.Generic;
using WebApplication1.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Interfaces
{
    interface IFilmeRepository
    {
        List<FilmeDomain> Listar();
        void Cadastrar(FilmeDomain filmeDomain);
        void Alterar(FilmeDomain filmeDomain);
        void Deletar(int id);
        FilmeDomain BuscarPorId(int id);

    }
}

