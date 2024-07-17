
using Longoka.BL.Interfaces;
using Longoka.Domain.DAO;
using Longoka.Domain.Interfaces;

namespace Longoka.BL.BL
{
    public class EtablissementMatiereEnseignantManager : IEtablissementMatiereEnseignantManager
    {
        private ITableIntermediare<Etablissement_Enseignant_Matiere> _tableIntermediare;

        public EtablissementMatiereEnseignantManager(ITableIntermediare<Etablissement_Enseignant_Matiere> tableIntermediare)
        {
            _tableIntermediare = tableIntermediare;
        }
        public async Task<bool> InertIDEtablissmentMatiereEnseignant(Etablissement_Enseignant_Matiere classe)
        {
            try
            {
                var status = await _tableIntermediare.InsertDataOfIntermediareTable(classe);
                if (status == false)
                {
                    throw new Exception("Erreur l'or de l'insertion des données.");
                }
                return status;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
