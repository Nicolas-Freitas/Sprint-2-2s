using System;
using System.Collections.Generic;

namespace InLockFirstDataBase.Domains
{
    public partial class Estudio
    {
        public Estudio()
        {
            Jogos = new HashSet<Jogos>();
        }

        public int IdEstudio { get; set; }
        public string EstudioNome { get; set; }

        public ICollection<Jogos> Jogos { get; set; }
    }
}
