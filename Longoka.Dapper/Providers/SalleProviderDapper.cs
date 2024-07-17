
using Dapper;
using Longoka.Domain.DAO;
using Longoka.Domain.Interfaces;
using Npgsql;

namespace Longoka.Dapper.Providers
{
    public class SalleProviderDapper : IProvider<Salle,int>
    {
        private string _connexionString = string.Empty;
        private const string TABLENAME = "Salles";
        private NpgsqlConnection _connexion;

        public SalleProviderDapper(string connexionString)
        {
            _connexionString = connexionString;
            _connexion = new NpgsqlConnection(_connexionString);
        }

        public async Task<StatusResponse> Create(Salle salle)
        {
            try
            {
                var sqlRequette = $"INSERT INTO {TABLENAME} (sallename, batiment, etage) " +
                    $"VALUES (@sallename, @batiment,@etage)";

                await _connexion.OpenAsync();
                await _connexion.ExecuteScalarAsync<Salle>(sqlRequette, salle);

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
                var sqlRequette = $"DELETE FROM {TABLENAME} WHERE Salleid = {id}";
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

        public async Task<IEnumerable<Salle>> GetAll()
        {
            try
            {
                var sqlRequette = $"SELECT * FROM {TABLENAME}";
                await _connexion.OpenAsync();
                var result = await _connexion.QueryAsync<Salle>(sqlRequette);

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

        public async Task<Salle> GetById(int id)
        {
            try
            {
                var sqlRequette = $"SELECT * FROM {TABLENAME} WHERE Salleid = {id}";
                await _connexion.OpenAsync();
                var result = await _connexion.QuerySingleOrDefaultAsync<Salle>(sqlRequette);

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
        public async Task<StatusResponse> Update(Salle salle)
        {
            try
            {
                var sqlRequette = $"UPDATE {TABLENAME} SET sallename=@sallename, batiment=@batiment, etage=@etage" +
                   $" WHERE Salleid = {salle.SalleId}";

                await _connexion.OpenAsync();
                var result = await _connexion.ExecuteAsync(sqlRequette, salle);
                if (result == 0)
                {
                    throw new InvalidOperationException("Aucun utilisateur trouvé avec l'ID spécifié.");
                }

                return new StatusResponse() { Message = "Mise à jour effectuée avec succès" };

            }
            catch (NpgsqlException ex)
            {
                return new StatusResponse() { Success = false, Message = ex.Message };
            }
        }
    }
}
