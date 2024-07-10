using Longoka.BL.Interfaces;
using Longoka.Domain.DAO;
using Longoka.Domain.Interfaces;

namespace Longoka.BL.BL
{
    public class AnneeScolaireManager : IAnneeScolaireManager
    {
        private readonly IProvider<AnneeScolaires, Guid> _provider;

        public AnneeScolaireManager(IProvider<AnneeScolaires, Guid> provider)
        {
            _provider = provider;
        }

        public bool CreateAnneeScolaire(AnneeScolaires anneeScolaire)
        {
            if (string.IsNullOrEmpty(anneeScolaire.AnneeScolaire))
            {
                throw new Exception("L\'année scolaire est obligatoire");
            }
            try
            {
                _provider.Create(anneeScolaire);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteAnneeScolaire(Guid id)
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

        public AnneeScolaires GetAnneeScolaireById(Guid id)
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

        public List<AnneeScolaires> GetAnneeScolaireList()
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

        public void UpdateAnneeScolaire(AnneeScolaires anneeScolaire)
        {
            try
            {
                _provider.Update(anneeScolaire);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
