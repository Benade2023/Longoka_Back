
using Longoka.BL.Interfaces;
using Longoka.Domain.DAO;
using Longoka.Domain.Interfaces;

namespace Longoka.BL.BL
{
    public class Etablissement_AnneeScolaireManager : IEtablissementAnneeScolaireManager
    {
        private ITableIntermediare<AnneeScolaire_Etablissement> _instance;

        public Etablissement_AnneeScolaireManager(ITableIntermediare<AnneeScolaire_Etablissement> instance)
        {
            _instance = instance;
        }
        public async Task<bool> InertIDEtablissmentAndAnneeScolaire(AnneeScolaire_Etablissement classe)
        {
            try
            {
                var status = await _instance.InsertDataOfIntermediareTable(classe);
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
