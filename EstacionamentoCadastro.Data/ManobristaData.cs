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
    public class ManobristaData : IDataAccessObject<Manobrista, long>
    {
        private SqlConnection connection;

        public ManobristaData(IOptions<Parametros> connectionString)
        {
            connection = new SqlConnection(connectionString.Value.EstacionamentoCadastro);
        }

        public void Atualizar(Manobrista model)
        {
            connection.Execute("[dbo].[uspUManobrista]", new
            {
                model.Id,
                model.NomeManobrista,
                model.CPF,
                model.DataNascimento
            }, commandType: CommandType.StoredProcedure);
        }

        public void Excluir(long id)
        {
            connection.Execute("[dbo].[uspDManobrista]", new
            {
                Id = id
            }, commandType: CommandType.StoredProcedure);
        }

        public void Incluir(Manobrista model)
        {
            model.Id = connection.ExecuteScalar<long>("[dbo].[uspIManobrista]", new
            {
                model.NomeManobrista,
                model.CPF,
                model.DataNascimento
            }, commandType: CommandType.StoredProcedure);
        }

        public List<Manobrista> Listar()
        {
            var list = connection.Query<Manobrista>("[dbo].[uspSManobrista]", commandType: CommandType.StoredProcedure).ToList();

            return list;
        }

        public Manobrista ObterPorId(long id)
        {
            return connection.QuerySingle<Manobrista>("[dbo].[uspSManobristaPorId]",
                new { Id = id },
                commandType: CommandType.StoredProcedure);
        }
    }
}
