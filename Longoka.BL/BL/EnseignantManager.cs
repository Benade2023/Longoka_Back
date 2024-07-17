using Longoka.BL.Interfaces;
using Longoka.Domain.DAO;
using Longoka.Domain.Interfaces;

namespace Longoka.BL.BL
{
    public class EnseignantManager : IPersonnelEnseignantManager
    {
        private readonly IProvider<Enseignant, int> _provider;

        public EnseignantManager(IProvider<Enseignant, int> provider)
        {
            _provider = provider;
        }

        public async Task<StatusResponse> CreateEnseignant(Enseignant enseignant)
        {
            try
            {
                var statut = await _provider.Create(enseignant);
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

        public async Task<StatusResponse> DeleteEnseignant(int id)
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

        public async Task<Enseignant> GetEnseignantById(int id)
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

        public async Task<IEnumerable<Enseignant>> GetEnseignantList()
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

        public async Task<StatusResponse> UpdateEnseignant(Enseignant enseignant)
        {
            try
            {
                var statut = await _provider.Update(enseignant);
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
