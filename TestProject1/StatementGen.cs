using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    [TestClass]
    public class StatementGen
    {
        [TestMethod]
        public void GenSQLTableString()
        {
            using var mssqlConnection = new SqlConnection(MSSQL_CONNECTION_STRING);
            mssqlConnection.Open();

            Debug.Print(StringGen.GenCreateTableStatement(mssqlConnection, "table1"));
        }

        [TestMethod]
        public void GenSqliteDBFromSchema()
        {
            using var mssqlConnection = new SqlConnection(MSSQL_CONNECTION_STRING);
            mssqlConnection.Open();

            foreach (string createTableStatement in StringGen.GenCreateTableStatementsFromMSSQLSchema(mssqlConnection, "test_schema"))
            {
                Debug.Print(createTableStatement);
            }
        }

    }
}
