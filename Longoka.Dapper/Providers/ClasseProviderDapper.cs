using Dapper;
using Longoka.Domain.DAO;
using Longoka.Domain.Interfaces;
using Npgsql;

namespace Longoka.Dapper.Providers
{
    public class ClasseProviderDapper : IProvider<Classe,int>
    {
        private string _connexionString = string.Empty;
        private const string TABLENAME = "Classes";
        private NpgsqlConnection _connexion;
        public ClasseProviderDapper(string connexionString)
        {
            _connexionString=connexionString;
            _connexion = new NpgsqlConnection(_connexionString);
        }
        public async Task<StatusResponse> Create(Classe classe)
        {
            try
            {
                var sqlRequette = $"INSERT INTO {TABLENAME} (classename, cyle, etablissementid) " +
                    $"VALUES (@classename, @cyle, @etablissementid)";
                await _connexion.OpenAsync();
                await _connexion.ExecuteScalarAsync<Classe>(sqlRequette, classe);

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
                var sqlRequette = $"DELETE FROM {TABLENAME} WHERE classeid = {id}";
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

        public async Task<IEnumerable<Classe>> GetAll()
        {
            try
            {
                var sqlRequette = $"SELECT * FROM {TABLENAME}";
                await _connexion.OpenAsync();
                var result = await _connexion.QueryAsync<Classe>(sqlRequette);

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

        public async Task<Classe> GetById(int id)
        {
            try
            {
                var sqlRequette = $"SELECT * FROM {TABLENAME} WHERE classeid = {id}";
                await _connexion.OpenAsync();
                var result = await _connexion.QuerySingleOrDefaultAsync<Classe>(sqlRequette);

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

        public async Task<StatusResponse> Update(Classe classe)
        {
            try
            {
                var sqlRequette = $"UPDATE {TABLENAME} SET classename=@classename, cycle=@cyle" +
                   $" WHERE Classeid = {classe.ClasseId}";
                await _connexion.OpenAsync();
                var result = await _connexion.ExecuteAsync(sqlRequette, classe);
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
