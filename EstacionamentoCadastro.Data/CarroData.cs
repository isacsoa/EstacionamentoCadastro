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
    public class CarroData : IDataAccessObject<Carro, long>
    {
        private SqlConnection connection;

        public CarroData(IOptions<Parametros> connectionString)
        {
            connection = new SqlConnection(connectionString.Value.EstacionamentoCadastro);
        }

        public void Atualizar(Carro model)
        {
            connection.Execute("[dbo].[uspUCarro]", new
            {
                model.Id,
                model.Marca,
                model.Modelo,
                model.Placa
            }, commandType: CommandType.StoredProcedure);
        }

        public void Excluir(long id)
        {
            connection.Execute("[dbo].[uspDCArro]", new
            {
                Id = id
            }, commandType: CommandType.StoredProcedure);
        }

        public void Incluir(Carro model)
        {
            model.Id = connection.ExecuteScalar<long>("[dbo].[uspICarro]", new
            {
                model.Marca,
                model.Modelo,
                model.Placa
            }, commandType: CommandType.StoredProcedure);
        }

        public List<Carro> Listar()
        {
            var list = connection.Query<Carro>("[dbo].[uspSCarro]", commandType: CommandType.StoredProcedure).ToList();

            return list;
        }

        public Carro ObterPorId(long id)
        {
            return connection.QuerySingle<Carro>("[dbo].[uspSCarroPorId]",
                new { Id = id },
                commandType: CommandType.StoredProcedure);
        }
    }
}
