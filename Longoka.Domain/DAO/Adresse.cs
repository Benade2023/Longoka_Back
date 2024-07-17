
namespace Longoka.Domain.DAO
{
    public class Adresse
    {
        public int AdresseId { get; set; }
        public int NumeroRue { get; set; }
        public string RueName { get; set; } = string.Empty;
        public string? Quartier { get; set; } = string.Empty;
        public string Ville { get; set; } = string.Empty;
        public string Pays { get; set; } = string.Empty;
        public int EtablissementId { get; set; }

    }
}
