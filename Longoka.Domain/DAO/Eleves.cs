
namespace Longoka.Domain.DAO
{
    public class Eleve
    {
        public int EleveId { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Prenoms { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public DateTime DateNaissance { get; set; }
        public string Profile { get; set; } = string.Empty;
        public int ClasseId { get; set; }
        public int ParentId { get; set; }

    }
}
