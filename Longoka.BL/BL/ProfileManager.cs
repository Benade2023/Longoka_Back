using Longoka.BL.Interfaces;
using Longoka.Domain.DAO;
using Longoka.Domain.Interfaces;
using static System.Formats.Asn1.AsnWriter;

namespace Longoka.BL.BL
{
    public class ProfileManager : IProfileManager
    {
        private readonly IProvider<Profile, int> _provider;

        public ProfileManager(IProvider<Profile, int> provider)
        {
            _provider = provider;
        }

        public async Task<StatusResponse> CreateProfile(Profile profile)
        {
            try
            {
                var statut = await _provider.Create(profile);
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

        public async Task<StatusResponse> DeleteProfile(int id)
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

        public async Task<Profile> GetProfileById(int id)
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

        public async Task<IEnumerable<Profile>> GetProfileList()
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

        public async Task<StatusResponse> UpdateProfile(Profile profile)
        {
            try
            {
                var statut = await _provider.Update(profile);
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
