using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longoka.Domain.DAO
{
    public class Ecoles
    {
        public Guid EcoleId { get; set; }
        public string NameEcole { get; set; }
        public string TypeEcole { get; set; }
        public int NumeroRue { get; set; }
        public string RueName { get; set; }
        public string Quartier { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
        public string TelephoneEcole { get; set; }
        public string EmailEcole { get; set; }
        public string SiteWeb { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
