
using Dapper;
using Longoka.Domain.DAO;
using Longoka.Domain.Interfaces;
using Npgsql;

namespace Longoka.Dapper.Providers
{
    public class CoursProviderDapper : IProvider<Cours,int>
    {
        private string _connexionString = string.Empty;
        private const string TABLENAME = "Cours";
        private NpgsqlConnection _connexion;

        public CoursProviderDapper(string connexionString)
        {
            _connexionString = connexionString;
            _connexion = new NpgsqlConnection(_connexionString);
        }

        public async Task<StatusResponse> Create(Cours cours)
        {
            try
            {
                var sqlRequette = $"INSERT INTO {TABLENAME} (coursname,jour_cours, heure_debut, heure_fin, observation, salleid,enseignantid,matiereid) " +
                    $"VALUES (@coursname,@jour_cours, @heure_debut, @heure_fin, @observation, @salleid,@enseignantid,@matiereid)";

                await _connexion.OpenAsync();
                await _connexion.ExecuteScalarAsync<Cours>(sqlRequette, cours);

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
                var sqlRequette = $"DELETE FROM {TABLENAME} WHERE Coursid = {id}";
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

        public async Task<IEnumerable<Cours>> GetAll()
        {
            try
            {
                var sqlRequette = $"SELECT * FROM {TABLENAME}";
                await _connexion.OpenAsync();
                var result = await _connexion.QueryAsync<Cours>(sqlRequette);

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

        public async Task<Cours> GetById(int id)
        {
            try
            {
                var sqlRequette = $"SELECT * FROM {TABLENAME} WHERE Coursid = {id}";
                await _connexion.OpenAsync();
                var result = await _connexion.QuerySingleOrDefaultAsync<Cours>(sqlRequette);

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
        public async Task<StatusResponse> Update(Cours cours)
        {
            try
            {
                var sqlRequette = $"UPDATE {TABLENAME} SET coursname=@coursname,jour_cours=@jour_cours, heure_debut=@heure_debut, heure_fin=@heure_fin, observation=@observation, salleid=@salleid" +
                   $" WHERE Coursid = {cours.CoursId}";

                await _connexion.OpenAsync();
                var result = await _connexion.ExecuteAsync(sqlRequette, cours);
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
