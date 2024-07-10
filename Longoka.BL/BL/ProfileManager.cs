using Longoka.BL.Interfaces;
using Longoka.Domain.DAO;
using Longoka.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longoka.BL.BL
{
    public class ProfileManager : IProfileManager
    {
        private readonly IProvider<Profiles, Guid> _provider;

        public ProfileManager(IProvider<Profiles, Guid> provider)
        {
            _provider = provider;
        }

        public bool CreateProfile(Profiles profile)
        {
            if (string.IsNullOrEmpty(profile.ProfileName))
            {
                throw new Exception("Le nom du profile est obligatoire");
            }
            try
            {
                _provider.Create(profile);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteProfile(Guid id)
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

        public Profiles GetProfileById(Guid id)
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

        public List<Profiles> GetProfileList()
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

        public void UpdateProfile(Profiles profile)
        {
            try
            {
                _provider.Update(profile);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
