
namespace Longoka.Domain.DAO
{
    public class Contact
    {
        public int ContactId { get; set; }
        public int EtablissementId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
        public string SiteWeb { get; set; } = string.Empty;
    }
}
