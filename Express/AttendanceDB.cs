using System.Data.SqlClient;

class AttendanceDB
{
    DBConnection connection;
    SqlCommand command;

    public AttendanceDB()
    {
        connection = new DBConnection();
    }

    public void insert(Attendance attendance)
    {
        connection.open();
        command = new SqlCommand("insert into Attendance values('"+attendance.getMonth()+"' , '"+attendance.getYear()+"' , '"+attendance.getLocationID()+"')", connection.getConnection());
        command.ExecuteNonQuery();
        connection.close();
    }

    public void selectLastID(Attendance attendance)
    {
        connection.open();
        command = new SqlCommand("select top 1 ID from Attendance ORDER BY ID DESC", connection.getConnection());
        attendance.setID((int)command.ExecuteScalar());
        connection.close();
    }

    public bool checkIfLocationAttendanceSubmitted(Attendance attendance)
    {
        connection.open();
        command = new SqlCommand("select count(*) from Attendance where month='" + attendance.getMonth() + "' and year='" + attendance.getYear() + "' and locationID='"+attendance.getLocationID()+"'", connection.getConnection());

        int count = (int)command.ExecuteScalar();
        connection.close();

        if (count > 0)
        {
            return true; // submitted before.
        }
        else
        {
            return false; // not submited before.
        }
    }

    public void selectID(Attendance attendance)
    {
        connection.open();
        command = new SqlCommand("select ID from Attendance where month='" + attendance.getMonth() + "' and year='" + attendance.getYear() + "' and locationID='" + attendance.getLocationID() + "'", connection.getConnection());
        attendance.setID((int)command.ExecuteScalar());
        connection.close();
    }
}
