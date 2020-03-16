using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Furiza.eCipaOnContainers.Organizacoes.WebApi.Queries
{
    internal class OrganizacoesQueryContext
    {
        private readonly IDbConnection dbConnection;
        private readonly OrganizacoesSqlConfiguration coreBusinessSqlConfiguration;

        public string DatabaseName => coreBusinessSqlConfiguration?.DatabaseName;
        public string CipasDatabaseName => coreBusinessSqlConfiguration?.CipasDatabaseName;

        public OrganizacoesQueryContext(OrganizacoesSqlConfiguration coreBusinessSqlConfiguration)
        {
            this.coreBusinessSqlConfiguration = coreBusinessSqlConfiguration ?? throw new System.ArgumentNullException(nameof(coreBusinessSqlConfiguration));
            dbConnection = new SqlConnection(coreBusinessSqlConfiguration.ConnectionString);
        }

        public IEnumerable<T1> Query<T1>(string sql, object param = null) => dbConnection.Query<T1>(sql, param);

        public async Task<IEnumerable<T1>> QueryAsync<T1>(string sql, object param = null) => await dbConnection.QueryAsync<T1>(sql, param);

        public async Task<IEnumerable<T1>> QueryAsync<T1, T2>(string sql, Func<T1, T2, T1> map, object param = null, string splitOn = "") => await dbConnection.QueryAsync(sql, map, param: param, splitOn: splitOn);

        public async Task<IEnumerable<T1>> QueryAsync<T1, T2, T3>(string sql, Func<T1, T2, T3, T1> map, object param = null, string splitOn = "") => await dbConnection.QueryAsync(sql, map, param: param, splitOn: splitOn);

        public async Task<IEnumerable<T1>> QueryAsync<T1, T2, T3, T4>(string sql, Func<T1, T2, T3, T4, T1> map, object param = null, string splitOn = "") => await dbConnection.QueryAsync(sql, map, param: param, splitOn: splitOn);

        public async Task<IEnumerable<T1>> QueryAsync<T1, T2, T3, T4, T5>(string sql, Func<T1, T2, T3, T4, T5, T1> map, object param = null, string splitOn = "") => await dbConnection.QueryAsync(sql, map, param: param, splitOn: splitOn);

        public async Task<IEnumerable<T1>> QueryAsync<T1, T2, T3, T4, T5, T6>(string sql, Func<T1, T2, T3, T4, T5, T6, T1> map, object param = null, string splitOn = "") => await dbConnection.QueryAsync(sql, map, param: param, splitOn: splitOn);
    }
}