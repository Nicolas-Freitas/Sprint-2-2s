using InLockFirstDataBase.Domains;
using InLockFirstDataBase.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InLockFirstDataBase.Repositories
{
    public class JogosRepository : IJogoRepository

    {
        InLockContext ctx = new InLockContext();

        public void Atualizar(int id, Jogos jogo)
        {
            throw new NotImplementedException();
        }

        public Jogos BuscarPorId(int id)
        {
            return ctx.Jogos.FirstOrDefault(e => e.IdJogo == id);
        }

        public void Cadastrar(Jogos novoJogo)
        {
            ctx.Jogos.Add(novoJogo);
            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                Jogos JogoBuscado = ctx.Jogos.Find(id);
                ctx.Jogos.Remove(JogoBuscado);
                ctx.SaveChanges();
            }
        }

        public List<Jogos> Listar()
        {
            return ctx.Jogos.ToList();
        }


    }
}