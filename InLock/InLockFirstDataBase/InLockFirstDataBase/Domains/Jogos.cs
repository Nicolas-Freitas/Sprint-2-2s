using System;
using System.Collections.Generic;

namespace InLockFirstDataBase.Domains
{
    public partial class Jogos
    {
        public int IdJogo { get; set; }
        public string NomeJogo { get; set; }
        public string Descricao { get; set; }
        public float Preco { get; set; }
        public DateTime DataLanc { get; set; }
        public int IdEstudio { get; set; }

        public Estudio IdEstudioNavigation { get; set; }
    }
}
