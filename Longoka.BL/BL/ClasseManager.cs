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
    public class ClasseManager : IClasseManager
    {
        private readonly IProvider<Classes, Guid> _provider;

        public ClasseManager(IProvider<Classes, Guid> provider)
        {
            _provider = provider;
        }

        public bool CreateClasse(Classes classe)
        {
            if (string.IsNullOrEmpty(classe.ClasseName))
            {
                throw new Exception("Le nom de la classe est obligatoire");
            }
            try
            {
                _provider.Create(classe);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteClasse(Guid id)
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

        public Classes GetClasseById(Guid id)
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

        public List<Classes> GetClasseList()
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

        public void UpdateClasse(Classes classe)
        {
            try
            {
                _provider.Update(classe);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
