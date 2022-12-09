using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    internal class Globals
    {
        public const string MSSQL_DB_NAME = "mssql_to_sqlite";

        public const string MSSQL_CONNECTION_STRING =
           $"Data Source=(localdb)\\ProjectModels;" +
           $"Initial Catalog={MSSQL_DB_NAME};" +
           $"Integrated Security=True;Connect Timeout=30;" +
           $"Encrypt=False;" +
           $"TrustServerCertificate=False;" +
           $"ApplicationIntent=ReadWrite;" +
           $"MultiSubnetFailover=False";

        public const string SQLITE_DB_NAME = "mssql_to_sqlite.sqlite";

        public const string SQLITE_CONNECTION_STRING =
           $"Data Source={SQLITE_DB_NAME};";
    }
}
