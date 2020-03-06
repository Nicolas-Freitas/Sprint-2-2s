using InLockFirstDataBase.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InLockFirstDataBase.Interface
{
    interface IJogoRepository
    {
        List<Jogos> Listar();

        Jogos BuscarPorId(int id);


        void Cadastrar(Jogos novoJogo);

        void Atualizar(int id, Jogos jogo);

        void Deletar(int id);
    }
}

