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
    public class ProfileProviderDapper : IProvider<Profiles, Guid>
    {
        private string _connexionString = string.Empty;
        private const string TABLENAME = "Profiles";
        public ProfileProviderDapper(string connexionString)
        {
            _connexionString = connexionString;
        }
        public void Create(Profiles profile)
        {
            var sqlRequette = $"INSERT INTO {TABLENAME} (profilename, description, ecoleid)" +
                    $"VALUES (@profilename, @description, @ecoleid)";
            using var dapperConnexion = new NpgsqlConnection(_connexionString);
            dapperConnexion.ExecuteScalar<Profiles>(sqlRequette, profile);
        }

        public void Delete(Guid id)
        {
            var sqlRequette = $"DELETE FROM {TABLENAME} WHERE ProfileId = {id}";
            using var dapperConnexion = new NpgsqlConnection(_connexionString);
            dapperConnexion.Query(sqlRequette, id);
        }

        public List<Profiles> GetAll()
        {
            var sqlRequette = $"SELECT * FROM {TABLENAME}";
            using var dapperConnexion = new NpgsqlConnection(_connexionString);
            var result = dapperConnexion.Query<Profiles>(sqlRequette);
            return result.ToList();
        }

        public Profiles GetById(Guid id)
        {
            var sqlRequette = $"SELECT * FROM {TABLENAME} WHERE ProfileId = {id}";
            using var dapperConnexion = new NpgsqlConnection(_connexionString);
            var result = dapperConnexion.QueryFirstOrDefault<Profiles>(sqlRequette);
            return result;
        }

        public void Update(Profiles profile)
        {
            var sqlRequette = $"UPDATE {TABLENAME} SET profilename=@profilename, description=@description, ecoleid=@ecoleid";
            using var dapperConnexion = new NpgsqlConnection(_connexionString);
            dapperConnexion.ExecuteScalar(sqlRequette, profile);
        }
    }
}
