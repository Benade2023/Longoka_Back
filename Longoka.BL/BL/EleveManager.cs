using Longoka.BL.Interfaces;
using Longoka.Domain.DAO;
using Longoka.Domain.Interfaces;


namespace Longoka.BL.BL
{
    public class EleveManager : IEleveManager
    {
        private readonly IProvider<Eleve, int> _provider;

        public EleveManager(IProvider<Eleve, int> provider)
        {
            _provider = provider;
        }

        public async Task<StatusResponse> CreateEleve(Eleve eleve)
        {
            try
            {
                if (string.IsNullOrEmpty(eleve.Nom))
                {
                    throw new Exception("Le nom de l'élève est requis.");
                }

                var statut = await _provider.Create(eleve);
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
        public async Task<StatusResponse> DeleteEleve(int id)
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

        public async Task<Eleve> GetEleveById(int id)
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

        public async Task<IEnumerable<Eleve>> GetEleveList()
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

        public async Task<StatusResponse> UpdateEleve(Eleve eleve)
        {
            try
            {
                var statut = await _provider.Update(eleve);
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
