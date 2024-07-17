
namespace Longoka.Domain.DAO
{
    public class Profile
    {
        public int ProfileId { get; set; }
        public string ProfileName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int EtablissementId { get; set; }
    }
}
