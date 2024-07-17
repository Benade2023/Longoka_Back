using Longoka.Domain.DAO;

namespace Longoka.BL.Interfaces
{
    public interface IEtablissementManager
    {
        Task<StatusResponse> CreateEtablissement(Etablissement ecole);
        Task<IEnumerable<Etablissement>> GetEtablissementList();
        Task<StatusResponse> DeleteEtablissement(int id);
        Task<StatusResponse> UpdateEtablissement(Etablissement ecole);
        Task<Etablissement> GetEtablissementById(int id);
    }
}
