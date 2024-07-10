using Longoka.Domain.DAO;

namespace Longoka.BL.Interfaces
{
    public interface IEleveManager
    {
        bool CreateEleve(Eleves eleve);
        List<Eleves> GetEleveList();
        void DeleteEleve(Guid id);
        void UpdateEleve(Eleves eleve);
        Eleves GetEleveById(Guid id);
    }
}
