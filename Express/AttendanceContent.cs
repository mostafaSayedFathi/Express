using System.Collections.Generic;

class AttendanceContent
{
    private int attendanceID;
    private int empID;
    private List<string> days;
    //private string d1, d2, d3, d4, d5, d6, d7, d8, d9, d10, d11, d12, d13, d14, d15, d16, d17, d18, d19, d20, d21, d22, d23, d24, d25, d26, d27, d28, d29, d30, d31;

    public void setAttendanceID(int attendanceID)
    {
        this.attendanceID = attendanceID;
    }
    public int getAttendanceID()
    {
        return attendanceID;
    }

    public void setEmpID(int empID)
    {
        this.empID = empID;
    }
    public int getEmpID()
    {
        return empID;
    }

    public void setDays(List<string> days)
    {
        this.days = days;
    }

    public List<string> getDays()
    {
        return days;
    }
}
