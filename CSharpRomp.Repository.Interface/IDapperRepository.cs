using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharpRomp.Repository.Interface
{
    public interface IDapperRepository
    {
        Task<T> GetRecord<T>(string sql, object parameters = null);
        Task<IEnumerable<T>> GetRecords<T>(string sql, object parameters = null);
    }
}