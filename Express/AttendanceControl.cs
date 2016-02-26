using System.Windows.Forms;

class AttendanceControl
{
    Attendance attendance;
    AttendanceDB attendanceDB;
    LocationControl locationControl;

    public void insert(int month, int year, string locationName)
    {
        locationControl = new LocationControl();
        attendance = new Attendance();
        attendanceDB = new AttendanceDB();
        int locationID = locationControl.getID(locationName);
        attendance.setMonth(month);
        attendance.setYear(year);
        attendance.setLocationID(locationID);
        attendanceDB.insert(attendance);
    }

    public void update(int month, int year, string locationName)
    {
    }

    public int getID(int month, int year, string locationName)
    {
        locationControl = new LocationControl();
        attendance = new Attendance();
        attendanceDB = new AttendanceDB();
        int locationID = locationControl.getID(locationName);
        attendance.setMonth(month);
        attendance.setYear(year);
        attendance.setLocationID(locationID);
        attendanceDB.selectID(attendance);
        return attendance.getID();
    }

    public int getLastID()
    {
        attendance = new Attendance();
        attendanceDB = new AttendanceDB();
        attendanceDB.selectLastID(attendance);
        return attendance.getID();
    }

    public bool checkIfLocationAttendanceSubmitted(int month, int year, string locationName)
    {
        locationControl = new LocationControl();
        attendance = new Attendance();
        attendanceDB = new AttendanceDB();
        int locationID = locationControl.getID(locationName);
        attendance.setMonth(month);
        attendance.setYear(year);
        attendance.setLocationID(locationID);
        bool flag = attendanceDB.checkIfLocationAttendanceSubmitted(attendance);
        return flag;
    }
}
