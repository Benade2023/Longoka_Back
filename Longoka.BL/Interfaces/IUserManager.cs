using Longoka.Domain.DAO;

namespace Longoka.BL.Interfaces
{
    public interface IUserManager
    {
        bool CreateUser(User user);
        List<User> GetUserList();
        void DeleteUser(int id);
        void UpdateUser(User user);
        User GetUserById(int id);
    }
}
