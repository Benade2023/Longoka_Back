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
    public class PersonnelEnseignantManager : IPersonnelEnseignantManager
    {
        private readonly IProvider<PersonnelEnseignants, Guid> _provider;

        public PersonnelEnseignantManager(IProvider<PersonnelEnseignants, Guid> provider)
        {
            _provider = provider;
        }

        public bool CreateEnseignant(PersonnelEnseignants enseignant)
        {
            try
            {
                _provider.Create(enseignant);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteEnseignant(Guid id)
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

        public PersonnelEnseignants GetEnseignantById(Guid id)
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

        public List<PersonnelEnseignants> GetEnseignantList()
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

        public void UpdateEnseignant(PersonnelEnseignants enseignant)
        {
            try
            {
                _provider.Update(enseignant);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
