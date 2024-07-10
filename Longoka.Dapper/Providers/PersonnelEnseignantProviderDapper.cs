using Dapper;
using Longoka.Domain.DAO;
using Longoka.Domain.Interfaces;
using Npgsql;

namespace Longoka.Dapper.Providers
{
    public class PersonnelEnseignantProviderDapper : IProvider<PersonnelEnseignants, Guid>
    {
        private string _connexionString = string.Empty;
        private const string TABLENAME = "PersonnelEnseignants";
        public PersonnelEnseignantProviderDapper(string connexionString)
        {
            _connexionString=connexionString;
        }
        public void Create(PersonnelEnseignants enseignants)
        {
            var sqlRequette = $"INSERT INTO {TABLENAME} (completname, telephone, email, numerorue, ruename, quartier, ville, pays, username, password, typeenseignant, ecoleid, matiere, classe, profileid)" +
                    $"VALUES (@completname, @telephone, @email, @numerorue, @ruename, @quartier, @ville, @pays, @username, @password, @typeenseignant, @ecoleid, @matiere, @classe, @profileid)";
            using var dapperConnexion = new NpgsqlConnection(_connexionString);
            dapperConnexion.ExecuteScalar<PersonnelEnseignants>(sqlRequette, enseignants);
        }

        public void Delete(Guid id)
        {
            var sqlRequette = $"DELETE FROM {TABLENAME} WHERE PersonnelEnseignantId = {id}";
            using var dapperConnexion = new NpgsqlConnection(_connexionString);
            dapperConnexion.Query(sqlRequette, id);
        }

        public List<PersonnelEnseignants> GetAll()
        {
            var sqlRequette = $"SELECT * FROM {TABLENAME}";
            using var dapperConnexion = new NpgsqlConnection(_connexionString);
            var result = dapperConnexion.Query<PersonnelEnseignants>(sqlRequette);
            return result.ToList();
        }

        public PersonnelEnseignants GetById(Guid id)
        {
            var sqlRequette = $"SELECT * FROM {TABLENAME} WHERE PersonnelEnseignantId = {id}";
            using var dapperConnexion = new NpgsqlConnection(_connexionString);
            var result = dapperConnexion.QueryFirstOrDefault<PersonnelEnseignants>(sqlRequette);
            return result;
        }

        public void Update(PersonnelEnseignants enseignant)
        {
            var sqlRequette = $"UPDATE {TABLENAME} SET completname=@completname, telephone=@telephone, email=@email, numerorue=@numerorue, ruename=@ruename, quartier=@quartier, ville=@ville, pays=@pays, username=@username, password=@password, typeenseignant=@typeenseignant, ecoleid=@ecoleid, matiere=@matiere, classe=@classe, profileid=@profileid";
            using var dapperConnexion = new NpgsqlConnection(_connexionString);
            dapperConnexion.ExecuteScalar(sqlRequette, enseignant);
        }
    }
}
