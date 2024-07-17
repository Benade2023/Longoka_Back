
using Dapper;
using Longoka.Domain.DAO;
using Longoka.Domain.Interfaces;
using Npgsql;

namespace Longoka.Dapper.Providers
{
    public class EleveCoursProviderDapper : ITableIntermediare<Eleve_Cours>
    {
        private string _connexionString = string.Empty;
        private const string TableName = "eleve_cours";
        private NpgsqlConnection _connexion;
        public EleveCoursProviderDapper(string connexionString)
        {
            _connexionString = connexionString;
            _connexion = new NpgsqlConnection(_connexionString);
        }
        public async Task<bool> InsertDataOfIntermediareTable(Eleve_Cours classe)
        {
            try
            {
                string requete = $"INSERT INTO {TableName} VALUES (@eleveid, @coursid)";
                await _connexion.OpenAsync();
                await _connexion.ExecuteAsync(requete,classe);
                    
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
