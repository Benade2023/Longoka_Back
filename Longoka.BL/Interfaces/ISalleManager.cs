
using Longoka.Domain.DAO;

namespace Longoka.BL.Interfaces
{
    public interface ISalleManager
    {
        Task<StatusResponse> CreateSalle(Salle salle);
        Task<IEnumerable<Salle>> GetSalleList();
        Task<StatusResponse> DeleteSalle(int id);
        Task<StatusResponse> UpdateSalle(Salle salle);
        Task<Salle> GetSalleById(int id);
    }
}
