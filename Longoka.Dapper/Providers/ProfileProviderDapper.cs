using Dapper;
using Longoka.Domain.DAO;
using Longoka.Domain.Interfaces;
using Npgsql;

namespace Longoka.Dapper.Providers
{
    public class ProfileProviderDapper : IProvider<Profile,int>
    {
        private string _connexionString = string.Empty;
        private const string TABLENAME = "Profiles";
        private NpgsqlConnection _connexion;

        public ProfileProviderDapper(string connexionString)
        {
            _connexionString = connexionString;
            _connexion = new NpgsqlConnection(_connexionString);
        }

        public async Task<StatusResponse> Create(Profile profile)
        {
            try
            {
                var sqlRequette = $"INSERT INTO {TABLENAME} (profilename, description, etablissementid) " +
                    $"VALUES (@profilename, @description, @etablissementid)";

                await _connexion.OpenAsync();
                await _connexion.ExecuteScalarAsync<Profile>(sqlRequette, profile);

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
                var sqlRequette = $"DELETE FROM {TABLENAME} WHERE profileid = {id}";
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
        public async Task<IEnumerable<Profile>> GetAll()
        {
            try
            {
                var sqlRequette = $"SELECT * FROM {TABLENAME}";
                await _connexion.OpenAsync();
                var result = await _connexion.QueryAsync<Profile>(sqlRequette);

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

        public async Task<Profile> GetById(int id)
        {
            try
            {
                var sqlRequette = $"SELECT * FROM {TABLENAME} WHERE profileid = {id}";
                await _connexion.OpenAsync();
                var result = await _connexion.QuerySingleOrDefaultAsync<Profile>(sqlRequette);

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

        public async Task<StatusResponse> Update(Profile profile)
        {
            try
            {
                var sqlRequette = $"UPDATE {TABLENAME} SET profilename=@profilename, description=@description, etablissementid=@etablissementid" +
                   $" WHERE Profileid = {profile.ProfileId}";

                await _connexion.OpenAsync();
                var result = await _connexion.ExecuteAsync(sqlRequette, profile);
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
