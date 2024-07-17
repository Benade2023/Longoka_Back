using Longoka.BL.Interfaces;
using Longoka.Domain.DAO;
using Longoka.Domain.Interfaces;

namespace Longoka.BL.BL
{
    public class ParentEleveManager : IParentEleveManager
    {
        private readonly IProvider<ParentEleve, int> _provider;

        public ParentEleveManager(IProvider<ParentEleve, int> provider)
        {
            _provider = provider;
        }

        public async Task<StatusResponse> CreateParent(ParentEleve parent)
        {
            if (string.IsNullOrEmpty(parent.NomParent))
            {
                throw new Exception("Le nom de  est obligatoire");
            }
            try
            {
                var statut = await _provider.Create(parent);
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

        public async Task<StatusResponse> DeleteParent(int id)
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

        public async Task<ParentEleve> GetParentById(int id)
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

        public async Task<IEnumerable<ParentEleve>> GetParentList()
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

        public async Task<StatusResponse> UpdateParent(ParentEleve parent)
        {
            try
            {
                var statut = await _provider.Update(parent);
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
