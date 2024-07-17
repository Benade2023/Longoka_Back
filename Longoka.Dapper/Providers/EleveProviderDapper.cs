using Dapper;
using Longoka.Domain.DAO;
using Longoka.Domain.Interfaces;
using Npgsql;


namespace Longoka.Dapper.Providers
{
    public class EleveProviderDapper : IProvider<Eleve,int>
    {
        private string _connexionString = string.Empty;
        private const string TABLENAME = "Eleves";
        private NpgsqlConnection _connexion;
        public EleveProviderDapper(string connexionString)
        {
            _connexionString = connexionString;
            _connexion = new NpgsqlConnection(_connexionString);
        }

        public async Task<StatusResponse> Create(Eleve Eleve)
        {
            try
            {
                var sqlRequette = $"INSERT INTO {TABLENAME} (nom, prenoms, genre, datenaissance, classeid, parentid) " +
                    $"VALUES (@nom, @prenoms, @genre,@datenaissance,@classeid,@parentid)";
                await _connexion.OpenAsync();
                await _connexion.ExecuteScalarAsync<Eleve>(sqlRequette, Eleve);

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
                var sqlRequette = $"DELETE FROM {TABLENAME} WHERE eleveid = {id}";
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

        public async Task<IEnumerable<Eleve>> GetAll()
        {
            try
            {
                var sqlRequette = $"SELECT * FROM {TABLENAME}";
                await _connexion.OpenAsync();
                var result = await _connexion.QueryAsync<Eleve>(sqlRequette);

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

        public async Task<Eleve> GetById(int id)
        {
            try
            {
                var sqlRequette = $"SELECT * FROM {TABLENAME} WHERE eleveid = {id}";
                await _connexion.OpenAsync();
                var result = await _connexion.QuerySingleOrDefaultAsync<Eleve>(sqlRequette);

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

        public async Task<StatusResponse> Update(Eleve eleve)
        {
            try
            {
                var sqlRequette = $"UPDATE {TABLENAME} SET nom=@nom, prenoms=@prenoms, genre=@genre,datenaissance=@datenaissance,classeid=@classeid,parentid=@parentid" +
                   $" WHERE Eleveid = {eleve.EleveId}";
                await _connexion.OpenAsync();
                var result = await _connexion.ExecuteAsync(sqlRequette, eleve);
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
