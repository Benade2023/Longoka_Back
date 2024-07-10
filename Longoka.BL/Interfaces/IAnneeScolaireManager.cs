using Longoka.Domain.DAO;

namespace Longoka.BL.Interfaces
{
    public interface IAnneeScolaireManager
    {
        bool CreateAnneeScolaire(AnneeScolaires anneeScolaire);
        List<AnneeScolaires> GetAnneeScolaireList();
        void DeleteAnneeScolaire(Guid id);
        void UpdateAnneeScolaire(AnneeScolaires anneeScolaire);
        AnneeScolaires GetAnneeScolaireById(Guid id);
    }
}
