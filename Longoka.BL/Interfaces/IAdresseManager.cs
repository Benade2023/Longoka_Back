
using Longoka.Domain.DAO;

namespace Longoka.BL.Interfaces
{
    public interface IAdresseManager
    {
        Task<StatusResponse> CreateAdresse(Adresse adresse);
        Task<IEnumerable<Adresse>> GetAdresseList();
        Task<StatusResponse> DeleteAdresse(int id);
        Task<StatusResponse> UpdateAdresse(Adresse adresse);
        Task<Adresse> GetAdresseById(int id);
    }
}
