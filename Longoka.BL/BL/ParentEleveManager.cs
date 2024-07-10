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
    public class ParentEleveManager : IParentEleveManager
    {
        private readonly IProvider<ParentEleves, Guid> _provider;

        public ParentEleveManager(IProvider<ParentEleves, Guid> provider)
        {
            _provider = provider;
        }

        public bool CreateParent(ParentEleves parent)
        {
          
            try
            {
                _provider.Create(parent);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteParent(Guid id)
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

        public ParentEleves GetParentById(Guid id)
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

        public List<ParentEleves> GetParentList()
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

        public void UpdateParent(ParentEleves parent)
        {
            try
            {
                _provider.Update(parent);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
