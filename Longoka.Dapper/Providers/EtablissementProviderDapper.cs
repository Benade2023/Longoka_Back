using Dapper;
using Longoka.Domain.DAO;
using Longoka.Domain.Interfaces;
using Npgsql;

namespace Longoka.Dapper.Providers
{
    public class EtablissementProviderDapper : IProvider<Etablissement, int>
    {
        private string _connexionString = string.Empty;
        private const string TABLENAME = "Etablissements";
        private NpgsqlConnection _connexion;
        public EtablissementProviderDapper(string connexionString)
        {
            _connexionString=connexionString;
            _connexion = new NpgsqlConnection(_connexionString);
        }
        public async Task<StatusResponse> Create(Etablissement etablissement)
        {
            try
            {
                var sqlRequette = $"INSERT INTO {TABLENAME} (etablissementname, typeetablissemt, datecreation) " +
                    $"VALUES (@etablissementname, @typeetablissemt, @datecreation)";
                await _connexion.OpenAsync();
               await _connexion.ExecuteScalarAsync<Etablissement>(sqlRequette, etablissement);

                return new StatusResponse()
                {
                    Message = "Enrégistrment effectué avce succès."
                };
            }
            catch (Exception ex)
            {
                return new StatusResponse()
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<StatusResponse> Delete(int id)
        {
            try
            {
                var sqlRequette = $"DELETE FROM {TABLENAME} WHERE etablissementid = {id}";
               await _connexion.OpenAsync();
              var result = await _connexion.QueryFirstOrDefaultAsync(sqlRequette, id);

                return new StatusResponse()
                {
                    Message = "Suppression effectuée avce succès."
                };
            }
            catch (Exception ex)
            {

                return new StatusResponse()
                {
                    Success = false,
                    Message = ex.Message,
                };
            }
        }

        public async Task<IEnumerable<Etablissement>> GetAll()
        {
            try
            {
                var sqlRequette = $"SELECT * FROM {TABLENAME}";
                await _connexion.OpenAsync();
                var result = await _connexion.QueryAsync<Etablissement>(sqlRequette);

                if (result is null)
                {
                    return [];
                }
                return result.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Etablissement> GetById(int id)
        {
            try
            {
                var sqlRequette = $"SELECT * FROM {TABLENAME} WHERE etablissementid = {id}";
                await _connexion.OpenAsync();
                var result = await _connexion.QuerySingleOrDefaultAsync<Etablissement>(sqlRequette);

                if (result is null)
                {
                    return null!;
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<StatusResponse> Update(Etablissement etablissement)
        {
            try
            {
                 var sqlRequette = $"UPDATE {TABLENAME} SET etablissementname=@etablissementname, typeetablissemt=@typeetablissemt" +
                    $" WHERE etablissementid = {etablissement.EtablissementId}";
                 await _connexion.OpenAsync();
                 var result = await _connexion.ExecuteAsync(sqlRequette, etablissement);
                if (result == 0)
                {
                    throw new InvalidOperationException("Aucun utilisateur trouvé avec l'ID spécifié.");
                }

                return new StatusResponse() { Message = "Mise à jour effectuée avec succès" };

            }
            catch (NpgsqlException ex)
            {
                return new StatusResponse() {Success=false, Message= ex.Message };
            }
        }
    }
}
