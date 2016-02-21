using System.Data.SqlClient;

class DBConnection
{
    private SqlConnection connection;

    public DBConnection()
    {
        string[] text = System.IO.File.ReadAllLines(@"C:\Server.txt");
        string serverName = text[0];
        connection = new SqlConnection("Data Source='"+serverName+"';Initial Catalog=Express;Integrated Security=True");
    }

    public void open()
    {
        connection.Open();
    }

    public void close()
    {
        connection.Close();
    }

    public SqlConnection getConnection()
    {
        return connection;
    }
}
