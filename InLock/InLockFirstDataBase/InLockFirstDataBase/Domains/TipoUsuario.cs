using System;
using System.Collections.Generic;

namespace InLockFirstDataBase.Domains
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int IdTipoUsuario { get; set; }
        public string Titulo { get; set; }

        public ICollection<Usuario> Usuario { get; set; }
    }
}
