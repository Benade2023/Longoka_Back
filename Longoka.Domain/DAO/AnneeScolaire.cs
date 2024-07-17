
namespace Longoka.Domain.DAO
{
    public class AnneeScolaires
    {
        public int AnneeId { get; set; }
        public string AnneeScolaire { get; set; } = string.Empty;
        public DateTime DateDebut { get; set; }
        public DateTime DateFin {  get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
