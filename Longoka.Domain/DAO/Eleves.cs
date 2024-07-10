using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longoka.Domain.DAO
{
    public class Eleves
    {
        public Guid EleveId { get; set; }
        public Guid UserId { get; set; }
        public Guid EcoleId { get; set; }
        public Guid ProfileId { get; set; }
        public Guid ClasseId { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
