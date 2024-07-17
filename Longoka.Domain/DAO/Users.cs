
namespace Longoka.Domain.DAO
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;    
        public string Password { get; set; } = string.Empty;
        public string Nom { get; set; } = string.Empty;
        public string Prenom {  get; set; } = string.Empty ;
        public int EtablissementId { get; set; }
        public int ProfileId { get; set; }
    }
}
