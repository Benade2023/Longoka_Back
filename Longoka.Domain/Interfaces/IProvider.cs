
using Longoka.Domain.DAO;

namespace Longoka.Domain.Interfaces
{
    public interface IProvider<T, K> where T : class
    {
        Task<StatusResponse> Create(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(K id);
        Task<StatusResponse> Update(T entity);
        Task<StatusResponse> Delete(K id);
    }
}
