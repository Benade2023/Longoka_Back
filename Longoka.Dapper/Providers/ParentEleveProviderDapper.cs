using Dapper;
using Longoka.Domain.DAO;
using Longoka.Domain.Interfaces;
using Npgsql;

namespace Longoka.Dapper.Providers
{
    public class ParentEleveProviderDapper : IProvider<ParentEleves, Guid>
    {
        private string _connexionString = string.Empty;
        private const string TABLENAME = "ParentEleves";
        public ParentEleveProviderDapper(string connexionString)
        {
            _connexionString = connexionString;
        }
        public void Create(ParentEleves parentEleve)
        {
            try
            {
                var sqlRequette = $"INSERT INTO {TABLENAME} (userid, ecoleid, profileid)" +
                    $"VALUES (@userid, @ecoleid, @profileid)";
                using var dapperConnexion = new NpgsqlConnection(_connexionString);
                dapperConnexion.ExecuteScalar<ParentEleves>(sqlRequette, parentEleve);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(Guid id)
        {
            var sqlRequette = $"DELETE FROM {TABLENAME } WHERE ParentId = {id}";
            using var dapperConnexion = new NpgsqlConnection(_connexionString);
            dapperConnexion.Query(sqlRequette, id);
        }

        public List<ParentEleves> GetAll()
        {
            var sqlRequette = $"SELECT * FROM {TABLENAME}";
            using var dapperConnexion = new NpgsqlConnection(_connexionString);
            var result = dapperConnexion.Query<ParentEleves>(sqlRequette);
            return result.ToList();
        }

        public ParentEleves GetById(Guid id)
        {
            var sqlRequette = $"SELECT * FROM {TABLENAME} WHERE ParentId = {id}";
            using var dapperConnexion = new NpgsqlConnection(_connexionString);
            var result = dapperConnexion.QueryFirstOrDefault<ParentEleves>(sqlRequette);
            return result;
        }

        public void Update(ParentEleves parentEleves)
        {
            var sqlRequette = $"UPDATE {TABLENAME} SET userid=@userid, ecoleid=@ecoleid, profileid=@profileid";
            using var dapperConnexion = new NpgsqlConnection(_connexionString);
            dapperConnexion.ExecuteScalar(sqlRequette, parentEleves);
        }
    }
}
