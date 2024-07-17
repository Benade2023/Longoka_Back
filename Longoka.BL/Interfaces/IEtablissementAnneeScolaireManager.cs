
using Longoka.Domain.DAO;

namespace Longoka.BL.Interfaces
{
    public interface IEtablissementAnneeScolaireManager
    {
        Task<bool> InertIDEtablissmentAndAnneeScolaire(AnneeScolaire_Etablissement classe);
    }
}
