using Longoka.Domain.DAO;

namespace Longoka.BL.Interfaces
{
    public interface ICoursManager
    {
        Task<StatusResponse> CreateCours(Cours cours);
        Task<IEnumerable<Cours>> GetCoursList();
        Task<StatusResponse> DeleteCours(int id);
        Task<StatusResponse> UpdateCours(Cours cours);
        Task<Cours> GetCoursById(int id);
    }
}
