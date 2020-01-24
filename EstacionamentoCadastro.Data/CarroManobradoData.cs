using Dapper;
using EstacionamentoCadastro.Data.Interface;
using EstacionamentoCadastro.Modelo;
using EstacionamentoCadastro.Modelo.Core;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace EstacionamentoCadastro.Data
{
    public class CarroManobradoData : IDataAccessObject<CarroManobrado, long>
    {
        private SqlConnection connection;

        public CarroManobradoData(IOptions<Parametros> connectionString)
        {
            connection = new SqlConnection(connectionString.Value.EstacionamentoCadastro);
        }

        public void Atualizar(CarroManobrado model)
        {
            connection.Execute("[dbo].[uspUCarroManobrado]", new
            {
                model.Id,
                model.IdCarro,
                model.IdManobrista
            }, commandType: CommandType.StoredProcedure);
        }

        public void Excluir(long id)
        {
            connection.Execute("[dbo].[uspDCarroManobrado]", new
            {
                Id = id
            }, commandType: CommandType.StoredProcedure);
        }

        public void Incluir(CarroManobrado model)
        {
            model.Id = connection.ExecuteScalar<long>("[dbo].[uspICarroManobrado]", new
            {
                model.IdCarro,
                model.IdManobrista
            }, commandType: CommandType.StoredProcedure);
        }

        public List<CarroManobrado> Listar()
        {
            var list = connection.Query<CarroManobrado>("[dbo].[uspSCarroManobrado]", commandType: CommandType.StoredProcedure).ToList();

            return list;
        }

        public CarroManobrado ObterPorId(long id)
        {
            return connection.QuerySingle<CarroManobrado>("[dbo].[uspSCarroManobradoPorId]",
                new { Id = id },
                commandType: CommandType.StoredProcedure);
        }
    }
}
