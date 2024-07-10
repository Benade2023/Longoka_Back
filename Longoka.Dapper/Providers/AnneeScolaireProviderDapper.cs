using Dapper;
using Longoka.Domain.DAO;
using Longoka.Domain.Interfaces;
using Npgsql;

namespace Longoka.Dapper.Providers
{
    public class AnneeScolaireProviderDapper : IProvider<AnneeScolaires, Guid>
    {
        private string _connexionString = string.Empty;
        private const string TABLENAME = "AnneeScolaires";
        public AnneeScolaireProviderDapper(string connexionString)
        {
            _connexionString=connexionString;
        }
        public void Create(AnneeScolaires anneeScolaire)
        {
            try
            {
                var sqlRequette = $"INSERT INTO {TABLENAME} (anneescolaire, datedebut, datefin, description, ecoleid) " +
                    $"VALUES (@anneescolaire, @datedebut, @datefin, @description, @ecoleid) ";
                using var dapperConnexion = new NpgsqlConnection(_connexionString);
                dapperConnexion.ExecuteScalar<AnneeScolaires>(sqlRequette, anneeScolaire);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(Guid id)
        {
            try
            {
                var sqlRequette = $"DELETE FROM {TABLENAME} WHERE AnneeId = {id}";
                using var dapperConnexion = new NpgsqlConnection(_connexionString);
                dapperConnexion.Query(sqlRequette, id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<AnneeScolaires> GetAll()
        {
            try
            {
                var sqlRequette = $"SELECT * FROM {TABLENAME}";
                using var dapperConnexion = new NpgsqlConnection(_connexionString);
                var result = dapperConnexion.Query<AnneeScolaires>(sqlRequette) ;
                return result.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public AnneeScolaires GetById(Guid id)
        {
            try
            {
                var sqlRequette = $"SELECT * FROM {TABLENAME}  WHERE AnneeId = {id}";
                using var dapperConnexion = new NpgsqlConnection(_connexionString);
                var result = dapperConnexion.QueryFirstOrDefault<AnneeScolaires>(sqlRequette);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(AnneeScolaires anneeScolaire)
        {
            try
            {
                var sqlRequette = $"UPDATE {TABLENAME} SET anneescolaire=@anneescolaire, datedebut=@datedebut, datefin=@datefin, description=@description, ecoleid=@ecoleid";
                using var dapperConnexion = new NpgsqlConnection(_connexionString) ;
                dapperConnexion.ExecuteScalar(sqlRequette, anneeScolaire);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
