using Dapper;
using Longoka.Domain.DAO;
using Longoka.Domain.Interfaces;
using Npgsql;

namespace Longoka.Dapper.Providers
{
    public class AnneeScolaireProviderDapper : IProvider<AnneeScolaires,int>
    {
        private string _connexionString = string.Empty;
        private const string TABLENAME = "AnneeScolaires";
        private NpgsqlConnection _connexion;
        public AnneeScolaireProviderDapper(string connexionString)
        {
            _connexionString=connexionString;
            _connexion = new NpgsqlConnection(_connexionString);
        }

        public async Task<StatusResponse> Create(AnneeScolaires anneeScolaires)
        {
            try
            {
                var sqlRequette = $"INSERT INTO {TABLENAME} (anneescolaire, datedebut, datefin, description) " +
                    $"VALUES (@anneescolaire, @datedebut, @datefin,@description)";
                await _connexion.OpenAsync();
                await _connexion.ExecuteScalarAsync<AnneeScolaires>(sqlRequette, anneeScolaires);

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
                var sqlRequette = $"DELETE FROM {TABLENAME} WHERE anneeid = {id}";
                await _connexion.OpenAsync();
                await _connexion.QueryFirstOrDefaultAsync(sqlRequette, id);

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

        public async Task<IEnumerable<AnneeScolaires>> GetAll()
        {
            try
            {
                var sqlRequette = $"SELECT * FROM {TABLENAME}";
                await _connexion.OpenAsync();
                var result = await _connexion.QueryAsync<AnneeScolaires>(sqlRequette);

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

        public async Task<AnneeScolaires> GetById(int id)
        {
            try
            {
                var sqlRequette = $"SELECT * FROM {TABLENAME} WHERE anneeid = {id}";
                await _connexion.OpenAsync();
                var result = await _connexion.QuerySingleOrDefaultAsync<AnneeScolaires>(sqlRequette);

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

        public async Task<StatusResponse> Update(AnneeScolaires anneeScolaires)
        {
            try
            {
                var sqlRequette = $"UPDATE {TABLENAME} SET anneescolaire=@anneescolaire, datedebut=@datedebut, datefin=@datefin,description=@description" +
                   $" WHERE anneeid = {anneeScolaires.AnneeId}";

                await _connexion.OpenAsync();
                var result = await _connexion.ExecuteAsync(sqlRequette, anneeScolaires);
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
