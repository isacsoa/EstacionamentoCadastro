using EstacionamentoCadastro.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstacionamentoCadastro.Models
{
    public class CarroManobradoViewModel
    {
        public long Id { get; set; }
        public long IdCarro { get; set; }
        public long IdManobrista { get; set; }
        public Carro Carro { get; set; }
        public Manobrista Manobrista { get; set; }
    }
}
