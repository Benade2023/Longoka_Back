
using Dapper;
using Longoka.Domain.DAO;
using Longoka.Domain.Interfaces;
using Npgsql;

namespace Longoka.Dapper.Providers
{
    public class AdresseProviderDapper : IProvider<Adresse,int>
    {

        private string _connexionString = string.Empty;
        private const string TABLENAME = "adresses";
        private NpgsqlConnection _connexion;
        public AdresseProviderDapper(string connexionString)
        {
            _connexionString = connexionString;
            _connexion = new NpgsqlConnection(_connexionString);
        }
        public async Task<StatusResponse> Create(Adresse adresse)
        {
            try
            {
                var sqlRequette = $"INSERT INTO {TABLENAME} (numerorue, ruename, quartier, ville, pays, etablissementid) " +
                    $"VALUES (@numerorue, @ruename, @quartier, @ville, @pays, @etablissementid)";

                await _connexion.OpenAsync();
                await _connexion.ExecuteScalarAsync<Adresse>(sqlRequette, adresse);

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
                var sqlRequette = $"DELETE FROM {TABLENAME} WHERE adresseid = {id}";
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
        public async Task<IEnumerable<Adresse>> GetAll()
        {
            try
            {
                var sqlRequette = $"SELECT * FROM {TABLENAME}";
                await _connexion.OpenAsync();
                var result = await _connexion.QueryAsync<Adresse>(sqlRequette);

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

        public async Task<Adresse> GetById(int id)
        {
            try
            {
                var sqlRequette = $"SELECT * FROM {TABLENAME} WHERE adresseid = {id}";
                await _connexion.OpenAsync();
                var result = await _connexion.QuerySingleOrDefaultAsync<Adresse>(sqlRequette);

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

        public async Task<StatusResponse> Update(Adresse adresse)
        {
            try
            {
                var sqlRequette = $"UPDATE {TABLENAME} SET numerorue=@numerorue, ruename=@ruename, quartier=@quartier, ville=@ville, pays=@pays" +
                   $" WHERE Adresseid = {adresse.AdresseId}";

                await _connexion.OpenAsync();
                var result = await _connexion.ExecuteAsync(sqlRequette, adresse);
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
