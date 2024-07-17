

using Longoka.Domain.DAO;

namespace Longoka.BL.Interfaces
{
    public interface IEtablissementMatiereEnseignantManager
    {
        Task<bool> InertIDEtablissmentMatiereEnseignant(Etablissement_Enseignant_Matiere classe);
    }
}
