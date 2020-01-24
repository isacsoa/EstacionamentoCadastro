using EstacionamentoCadastro.Data;
using EstacionamentoCadastro.Modelo;
using EstacionamentoCadastro.Modelo.Core;
using Microsoft.Extensions.Options;
using System;

namespace EstacionamentoCadastro.Business
{
    public class ManobristaBLL : BaseBLL<Manobrista, long>
    {
        private readonly IOptions<Parametros> _connectionString;
        public new ManobristaData data { get; set; }

        public ManobristaBLL(IOptions<Parametros> connectionString
            )
            : base(new ManobristaData(connectionString))
        {
            _connectionString = connectionString;
            data = new ManobristaData(_connectionString);
        }

    }
}
