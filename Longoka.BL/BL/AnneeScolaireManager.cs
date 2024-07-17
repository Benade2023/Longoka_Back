using Longoka.BL.Interfaces;
using Longoka.Domain.DAO;
using Longoka.Domain.Interfaces;

namespace Longoka.BL.BL
{
    public class AnneeScolaireManager : IAnneeScolaireManager
    {
        private readonly IProvider<AnneeScolaires, int> _provider;
        public AnneeScolaireManager(IProvider<AnneeScolaires, int> provider)
        {
            _provider = provider;
        }
        public async Task<StatusResponse> CreateAnneeScolaire(AnneeScolaires anneeScolaire)
        {
            if (string.IsNullOrEmpty(anneeScolaire.AnneeScolaire))
            {
                throw new Exception("L\'année scolaire est obligatoire");
            }
            try
            {
                var statut = await _provider.Create(anneeScolaire);
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

        public async Task<StatusResponse> DeleteAnneeScolaire(int id)
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

        public async Task<AnneeScolaires> GetAnneeScolaireById(int id)
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

        public async Task<IEnumerable<AnneeScolaires>> GetAnneeScolaireList()
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

        public async Task<StatusResponse> UpdateAnneeScolaire(AnneeScolaires anneeScolaire)
        {
            try
            {
               var statut = await _provider.Update(anneeScolaire);
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
