using Longoka.Domain.DAO;

namespace Longoka.BL.Interfaces
{
    public interface IPersonnelEnseignantManager
    {
        Task<StatusResponse> CreateEnseignant(Enseignant enseignant);
        Task<IEnumerable<Enseignant>> GetEnseignantList();
        Task<StatusResponse> DeleteEnseignant(int id);
        Task<StatusResponse> UpdateEnseignant(Enseignant enseignant);
        Task<Enseignant> GetEnseignantById(int id);
    }
}
