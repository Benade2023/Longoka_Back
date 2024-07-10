using Longoka.BL.Interfaces;
using Longoka.Domain.DAO;
using Longoka.Domain.Interfaces;

namespace Longoka.BL.BL
{
    public class EcoleManager : IEcoleManager
    {
        private readonly IProvider<Ecoles, Guid> _provider;

        public EcoleManager(IProvider<Ecoles, Guid> provider)
        {
            _provider = provider;
        }
        /// <summary>
        /// Creer une école
        /// </summary>
        /// <param name="ecole"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool CreateEcole(Ecoles ecole)
        {
            if(string.IsNullOrEmpty(ecole.NameEcole))
            {
                throw new Exception("Le nom de  est obligatoire");
            }
            try
            {
                _provider.Create(ecole);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Suprimé une école
        /// </summary>
        /// <param name="id"></param>
        public void DeleteEcole(Guid id)
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
        /// <summary>
        /// Récupérer une seul école par son Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Ecoles GetEcoleById(Guid id)
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
        /// <summary>
        /// Récupérer la liste de toutes les écoles
        /// </summary>
        /// <returns></returns>
        public List<Ecoles> GetEcoleList()
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
        /// <summary>
        /// Modification d'une école
        /// </summary>
        /// <param name="ecole"></param>
        public void UpdateEcole(Ecoles ecole)
        {
            try
            {
                _provider.Update(ecole);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
