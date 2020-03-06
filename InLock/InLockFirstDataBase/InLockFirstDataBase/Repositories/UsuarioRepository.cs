using InLockFirstDataBase.Domains;
using InLockFirstDataBase.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InLockFirstDataBase.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        InLockContext ctx = new InLockContext();
            
        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuario.FirstOrDefault(e => e.IdUsuario == id);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuario.Add(novoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            using (InLockContext ctx = new InLockContext())
            {
                Usuario UsuarioBuscado = ctx.Usuario.Find(id);
                ctx.Usuario.Remove(UsuarioBuscado);
                ctx.SaveChanges();
            }
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuario.ToList();
        }
    }
}
