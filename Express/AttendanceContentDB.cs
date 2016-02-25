using System.Data.SqlClient;

class AttendanceContentDB
{
    DBConnection connection;
    SqlCommand command;

    public AttendanceContentDB()
    {
        connection = new DBConnection();
    }
}
