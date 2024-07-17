
using Longoka.BL.Interfaces;
using Longoka.Domain.DAO;
using Longoka.Domain.Interfaces;

namespace Longoka.BL.BL
{
    public class AdresseManager : IAdresseManager
    {
        private readonly IProvider<Adresse, int> _provider;
        public AdresseManager(IProvider<Adresse, int> provider)
        {
            _provider = provider;
        }
        /// <summary>
        /// Creer une adresse
        /// </summary>
        /// <param name="adresse"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<StatusResponse> CreateAdresse(Adresse adresse)
        {
            try
            {
                var statut = await _provider.Create(adresse);
                if (statut.Success)
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
        /// Suprimé une adresse
        /// </summary>
        /// <param name="id"></param>
        public async Task<StatusResponse> DeleteAdresse(int id)
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
        /// Récupérer une seul adresse par son Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Adresse> GetAdresseById(int id)
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
        /// Récupérer la liste de toutes les adresses
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Adresse>> GetAdresseList()
        {
            try
            {
                var result = await _provider.GetAll();
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
        /// Modification d'une adresse
        /// </summary>
        /// <param name="ecole"></param>
        public async Task<StatusResponse> UpdateAdresse(Adresse adresse)
        {
            try
            {
                var statut = await _provider.Update(adresse);
                if (statut.Success)
                {
                    return statut;
                }
                return new StatusResponse() { Success = false, Message = "Echèc de mise à jour." };
            }
            catch (Exception ex)
            {
                return new StatusResponse() { Success = false, Message = ex.Message };

            }
        }
    }
}
