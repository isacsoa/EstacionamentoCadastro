using EstacionamentoCadastro.Data;
using EstacionamentoCadastro.Modelo;
using EstacionamentoCadastro.Modelo.Core;
using Microsoft.Extensions.Options;
using System;

namespace EstacionamentoCadastro.Business
{
    public class CarroBLL : BaseBLL<Carro, long>
    {
        private readonly IOptions<Parametros> _connectionString;
        public new CarroData data { get; set; }

        public CarroBLL(IOptions<Parametros> connectionString
            )
            : base(new CarroData(connectionString))
        {
            _connectionString = connectionString;
            data = new CarroData(_connectionString);
        }

    }
}
