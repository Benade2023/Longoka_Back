using Longoka.Domain.DAO;

namespace Longoka.BL.Interfaces
{
    public interface IEleveManager
    {
        Task<StatusResponse> CreateEleve(Eleve eleve);
        Task<IEnumerable<Eleve>> GetEleveList();
        Task<StatusResponse> DeleteEleve(int id);
        Task<StatusResponse> UpdateEleve(Eleve eleve);
        Task<Eleve> GetEleveById(int id);
    }
}
