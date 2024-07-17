using Longoka.BL.Interfaces;
using Longoka.Domain.DAO;
using Longoka.Domain.Interfaces;


namespace Longoka.BL.BL
{
    public class UserManager : IUserManager
    {
        private readonly IProvider<User, int> _provider;

        public UserManager(IProvider<User, int> provider)
        {
            _provider = provider;
        }

        public bool CreateUser(User user)
        {
          
            try
            {
                _provider.Create(user);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteUser(int id)
        {
            try
            {
                _provider.Delete(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public User GetUserById(int id)
        {
            try
            {
                return new User();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<User> GetUserList()
        {
            try
            {
                return new List<User>();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateUser(User user)
        {
            try
            {
                _provider.Update(user);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
