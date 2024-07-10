using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longoka.Domain.DAO
{
    public class Profiles
    {
        public Guid ProfileId { get; set; }
        public string ProfileName { get; set; }
        public string Description { get; set; }
        public Guid EcoleId { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
