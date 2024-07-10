using Longoka.Domain.DAO;

namespace Longoka.BL.Interfaces
{
    public interface IProfileManager
    {
        bool CreateProfile(Profiles profile);
        List<Profiles> GetProfileList();
        void DeleteProfile(Guid id);
        void UpdateProfile(Profiles profile);
        Profiles GetProfileById(Guid id);
    }
}
