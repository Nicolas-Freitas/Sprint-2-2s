using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Domaing
{
    public class FuncionarioDomain
    {
        public int IdFuncionario { get; set; }
        [Required(ErrorMessage = "O nome do funcionário é obrigatório!")]

        public string Nome { get; set; }
        [Required(ErrorMessage = "O sobrenome do funcionário é obrigatório!")]


        public string Sobrenome { get; set; }

    }
}
