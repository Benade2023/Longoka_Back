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
    public class EleveManager : IEleveManager
    {
        private readonly IProvider<Eleves, Guid> _provider;

        public EleveManager(IProvider<Eleves, Guid> provider)
        {
            _provider = provider;
        }

        public bool CreateEleve(Eleves eleve)
        {
           
            try
            {
                _provider.Create(eleve);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteEleve(Guid id)
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

        public Eleves GetEleveById(Guid id)
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

        public List<Eleves> GetEleveList()
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

        public void UpdateEleve(Eleves eleve)
        {
            try
            {
                _provider.Update(eleve);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
