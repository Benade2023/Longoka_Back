using Longoka.Domain.DAO;

namespace Longoka.BL.Interfaces
{
    public interface IClasseManager
    {
        Task<StatusResponse> CreateClasse(Classe classe);
        Task<IEnumerable<Classe>> GetClasseList();
        Task<StatusResponse> DeleteClasse(int id);
        Task<StatusResponse> UpdateClasse(Classe classe);
        Task<Classe> GetClasseById(int id);

    }
}
