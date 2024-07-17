
namespace Longoka.Domain.DAO
{
    public class Cours
    {
        public int CoursId { get; set; }
        public string CoursName { get; set; } = string.Empty;
        public DateTime Jour_cours {  get; set; } = DateTime.Now;
        public string Heure_debut { get; set; }
        public string Heure_Fin { get; set; }
        public string ? Observation {  get; set; }
        public int SalleId { get; set; }
        public int EnseignantId { get; set; }
        public int MatiereId { get; set; }
    }
}
