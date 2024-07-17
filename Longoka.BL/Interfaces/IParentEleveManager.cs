using Longoka.Domain.DAO;

namespace Longoka.BL.Interfaces
{
    public interface IParentEleveManager
    {
        Task<StatusResponse> CreateParent(ParentEleve parent);
        Task<IEnumerable<ParentEleve>> GetParentList();
        Task<StatusResponse> DeleteParent(int id);
        Task<StatusResponse> UpdateParent(ParentEleve parent);
        Task<ParentEleve> GetParentById(int id);
    }
}
