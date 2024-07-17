using Longoka.Domain.DAO;

namespace Longoka.BL.Interfaces
{
    public interface IMatiereManager
    {
        Task<StatusResponse> CreateMatiere(Matiere matiere);
        Task<IEnumerable<Matiere>> GetMatiereList();
        Task<StatusResponse> DeleteMatiere(int id);
        Task<StatusResponse> UpdateMatiere(Matiere matiere);
        Task<Matiere> GetMatiereById(int id);
    }
}
