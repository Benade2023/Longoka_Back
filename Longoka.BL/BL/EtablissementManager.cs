using Longoka.BL.Interfaces;
using Longoka.Domain.DAO;
using Longoka.Domain.Interfaces;

namespace Longoka.BL.BL
{
    public class EtablissementManager : IEtablissementManager
    {
        private readonly IProvider<Etablissement, int> _provider;

        public EtablissementManager(IProvider<Etablissement, int> provider)
        {
            _provider = provider;
        }
        /// <summary>
        /// Creer une école
        /// </summary>
        /// <param name="ecole"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<StatusResponse> CreateEtablissement(Etablissement ecole)
        {
            if(string.IsNullOrEmpty(ecole.EtablissementName))
            {
                throw new Exception("Le nom de  est obligatoire");
            }
            try
            {
              var statut =  await _provider.Create(ecole);
                if(statut.Success)
                {
                    return statut;
                }
                return new StatusResponse()
                {
                    Success = false,
                    Message = "Échec d'enrégistrement.",
                };
            }
            catch (Exception ex)
            {
                return new StatusResponse()
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }
        /// <summary>
        /// Suprimé une école
        /// </summary>
        /// <param name="id"></param>
        public async Task<StatusResponse> DeleteEtablissement(int id)
        {
            try
            {
               var statut = await _provider.Delete(id);
                if (statut.Success)
                {
                    return statut;
                }
                return new StatusResponse() { Success = false, Message = "Echec de supression" };
            }
            catch (Exception ex)
            {
                return new StatusResponse()
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }
        /// <summary>
        /// Récupérer une seul école par son Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Etablissement> GetEtablissementById(int id)
        {
            try
            {
                var result = await _provider.GetById(id);
                if (result != null)
                {
                    return result;
                }
                return null!;

            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Récupérer la liste de toutes les écoles
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Etablissement>> GetEtablissementList()
        {
            try
            {
               var result = await  _provider.GetAll();
                if (result == null)
                {
                    return [];
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Modification d'une école
        /// </summary>
        /// <param name="ecole"></param>
        public async Task<StatusResponse> UpdateEtablissement(Etablissement ecole)
        {
            try
            {
               var statut = await _provider.Update(ecole);
                if (statut.Success)
                {
                      return statut;
                }
                return new StatusResponse() { Success= false, Message="Echèc de mise à jour."};
            }
            catch (Exception ex)
            {
                return new StatusResponse() { Success= false, Message=ex.Message};
                
            }
        }
    }
}
