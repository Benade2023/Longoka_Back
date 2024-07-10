using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longoka.Domain.DAO
{
    public class AnneeScolaires
    {
        public Guid AnneeId { get; set; }
        public string AnneeScolaire {  get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin {  get; set; }
        public string Description { get; set; }
        public Guid EcoleId { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
