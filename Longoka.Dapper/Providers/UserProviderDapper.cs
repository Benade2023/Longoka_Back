using Dapper;
using Longoka.Domain.DAO;
using Longoka.Domain.Interfaces;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Longoka.Dapper.Providers
{
    public class UserProviderDapper: IProvider<Users, Guid>
    {
        private string _connexionString = string.Empty;
        private const string TABLENAME = "Users";
        public UserProviderDapper(string connexionString)
        {
            _connexionString = connexionString;
        }

        public void Create(Users user)
        {
            var sqlRequette = $"INSERT INTO {TABLENAME} (username, password, completname, birthday, numerorue, ruename, quartier, ville, pays, ecoleid, profileid)" +
                    $"VALUES (@username, @password, @completname, @birthday, @numerorue, @ruename, @quartier, @ville, @pays, @ecoleid, @profileid)";
            using var dapperConnexion = new NpgsqlConnection(_connexionString);
            dapperConnexion.ExecuteScalar<Users>(sqlRequette, user);
        }

        public List<Users> GetAll()
        {
            var sqlRequette = $"SELECT * FROM {TABLENAME}";
            using var dapperConnexion = new NpgsqlConnection(_connexionString);
            var result = dapperConnexion.Query<Users>(sqlRequette);
            return result.ToList();
        }

        public Users GetById(Guid id)
        {
            var sqlRequette = $"SELECT * FROM {TABLENAME} WHERE UserId = {id}";
            using var dapperConnexion = new NpgsqlConnection(_connexionString);
            var result = dapperConnexion.QueryFirstOrDefault<Users>(sqlRequette);
            return result;
        }

        public void Update(Users user)
        {
            var sqlRequette = $"UPDATE {TABLENAME} SET username=@username, password=@password, completname=@completname, birthday=@birthday, numerorue=@numerorue, ruename=@ruename, quartier=@quartier, ville=@ville, pays=@pays, ecoleid=@ecoleid, profileid=@profileid";
            using var dapperConnexion = new NpgsqlConnection(_connexionString);
            dapperConnexion.ExecuteScalar(sqlRequette, user);
        }

        public void Delete(Guid id)
        {
            var sqlRequette = $"DELETE FROM {TABLENAME} WHERE UserId = {id}";
            using var dapperConnexion = new NpgsqlConnection(_connexionString);
            dapperConnexion.Query(sqlRequette, id);
        }
    }
}
