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
    public class MatiereProviderDapper : IProvider<Matieres, Guid>
    {
        private string _connexionString = string.Empty;
        private const string TABLENAME = "Matieres";
        public MatiereProviderDapper(string connexionString)
        {
            _connexionString += connexionString;
        }
        public void Create(Matieres matiere)
        {
            try
            {
                var sqlRequette = $"INSERT INTO {TABLENAME} (niveau, matierename, classe, ecoleid) " +
                    $"VALUES (@niveau, @matierename, @classe, @ecoleid)";
                using var dapperConnexion = new NpgsqlConnection(_connexionString);
                dapperConnexion.ExecuteScalar<Matieres>(sqlRequette, matiere);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(Guid id)
        {
            var sqlRequette = $"DELETE FROM {TABLENAME} WHERE MatiereId = {id}";
            using var dapperConnexion = new NpgsqlConnection(_connexionString);
            dapperConnexion.Query(sqlRequette, id);
        }

        public List<Matieres> GetAll()
        {
            var sqlRequette = $"SELECT * FROM {TABLENAME}";
            using var dapperConnexion = new NpgsqlConnection(_connexionString);
            var result = dapperConnexion.Query<Matieres>(sqlRequette);
            return result.ToList();
        }

        public Matieres GetById(Guid id)
        {
            var sqlRequette = $"SELECT * FROM {TABLENAME} WHERE MatiereId = {id}";
            using var dapperConnexion = new NpgsqlConnection(_connexionString);
            var result = dapperConnexion.QueryFirstOrDefault<Matieres>(sqlRequette);
            return result;
        }

        public void Update(Matieres matieres)
        {
            var sqlRequette = $"UPDATE {TABLENAME} SET niveau=@niveau, matierename=@matierename, classe=@classe, ecoleid=@ecoleid";
            using var dapperConnexion = new NpgsqlConnection(_connexionString);
            dapperConnexion.ExecuteScalar(sqlRequette, matieres);
        }
    }
}
