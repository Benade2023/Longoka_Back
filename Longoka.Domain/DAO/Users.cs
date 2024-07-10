using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longoka.Domain.DAO
{
    public class Users
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string CompletName { get; set; }
        public DateTime Birthday { get; set; }
        public int NumeroRue {  get; set; }
        public string RueName { get; set; }
        public string Quartier { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
        public Guid EcoleId { get; set; }
        public Guid ProfileId { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
