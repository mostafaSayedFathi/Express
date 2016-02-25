using System.Data.SqlClient;

class AttendanceDB
{
    DBConnection connection;
    SqlCommand command;

    public AttendanceDB()
    {
        connection = new DBConnection();
    }
}
