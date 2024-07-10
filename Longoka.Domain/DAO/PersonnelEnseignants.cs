using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longoka.Domain.DAO
{
    public class PersonnelEnseignants
    {
        public Guid PersonnelEnseignantId { get; set; }
        public string CompletName { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public int NumeroRue { get; set; }
        public string RueName { get; set; }
        public string Quartier { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid EcoleId { get; set; }
        public Matieres[] Matiere { get; set; }
        public Classes[] Classe { get; set; }
        public Guid ProfileId { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
