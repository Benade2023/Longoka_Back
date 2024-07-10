using Dapper;
using Longoka.Domain.DAO;
using Longoka.Domain.Interfaces;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longoka.Dapper.Providers
{
    public class EleveProviderDapper: IProvider<Eleves, Guid>
    {
        private string _connexionString = string.Empty;
        private const string TABLENAME = "Eleves";
        public EleveProviderDapper(string connexionString)
        {
            _connexionString = connexionString;
        }

        public void Create(Eleves eleve)
        {
            var sqlRequette = $"INSERT INTO {TABLENAME} (userid, ecoleid, profileid, classeId) " +
                    $"VALUES (@userid, @ecoleid, @profileid, @classeId)";
            using var dapperConnexion = new NpgsqlConnection(_connexionString);
            dapperConnexion.ExecuteScalar<Eleves>(sqlRequette);
        }

        public List<Eleves> GetAll()
        {
            try
            {
                var sqlRequette = $"SELECT * FROM {TABLENAME}";
                using var dapperConnexion = new NpgsqlConnection(_connexionString);
                var result = dapperConnexion.Query<Eleves>(sqlRequette);
                return result.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Eleves GetById(Guid id)
        {
            try
            {
                var sqlRequette = $"SELECT * FROM {TABLENAME} WHERE EleveId = {id}";
                using var dapperConnexion = new NpgsqlConnection(_connexionString);
                var result = dapperConnexion.QueryFirstOrDefault<Eleves>(sqlRequette);
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(Eleves eleve)
        {
            try
            {
                var sqlRequette = $"UPDATE {TABLENAME} SET userid=@userid, ecoleid=@ecoleid, profileid=@profileid, classeId=@classeId";
                using var dapperConnexion = new NpgsqlConnection(_connexionString);
                dapperConnexion.ExecuteScalar(sqlRequette, eleve);
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
                var sqlRequette = $"DELETE FROM {TABLENAME} WHERE EleveId = {id} ";
                using var dapperConnexion = new NpgsqlConnection(_connexionString);
                dapperConnexion.Query(sqlRequette, id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
