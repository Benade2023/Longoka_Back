
namespace Longoka.Domain.DAO
{
    public class ParentEleve
    {
        public int ParentId { get; set; }
        public string NomParent { get; set; } = string.Empty;
        public string PrenomParent { get; set; } = string.Empty ;
        public string Telephone { get; set; } = string.Empty;
        public int NumeroRue { get; set; }
        public string Rue { get; set; } = string.Empty;
        public string Ville { get; set; } = string.Empty;
        public string Pays { get; set; } = string.Empty;
        public string ? EmailParent { get; set; } = string.Empty;
        public string Profile { get; set; } = string.Empty;
    }
}
