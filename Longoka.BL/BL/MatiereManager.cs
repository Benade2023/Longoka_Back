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
    public class MatiereManager : IMatiereManager
    {
        private readonly IProvider<Matieres, Guid> _provider;

        public MatiereManager(IProvider<Matieres, Guid> provider)
        {
            _provider = provider;
        }

        public bool CreateMatiere(Matieres matiere)
        {
            if (string.IsNullOrEmpty(matiere.MatiereName))
            {
                throw new Exception("Le nom de la matiere est obligatoire");
            }
            try
            {
                _provider.Create(matiere);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteMatiere(Guid id)
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

        public Matieres GetMatiereById(Guid id)
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

        public List<Matieres> GetMatiereList()
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

        public void UpdateMatiere(Matieres matiere)
        {
            try
            {
                _provider.Update(matiere);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
