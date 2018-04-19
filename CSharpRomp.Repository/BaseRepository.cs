using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using CSharpRomp.Repository.Interface;
namespace CSharpRomp.Repository
{
    public class BaseRepository: IDapperRepository
    {
        private string ConnectionString;
        public BaseRepository(string Connectionstring)
        {
            this.ConnectionString = Connectionstring;
        }
        public async Task<IEnumerable<T>> GetRecords<T>(string sql, object parameters = null)
        {
            IEnumerable<T> records = default(IEnumerable<T>);
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.StatisticsEnabled = true;
                await connection.OpenAsync();

                try
                {
                    records = await connection.QueryAsync<T>(sql, parameters);
                }
                catch (Exception originalException)
                {
                    throw AddAdditionalInfoToException(originalException, $"Error: GetRecords: {typeof(T).Name}", sql, parameters);
                }

                var stats = connection.RetrieveStatistics();
            }

            return records;
        }

        public async Task<T> GetRecord<T>(string sql, object parameters = null)
        {
            T record = default(T);

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.StatisticsEnabled = true;
                await connection.OpenAsync();

                try
                {
                    record = await connection.QueryFirstOrDefaultAsync<T>(sql, parameters);
                }
                catch (Exception originalException)
                {
                    throw AddAdditionalInfoToException(originalException, "Error: GetRecord: " + typeof(T).Name, sql, parameters);
                }

                var stats = connection.RetrieveStatistics();
            }

            return record;
        }

        private Exception AddAdditionalInfoToException(Exception originalException, string message, string sql, object parameters = null)
        {
            var additionalInfoException = new Exception(message, originalException);
            additionalInfoException.Data.Add("SQL", sql);
            var props = parameters.GetType().GetProperties();
            foreach (var prop in props)
            {
                additionalInfoException.Data.Add(prop.Name, prop.GetValue(parameters));
            }
            return additionalInfoException;
        }
    }
}