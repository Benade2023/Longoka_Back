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
                var sqlRequette = $"INSERT INTO {TABLENAME} (username, password, completname, birthday, numerorue, ruename, quartier, ville, pays, telephoneparent, emailparent, profileid, ecoleid)" +
                    $"VALUES (@username, @password, @completname, @birthday, @numerorue, @ruename, @quartier, @ville, @pays, @telephoneparent, @emailparent, @profileid, @ecoleid)";
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
            var sqlRequette = $"UPDATE {TABLENAME} SET username=@username, password=@password, completname=@completname, birthday=@birthday, numerorue=@numerorue, ruename=@ruename, quartier=@quartier, ville=@ville, pays=@pays, telephoneparent=@telephoneparent, emailparent=@emailparent, profileid=@profileid, ecoleid=@ecoleid";
            using var dapperConnexion = new NpgsqlConnection(_connexionString);
            dapperConnexion.ExecuteScalar(sqlRequette, parentEleves);
        }
    }
}
