using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamentoCadastro.Models
{
    public class ManobristaViewModel
    {
        public long Id { get; set; }
        public string NomeManobrista { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
