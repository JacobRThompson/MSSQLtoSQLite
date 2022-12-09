namespace MSSQLtoSQLite
{
    using System.Data;
    using System.Data.SqlClient;
    using System.Data.SQLite;
    using System.Text;

    static public class StringGen
    {
        static internal readonly Dictionary<string, bool> MSSQLYesNoMap = new()
        {
            {"YES", true},
            {"NO", false},
        };

        public static IEnumerable<string> GenCreateTableStatementsFromMSSQLSchema(SqlConnection mssqlConn, string schemaName)
        {
            var mssqlSchema = mssqlConn.GetSchema("Tables", new string[] { null!, schemaName });

            // Create a new table in the SQLite database for each table in the MSSQL schema
            string tableName;
            foreach (DataRow row in mssqlSchema.Rows)
            {
                tableName = row["TABLE_NAME"].ToString()!;
                yield return GenCreateTableStatement(mssqlConn, tableName);
            }
        }

        /// <summary>
        /// Generates a CREATE TABLE statement for the specified MSSQL table.
        /// </summary>
        /// <param name="mssqlConn">An open SqlConnection to the MSSQL database.</param>
        /// <param name="mssqlTableName">The name of the MSSQL table for which to generate a CREATE TABLE statement.</param>
        /// <returns>A string containing the generated CREATE TABLE statement.</returns>
        public static string GenCreateTableStatement(SqlConnection mssqlConn, string mssqlTableName)
        {
            
            //Create object that will eventually become the generated statement
            StringBuilder createTableStatement = new StringBuilder($"CREATE TABLE {mssqlTableName} (");

            // Add a column definition for each column in the MSSQL table
            var mssqlTable = mssqlConn.GetSchema("Columns", new string[] { null!, null!, mssqlTableName });
            foreach (DataRow column in mssqlTable.Rows)
            {
                
                string columnName = column["COLUMN_NAME"].ToString()!;

                //column["IS_NULLABLE"] returns either the string "YES" or NO. Because of this we use a dict to convert to bool
                bool isNullable = MSSQLYesNoMap[column["IS_NULLABLE"].ToString()!];
                MSSQLType mssqlDataType = column["DATA_TYPE"]
                    .ToString()!
                    .ToMSSQLType();

                // Use the ToSQLiteType extension method to map the MSSQL data type to the corresponding SQLite data type
                SQLiteType sqliteDataType = mssqlDataType.ToSQLiteType();

                // Add the column definition to the CREATE TABLE statement
                createTableStatement.AppendLine($"{columnName} {sqliteDataType}{(isNullable ? "" : " NOT NULL")},");
            }

            //Primary key definition:
            List<string> primaryKeyColumns = new();

            SqlCommand getPrimaryKeysCmd = new(
                    $"SELECT COLUMN_NAME FROM " +
                    $"INFORMATION_SCHEMA.KEY_COLUMN_USAGE " +
                    $"WHERE OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + QUOTENAME(CONSTRAINT_NAME)), 'IsPrimaryKey') = 1" +
                    $"AND TABLE_NAME = '{mssqlTableName}'",
                    mssqlConn);

            using(SqlDataReader reader = getPrimaryKeysCmd.ExecuteReader())
            {
                // Loop through the rows in the results
                while (reader.Read())
                {
                    // Add the primary key column to the list
                    primaryKeyColumns.Add(reader.GetString(0));
                }
            }

            createTableStatement.AppendLine($"PRIMARY KEY ({string.Join(",", primaryKeyColumns)})");

            //Close up the SQL Query
            createTableStatement.AppendLine(")");

            return createTableStatement.ToString();
        }

    }
}