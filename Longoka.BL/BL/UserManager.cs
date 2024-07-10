using Longoka.BL.Interfaces;
using Longoka.Domain.DAO;
using Longoka.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Longoka.BL.BL
{
    public class UserManager : IUserManager
    {
        private readonly IProvider<Users, Guid> _provider;

        public UserManager(IProvider<Users, Guid> provider)
        {
            _provider = provider;
        }

        public bool CreateUser(Users user)
        {
            if (string.IsNullOrEmpty(user.CompletName))
            {
                throw new Exception("Le nom  est obligatoire");
            }
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

        public void DeleteUser(Guid id)
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

        public Users GetUserById(Guid id)
        {
            try
            {
                return _provider.GetById(id);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Users> GetUserList()
        {
            try
            {
                return _provider.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateUser(Users user)
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
