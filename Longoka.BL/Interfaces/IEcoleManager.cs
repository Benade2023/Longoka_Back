using Longoka.Domain.DAO;

namespace Longoka.BL.Interfaces
{
    public interface IEcoleManager
    {
        bool CreateEcole(Ecoles ecole);
        List<Ecoles> GetEcoleList();
        void DeleteEcole(Guid id);
        void UpdateEcole(Ecoles ecole);
        Ecoles GetEcoleById(Guid id);
    }
}
