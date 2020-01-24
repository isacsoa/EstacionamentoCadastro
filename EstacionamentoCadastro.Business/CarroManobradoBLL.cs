using EstacionamentoCadastro.Data;
using EstacionamentoCadastro.Modelo;
using EstacionamentoCadastro.Modelo.Core;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

namespace EstacionamentoCadastro.Business
{
    public class CarroManobradoBLL : BaseBLL<CarroManobrado, long>
    {
        private readonly IOptions<Parametros> _connectionString;
        public new CarroManobradoData data { get; set; }
        private readonly CarroBLL carroBLL;
        private readonly ManobristaBLL manobristaBLL;

        public CarroManobradoBLL(IOptions<Parametros> connectionString,
            CarroBLL carroBLL,
            ManobristaBLL manobristaBLL
            )
            : base(new CarroManobradoData(connectionString))
        {
            _connectionString = connectionString;
            data = new CarroManobradoData(_connectionString);
            this.carroBLL = carroBLL;
            this.manobristaBLL = manobristaBLL;
        }

        public override List<CarroManobrado> Listar()
        {
            var list = base.Listar();

            foreach (var item in list)
            {
                item.Carro = carroBLL.ObterPorId(item.IdCarro);
                item.Manobrista = manobristaBLL.ObterPorId(item.IdManobrista);
            }

            return list;
        }
    }
}
