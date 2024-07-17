
using Dapper;
using Longoka.Domain.DAO;
using Longoka.Domain.Interfaces;
using Npgsql;

namespace Longoka.Dapper.Providers
{
    public class EtablissmentEnseignantMatiereProvider : ITableIntermediare<Etablissement_Enseignant_Matiere>
    {
        private string _connexionString = string.Empty;
        private const string TableName = "etablissement_enseignant_matiere";
        private NpgsqlConnection _connexion;
        public EtablissmentEnseignantMatiereProvider(string connexionString)
        {
            _connexionString = connexionString;
            _connexion = new NpgsqlConnection(_connexionString);
        }
        public async Task<bool> InsertDataOfIntermediareTable(Etablissement_Enseignant_Matiere classe)
        {
            try
            {
                string query = $"INSERT INTO {TableName} (\r\n\tmatiereid, enseignantid, etablissementid)" +
                    $"VALUES (@matiereid, @enseignantid, @etablissementid);";

                await _connexion.OpenAsync();
               await _connexion.ExecuteScalarAsync(query,classe);
                   
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
