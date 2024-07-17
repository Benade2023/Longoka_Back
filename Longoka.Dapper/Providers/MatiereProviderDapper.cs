using Dapper;
using Longoka.Domain.DAO;
using Longoka.Domain.Interfaces;
using Npgsql;

namespace Longoka.Dapper.Providers
{
    public class MatiereProviderDapper : IProvider<Matiere,int>
    {
        private string _connexionString = string.Empty;
        private const string TABLENAME = "Matieres";
        private NpgsqlConnection _connexion;


        public MatiereProviderDapper(string connexionString)
        {
            _connexionString = connexionString;
            _connexion = new NpgsqlConnection(_connexionString);

        }
        public async Task<StatusResponse> Create(Matiere matiere)
        {
            try
            {
                var sqlRequette = $"INSERT INTO {TABLENAME} (niveau, matierename) " +
                    $"VALUES (@niveau, @matierename)";

                await _connexion.OpenAsync();
                await _connexion.ExecuteScalarAsync<Matiere>(sqlRequette, matiere);

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
                var sqlRequette = $"DELETE FROM {TABLENAME} WHERE matiereid = {id}";
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

        public async Task<IEnumerable<Matiere>> GetAll()
        {
            try
            {
                var sqlRequette = $"SELECT * FROM {TABLENAME}";
                await _connexion.OpenAsync();
                var result = await _connexion.QueryAsync<Matiere>(sqlRequette);

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

        public async Task<Matiere> GetById(int id)
        {
            try
            {
                var sqlRequette = $"SELECT * FROM {TABLENAME} WHERE matiereid = {id}";
                await _connexion.OpenAsync();
                var result = await _connexion.QuerySingleOrDefaultAsync<Matiere>(sqlRequette);

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

        public async Task<StatusResponse> Update(Matiere matiere)
        {
            try
            {
                var sqlRequette = $"UPDATE {TABLENAME} SET niveau=@niveau, matierename=@matierename" +
                   $" WHERE Matiereid = {matiere.MatiereId}";
                await _connexion.OpenAsync();
                var result = await _connexion.ExecuteAsync(sqlRequette, matiere);
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
