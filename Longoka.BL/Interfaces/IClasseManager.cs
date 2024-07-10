using Longoka.Domain.DAO;

namespace Longoka.BL.Interfaces
{
    public interface IClasseManager
    {
        bool CreateClasse(Classes classe);
        List<Classes> GetClasseList();
        void DeleteClasse(Guid id);
        void UpdateClasse(Classes classe);
        Classes GetClasseById(Guid id);
    }
}
