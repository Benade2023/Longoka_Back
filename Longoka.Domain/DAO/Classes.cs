using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longoka.Domain.DAO
{
    public class Classes
    {
        public Guid ClasseId { get; set; }
        public string Niveau {  get; set; }
        public string ClasseName { get; set; }
        public Guid EcoleId { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
