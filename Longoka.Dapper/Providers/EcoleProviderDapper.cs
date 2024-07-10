using Dapper;
using Longoka.Domain.DAO;
using Longoka.Domain.Interfaces;
using Npgsql;

namespace Longoka.Dapper.Providers
{
    public class EcoleProviderDapper : IProvider<Ecoles, Guid>
    {
        private string _connexionString = string.Empty;
        private const string TABLENAME = "Ecoles";
        public EcoleProviderDapper(string connexionString)
        {
            _connexionString=connexionString;
        }
        public void Create(Ecoles ecole)
        {
            try
            {
                var sqlRequette = $"INSERT INTO {TABLENAME} (nameecole, typeecole, numerorue, ruename, quartier, ville, pays, telephoneecole, emailecole, siteweb) " +
                    $"VALUES (@nameecole, @typeecole, @numerorue, @ruename, @quartier, @ville, @pays, @telephoneecole, @emailecole, @siteweb)";
                using var dapperConnexion = new NpgsqlConnection(_connexionString);
                dapperConnexion.ExecuteScalar<Ecoles>(sqlRequette, ecole);
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
                var sqlRequette = $"DELETE FROM {TABLENAME} WHERE EcoleId = {id}";
                using var dapperConnexion = new NpgsqlConnection(_connexionString);
                dapperConnexion.Query(sqlRequette, id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Ecoles> GetAll()
        {
            try
            {
                var sqlRequette = $"SELECT * FROM {TABLENAME}";
                using var dapperConnexion = new NpgsqlConnection(_connexionString);
                var result = dapperConnexion.Query<Ecoles>(sqlRequette);
                return result.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Ecoles GetById(Guid id)
        {
            try
            {
                var sqlRequette = $"SELECT * FROM {TABLENAME} WHERE EcoleId = {id}";
                using var dapperConnexion = new NpgsqlConnection(_connexionString);
                var result = dapperConnexion.QueryFirstOrDefault<Ecoles>(sqlRequette);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(Ecoles ecole)
        {
            try
            {
                var sqlRequette = $"UPDATE {TABLENAME} SET nameecole=@nameecole, typeecole=@typeecole, numerorue=@numerorue, ruename=@ruename, quartier=@quartier, ville=@ville, pays=@pays, telephoneecole=@telephoneecole, emailecole=@emailecole, siteweb=@siteweb";
                using var dapperConnexion = new NpgsqlConnection(_connexionString);
                dapperConnexion.ExecuteScalar(sqlRequette, ecole);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
