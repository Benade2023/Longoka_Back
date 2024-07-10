using Longoka.Domain.DAO;

namespace Longoka.BL.Interfaces
{
    public interface IParentEleveManager
    {
        bool CreateParent(ParentEleves parent);
        List<ParentEleves> GetParentList();
        void DeleteParent(Guid id);
        void UpdateParent(ParentEleves parent);
        ParentEleves GetParentById(Guid id);
    }
}
