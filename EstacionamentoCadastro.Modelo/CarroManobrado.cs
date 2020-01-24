using System;

namespace EstacionamentoCadastro.Modelo
{
    public class CarroManobrado
    {
        public long Id { get; set; }
        public long IdCarro { get; set; }
        public long IdManobrista { get; set; }
        public Carro Carro { get; set; }
        public Manobrista Manobrista { get; set; }

    }
}
