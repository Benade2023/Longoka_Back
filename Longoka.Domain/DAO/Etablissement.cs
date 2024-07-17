
namespace Longoka.Domain.DAO
{
    public class Etablissement
    {
        public int EtablissementId { get; set; }
        public string EtablissementName { get; set; } = string.Empty;
        public string TypeEtablissemt { get; set; } = string.Empty;
        public DateTime DateCreation { get; set; } = DateTime.Now;  
        
    }
}
