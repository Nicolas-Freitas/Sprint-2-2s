using InLockFirstDataBase.Domains;
using InLockFirstDataBase.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InLockFirstDataBase.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        InLockContext ctx = new InLockContext();

        public void Atualizar(int id, TipoUsuario tipoUsuario)
        {
            throw new NotImplementedException();
        }

        public TipoUsuario BuscarPorId(int id)
        {
            return ctx.TipoUsuario.FirstOrDefault(e => e.IdTipoUsuario == id);
        }

        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            ctx.TipoUsuario.Add(novoTipoUsuario);
            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                TipoUsuario TipoBuscado = ctx.TipoUsuario.Find(id);
                ctx.TipoUsuario.Remove(TipoBuscado);
                ctx.SaveChanges();
            }
        }

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuario.ToList();
        }
    }
}
