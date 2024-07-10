using Dapper;
using Longoka.Domain.DAO;
using Longoka.Domain.Interfaces;
using Npgsql;

namespace Longoka.Dapper.Providers
{
    public class ClasseProviderDapper : IProvider<Classes, Guid>
    {
        private string _connexionString = string.Empty;
        private const string TABLENAME = "Classes";
        public ClasseProviderDapper(string connexionString)
        {
            _connexionString=connexionString;
        }
        public void Create(Classes classe)
        {
            try
            {
                var sqlRequette = $"INSERT INTO {TABLENAME} (niveau, classename, ecoleid) " +
                    $"VALUES (@niveau, @classename, @ecoleid)";
                using var dapperConnexion = new NpgsqlConnection(_connexionString);
                dapperConnexion.ExecuteScalar<Classes>(sqlRequette, classe);
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
                var sqlRequette = $"DELETE FROM {TABLENAME} WHERE ClasseId = {id}";
                using var dapperConnexion = new NpgsqlConnection(_connexionString);
                dapperConnexion.Query(sqlRequette, id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Classes> GetAll()
        {
            try
            {
                var sqlRequette = $"SELECT * FROM {TABLENAME}";
                using var dapperConnexion = new NpgsqlConnection(_connexionString);
                var result = dapperConnexion.Query<Classes>(sqlRequette);
                return result.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Classes GetById(Guid id)
        {
            try
            {
                var sqlRequette = $"SELECT * FROM {TABLENAME} WHERE ClasseId = {id}";
                using var dapperConnexion = new NpgsqlConnection(_connexionString);
                var result = dapperConnexion.QueryFirstOrDefault<Classes>(sqlRequette);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(Classes classe)
        {
            try
            {
                var sqlRequette = $"UPDATE {TABLENAME} SET niveau=@niveau, classename=@classename, ecoleid=@ecoleid";
                using var dapperConnexion = new NpgsqlConnection(_connexionString);
                dapperConnexion.ExecuteScalar(sqlRequette, classe);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
