using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longoka.Domain.DAO
{
    public class Matieres
    {
        public Guid MatiereId { get; set; }
        public string Niveau {  get; set; }
        public string MatiereName { get; set; }
        public string[] Classe { get; set; }
        public Guid EcoleId { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
