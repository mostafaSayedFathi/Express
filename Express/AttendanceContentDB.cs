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

    public void update(AttendanceContent attendanceContent)
    {
        connection.open();
        command = new SqlCommand("update AttendanceContent set d1='" + attendanceContent.getDays()[0] + "' , d2='" + attendanceContent.getDays()[1] + "' , d3='" + attendanceContent.getDays()[2] + "' , d4='" + attendanceContent.getDays()[3] + "' , d5='" + attendanceContent.getDays()[4] + "' , d6='" + attendanceContent.getDays()[5] + "' , d7='" + attendanceContent.getDays()[6] + "' , d8='" + attendanceContent.getDays()[7] + "' , d9='" + attendanceContent.getDays()[8] + "' , d10='" + attendanceContent.getDays()[9] + "' , d11='" + attendanceContent.getDays()[10] + "' , d12='" + attendanceContent.getDays()[11] + "' , d13='" + attendanceContent.getDays()[12] + "' , d14='" + attendanceContent.getDays()[13] + "' , d15='" + attendanceContent.getDays()[14] + "' , d16='" + attendanceContent.getDays()[15] + "' , d17='" + attendanceContent.getDays()[16] + "' , d18='" + attendanceContent.getDays()[17] + "' , d19='" + attendanceContent.getDays()[18] + "' , d20='" + attendanceContent.getDays()[19] + "' , d21='" + attendanceContent.getDays()[20] + "' , d22='" + attendanceContent.getDays()[21] + "' , d23='" + attendanceContent.getDays()[22] + "' , d24='" + attendanceContent.getDays()[23] + "' , d25='" + attendanceContent.getDays()[24] + "' , d26='" + attendanceContent.getDays()[25] + "' , d27='" + attendanceContent.getDays()[26] + "' , d28='" + attendanceContent.getDays()[27] + "' , d29='" + attendanceContent.getDays()[28] + "' , d30='" + attendanceContent.getDays()[29] + "' , d31='" + attendanceContent.getDays()[30] + "' where attendanceID='" + attendanceContent.getAttendanceID() + "' and empID='" + attendanceContent.getEmpID() + "'", connection.getConnection());
        command.ExecuteNonQuery();
        connection.close();
    }
}
