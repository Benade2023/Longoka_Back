
using Longoka.Domain.DAO;

namespace Longoka.BL.Interfaces
{
    public interface IEleveCoursManager
    {
        Task<bool> InsertIDEleveAndCours(Eleve_Cours classe);
    }
}
