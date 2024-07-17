
using Longoka.BL.Interfaces;
using Longoka.Domain.DAO;
using Longoka.Domain.Interfaces;

namespace Longoka.BL.BL
{
    public class EleveCoursManager : IEleveCoursManager
    {
        private ITableIntermediare<Eleve_Cours> _intermediare;

        public EleveCoursManager(ITableIntermediare<Eleve_Cours> intermediare)
        {
            _intermediare = intermediare;
        }
        public async Task<bool> InsertIDEleveAndCours(Eleve_Cours classe)
        {
            try
            {
                var status = await _intermediare.InsertDataOfIntermediareTable(classe);
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
