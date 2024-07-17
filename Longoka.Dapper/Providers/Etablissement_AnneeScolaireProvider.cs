
using Dapper;
using Longoka.Domain.DAO;
using Longoka.Domain.Interfaces;
using Npgsql;

namespace Longoka.Dapper.Providers
{
    public class Etablissement_AnneeScolaireProvider : ITableIntermediare<AnneeScolaire_Etablissement>
    {
        private string _connexionString = string.Empty;
        private NpgsqlConnection _connexion;
        public Etablissement_AnneeScolaireProvider(string connexionString)
        {
            _connexionString = connexionString;
            _connexion = new NpgsqlConnection(_connexionString);
        }
        public async Task<bool> InsertDataOfIntermediareTable(AnneeScolaire_Etablissement anneeScolaire_Etablissement)
        {
            try
            {
                await _connexion.OpenAsync();
                await _connexion.ExecuteAsync(
                    "Etablissement_AnneeScolaire_Procedure",
                    new {anneeid = anneeScolaire_Etablissement.AnneeId, etablissementid = anneeScolaire_Etablissement.EtablissementId},
                    commandType: System.Data.CommandType.StoredProcedure
                    );
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
