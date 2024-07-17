
namespace Longoka.Domain.DAO
{
    public class Salle
    {
        public int SalleId { get; set; }
        public string SalleName { get; set; } = string.Empty;
        public string Batiment { get; set; } = string.Empty;
        public string? Etage { get; set; }
    }
}
