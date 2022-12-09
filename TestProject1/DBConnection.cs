namespace TestProject1
{
    [TestClass]
    public class DBConnection
    {
        [TestMethod]
        public void MSSQLCanConnect()
        {
            using (var mssqlConnection = new SqlConnection(MSSQL_CONNECTION_STRING))
            {
                mssqlConnection.Open();
                mssqlConnection.Close();
            }
        }

        [TestMethod]
        public void SQLITECanConnect()
        {
            using (var sqliteConnection = new SQLiteConnection(SQLITE_CONNECTION_STRING))
            {
                sqliteConnection.Open();
                Debug.WriteLine(sqliteConnection.FileName);
                sqliteConnection.Close();
            }
        }

       
    }
}