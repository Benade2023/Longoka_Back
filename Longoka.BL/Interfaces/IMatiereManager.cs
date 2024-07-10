using Longoka.Domain.DAO;

namespace Longoka.BL.Interfaces
{
    public interface IMatiereManager
    {
        bool CreateMatiere(Matieres matiere);
        List<Matieres> GetMatiereList();
        void DeleteMatiere(Guid id);
        void UpdateMatiere(Matieres matiere);
        Matieres GetMatiereById(Guid id);
    }
}
