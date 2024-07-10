using Longoka.Domain.DAO;

namespace Longoka.BL.Interfaces
{
    public interface IUserManager
    {
        bool CreateUser(Users user);
        List<Users> GetUserList();
        void DeleteUser(Guid id);
        void UpdateUser(Users user);
        Users GetUserById(Guid id);
    }
}
