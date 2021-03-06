﻿using Senai.Peoples.WebApi.Domains;
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
        void Deletar(int id);
        FuncionarioDomain BuscarPorId(int id);
        
    }
}
