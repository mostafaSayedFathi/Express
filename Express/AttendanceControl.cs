using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

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

    public void fillDataGridViewLocationAttendance(DataGridView dataGridView, string locationName , int month , int year)
    {
        locationControl = new LocationControl();
        attendance = new Attendance();
        attendanceDB = new AttendanceDB();
        int locationID = locationControl.getID(locationName);
        attendance.setLocationID(locationID);
        attendance.setMonth(month);
        attendance.setYear(year);
        SqlDataAdapter adapter = attendanceDB.fillDataGridViewLocationAttendance(attendance);
        DataTable dataTable = new DataTable();
        adapter.Fill(dataTable);
        dataGridView.DataSource = dataTable;
    }
}
