using Longoka.Domain.DAO;

namespace Longoka.BL.Interfaces
{
    public interface IAnneeScolaireManager
    {
        Task<StatusResponse> CreateAnneeScolaire(AnneeScolaires anneeScolaire);
        Task<IEnumerable<AnneeScolaires>> GetAnneeScolaireList();
        Task<StatusResponse> DeleteAnneeScolaire(int id);
        Task<StatusResponse> UpdateAnneeScolaire(AnneeScolaires anneeScolaire);
        Task<AnneeScolaires> GetAnneeScolaireById(int id);
    }
}
