
namespace Longoka.Domain.DAO
{
    public class Enseignant
    {
        public int EnseignantId { get; set; }
        public string NomEnseignant { get; set; } = string.Empty;
        public string PrenomEnseignant { get; set; } = string.Empty;
        public string TypeEnseignant { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string TelephoneEnseignant { get; set; } = string.Empty;
        public DateTime DateNaissance { get; set; }
        public string EmailEnseignant { get; set; } = string.Empty;
        public int NumeroRue { get; set; }
        public string Rue { get; set; } = string.Empty;
        public string Ville { get; set; } = string.Empty;
        public string Pays { get; set; } = string.Empty;
        public string Profile { get; set; } = string.Empty;
    }
}
