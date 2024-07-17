using Longoka.Domain.DAO;

namespace Longoka.BL.Interfaces
{
    public interface IProfileManager
    {
        Task<StatusResponse> CreateProfile(Profile profile);
        Task<IEnumerable<Profile>> GetProfileList();
        Task<StatusResponse> DeleteProfile(int id);
        Task<StatusResponse> UpdateProfile(Profile profile);
        Task<Profile> GetProfileById(int id);
    }
}
