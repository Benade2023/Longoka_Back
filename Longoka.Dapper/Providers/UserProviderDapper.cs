using Dapper;
using Longoka.Domain.DAO;
using Longoka.Domain.Interfaces;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Longoka.Dapper.Providers
{
    public class UserProviderDapper
    {
        private string _connexionString = string.Empty;
        private const string TABLENAME = "User";
        public UserProviderDapper(string connexionString)
        {
            _connexionString = connexionString;
        }
    }
}
