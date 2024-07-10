using Longoka.Domain.DAO;

namespace Longoka.BL.Interfaces
{
    public interface IPersonnelEnseignantManager
    {
        bool CreateEnseignant(PersonnelEnseignants enseignant);
        List<PersonnelEnseignants> GetEnseignantList();
        void DeleteEnseignant(Guid id);
        void UpdateEnseignant(PersonnelEnseignants enseignant);
        PersonnelEnseignants GetEnseignantById(Guid id);
    }
}
