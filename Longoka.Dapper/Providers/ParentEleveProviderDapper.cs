using Dapper;
using Longoka.Domain.DAO;
using Longoka.Domain.Interfaces;
using Npgsql;

namespace Longoka.Dapper.Providers
{
    public class ParentEleveProviderDapper : IProvider<ParentEleve,int>
    {
        private string _connexionString = string.Empty;
        private const string TABLENAME = "ParentEleves";
        private NpgsqlConnection _connexion;

        public ParentEleveProviderDapper(string connexionString)
        {
            _connexionString = connexionString;
            _connexion = new NpgsqlConnection(_connexionString);

        }

        public async Task<StatusResponse> Create(ParentEleve parentEleve)
        {
            try
            {
                var sqlRequette = $"INSERT INTO {TABLENAME} (nomparent, prenomparent, telephone, emailparent, rue, numerorue, ville, pays) " +
                    $"VALUES (@nomparent, @prenomparent, @telephone,@emailparent,@rue,@numerorue,@ville,@pays)";
                await _connexion.OpenAsync();
                await _connexion.ExecuteScalarAsync<ParentEleve>(sqlRequette, parentEleve);

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
                var sqlRequette = $"DELETE FROM {TABLENAME} WHERE ParentId = {id}";
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

        public async Task<IEnumerable<ParentEleve>> GetAll()
        {
            try
            {
                var sqlRequette = $"SELECT * FROM {TABLENAME}";
                await _connexion.OpenAsync();
                var result = await _connexion.QueryAsync<ParentEleve>(sqlRequette);

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

        public async Task<ParentEleve> GetById(int id)
        {
            try
            {
                var sqlRequette = $"SELECT * FROM {TABLENAME} WHERE ParentId = {id}";
                await _connexion.OpenAsync();
                var result = await _connexion.QuerySingleOrDefaultAsync<ParentEleve>(sqlRequette);

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

        public async Task<StatusResponse> Update(ParentEleve parentEleve)
        {
            try
            {
                var sqlRequette = $"UPDATE {TABLENAME} SET nomparent=@nomparent, prenomparent=@prenomparent, telephone=@telephone,emailparent=@emailparent,rue=@rue,numerorue=@numerorue,ville=@ville,pays=@pays" +
                   $" WHERE ParentEleveid = {parentEleve.ParentId}";
                await _connexion.OpenAsync();
                var result = await _connexion.ExecuteAsync(sqlRequette, parentEleve);
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
