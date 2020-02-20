using Senai.Peoples.WebApi.Domaing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    interface IFuncionarioRepository
    {
        List<FuncionarioDomain> Listar();
        void Cadastrar(FuncionarioDomain funcionarioDomain);
        void Alterar(FuncionarioDomain funcionarioDomain);
        void Deletar(int id);
        FuncionarioDomain BuscarPorId(int id);
    }
}
