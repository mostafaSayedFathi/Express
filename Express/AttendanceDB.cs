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

    public SqlDataAdapter fillDataGridViewLocationAttendance(Attendance attendance)
    {
        connection.open();
        string query = "select Employee.ID,Employee.name,AttendanceContent.d1,AttendanceContent.d2,AttendanceContent.d3,AttendanceContent.d4,AttendanceContent.d5,AttendanceContent.d6,AttendanceContent.d7,AttendanceContent.d8,AttendanceContent.d9,AttendanceContent.d10,AttendanceContent.d11,AttendanceContent.d12,AttendanceContent.d13,AttendanceContent.d14,AttendanceContent.d15,AttendanceContent.d16,AttendanceContent.d17,AttendanceContent.d18,AttendanceContent.d19,AttendanceContent.d20,AttendanceContent.d21,AttendanceContent.d22,AttendanceContent.d23,AttendanceContent.d24,AttendanceContent.d25,AttendanceContent.d26,AttendanceContent.d27,AttendanceContent.d28,AttendanceContent.d29,AttendanceContent.d30,AttendanceContent.d31" +
            " from Employee" +
            " left join AttendanceContent" +
            " on Employee.ID = AttendanceContent.empID" +
            " join Attendance"+
            " on Employee.locationID = Attendance.locationID" +
            " where Employee.locationID='" + attendance.getLocationID() + "' and Attendance.month='" + attendance.getMonth() + "' and Attendance.year='"+attendance.getYear()+"'";
        command = new SqlCommand(query, connection.getConnection());
        SqlDataAdapter adapter = new SqlDataAdapter(command);
        return adapter;
    }
}
