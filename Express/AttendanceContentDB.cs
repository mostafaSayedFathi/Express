using System.Data.SqlClient;

class AttendanceContentDB
{
    DBConnection connection;
    SqlCommand command;

    public AttendanceContentDB()
    {
        connection = new DBConnection();
    }

    public void insert(AttendanceContent attendanceContent)
    {
        connection.open();
        command = new SqlCommand("insert into AttendanceContent values('" + attendanceContent.getAttendanceID() + "' , '" + attendanceContent.getEmpID() + "' , '" + attendanceContent.getDays()[0] + "' , '" + attendanceContent.getDays()[1] + "' , '" + attendanceContent.getDays()[2] + "' , '" + attendanceContent.getDays()[3] + "' , '" + attendanceContent.getDays()[4] + "' , '" + attendanceContent.getDays()[5] + "' , '" + attendanceContent.getDays()[6] + "' , '" + attendanceContent.getDays()[7] + "' , '" + attendanceContent.getDays()[8] + "' , '" + attendanceContent.getDays()[9] + "' , '" + attendanceContent.getDays()[10] + "' , '" + attendanceContent.getDays()[11] + "' , '" + attendanceContent.getDays()[12] + "' , '" + attendanceContent.getDays()[13] + "' , '" + attendanceContent.getDays()[14] + "' , '" + attendanceContent.getDays()[15] + "' , '" + attendanceContent.getDays()[16] + "' , '" + attendanceContent.getDays()[17] + "' , '" + attendanceContent.getDays()[18] + "' , '" + attendanceContent.getDays()[19] + "' , '" + attendanceContent.getDays()[20] + "' , '" + attendanceContent.getDays()[21] + "' , '" + attendanceContent.getDays()[22] + "' , '" + attendanceContent.getDays()[23] + "' , '" + attendanceContent.getDays()[24] + "' , '" + attendanceContent.getDays()[25] + "' , '" + attendanceContent.getDays()[26] + "' , '" + attendanceContent.getDays()[27] + "' , '" + attendanceContent.getDays()[28] + "' , '" + attendanceContent.getDays()[29] + "' , '" + attendanceContent.getDays()[30] + "')", connection.getConnection());
        command.ExecuteNonQuery();
        connection.close();
    }
}
