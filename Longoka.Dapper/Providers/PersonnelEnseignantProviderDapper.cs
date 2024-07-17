using Dapper;
using Longoka.Domain.DAO;
using Longoka.Domain.Interfaces;
using Npgsql;

namespace Longoka.Dapper.Providers
{
    public class PersonnelEnseignantProviderDapper : IProvider<Enseignant,int>
    {
        private string _connexionString = string.Empty;
        private const string TABLENAME = "Enseignants";
        private NpgsqlConnection _connexion;

        public PersonnelEnseignantProviderDapper(string connexionString)
        {
            _connexionString=connexionString;
            _connexion = new NpgsqlConnection(_connexionString);

        }

        public async Task<StatusResponse> Create(Enseignant enseignant)
        {
            try
            {
                var sqlRequette = $"INSERT INTO {TABLENAME} (nomenseignant, prenomenseignant, typeenseignant, genre, datenaissance, emailenseignant, telephoneenseignant, rue, numerorue, ville, pays) " +
                    $"VALUES (@nomenseignant, @prenomenseignant, @typeenseignant, @genre,@datenaissance,@emailenseignant,@telephoneenseignant,@rue,@numerorue,@ville,@pays)";
                await _connexion.OpenAsync();
                await _connexion.ExecuteScalarAsync<Enseignant>(sqlRequette, enseignant);

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
                var sqlRequette = $"DELETE FROM {TABLENAME} WHERE enseignantid = {id}";
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

        public async Task<IEnumerable<Enseignant>> GetAll()
        {
            try
            {
                var sqlRequette = $"SELECT * FROM {TABLENAME}";
                await _connexion.OpenAsync();
                var result = await _connexion.QueryAsync<Enseignant>(sqlRequette);

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

        public async Task<Enseignant> GetById(int id)
        {
            try
            {
                var sqlRequette = $"SELECT * FROM {TABLENAME} WHERE enseignantid = {id}";
                await _connexion.OpenAsync();
                var result = await _connexion.QuerySingleOrDefaultAsync<Enseignant>(sqlRequette);

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

        public async Task<StatusResponse> Update(Enseignant enseignant)
        {
            try
            {
                var sqlRequette = $"UPDATE {TABLENAME} SET nomenseignant=@nomenseignant, prenomenseignant=@prenomenseignant," +
                    $" typeenseignant=@typeenseignant, genre=@genre,datenaissance=@datenaissance,emailenseignant=@emailenseignant," +
                    $"telephoneenseignant=@telephoneenseignant,rue=@rue,numerorue=@numerorue,ville=@ville,pays=@pays" +
                   $" WHERE Enseignantid = {enseignant.EnseignantId}";

                await _connexion.OpenAsync();
                var result = await _connexion.ExecuteAsync(sqlRequette, enseignant);
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
