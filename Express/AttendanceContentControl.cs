using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

class AttendanceContentControl
{
    AttendanceContent attendanceContent;
    AttendanceContentDB attendanceContentDB;
    AttendanceControl attendanceControl;

    public void insert(DataGridView dataGridView)
    {
        attendanceContent = new AttendanceContent();
        attendanceContentDB = new AttendanceContentDB();
        attendanceControl = new AttendanceControl();
        int attendanceID = attendanceControl.getLastID();
        List<string> list = new List<string>();

        foreach(DataGridViewRow row in dataGridView.Rows)
        {
            list.Clear();
            int code = int.Parse(row.Cells[0].Value.ToString());
            //string name = row.Cells[1].Value.ToString();
            list.Add(row.Cells[2].Value.ToString());
            list.Add(row.Cells[3].Value.ToString());
            list.Add(row.Cells[4].Value.ToString());
            list.Add(row.Cells[5].Value.ToString());
            list.Add(row.Cells[6].Value.ToString());
            list.Add(row.Cells[7].Value.ToString());
            list.Add(row.Cells[8].Value.ToString());
            list.Add(row.Cells[9].Value.ToString());
            list.Add(row.Cells[10].Value.ToString());
            list.Add(row.Cells[11].Value.ToString());
            list.Add(row.Cells[12].Value.ToString());
            list.Add(row.Cells[13].Value.ToString());
            list.Add(row.Cells[14].Value.ToString());
            list.Add(row.Cells[15].Value.ToString());
            list.Add(row.Cells[16].Value.ToString());
            list.Add(row.Cells[17].Value.ToString());
            list.Add(row.Cells[18].Value.ToString());
            list.Add(row.Cells[19].Value.ToString());
            list.Add(row.Cells[20].Value.ToString());
            list.Add(row.Cells[21].Value.ToString());
            list.Add(row.Cells[22].Value.ToString());
            list.Add(row.Cells[23].Value.ToString());
            list.Add(row.Cells[24].Value.ToString());
            list.Add(row.Cells[25].Value.ToString());
            list.Add(row.Cells[26].Value.ToString());
            list.Add(row.Cells[27].Value.ToString());
            list.Add(row.Cells[28].Value.ToString());
            list.Add(row.Cells[29].Value.ToString());
            list.Add(row.Cells[30].Value.ToString());
            list.Add(row.Cells[31].Value.ToString());
            list.Add(row.Cells[32].Value.ToString());
            attendanceContent.setDays(list);
            attendanceContent.setEmpID(code);
            attendanceContent.setAttendanceID(attendanceID);
            attendanceContentDB.insert(attendanceContent);
        }
    }

    public void update(int month, int year, string locationName, DataGridView dataGridView)
    {
        attendanceControl = new AttendanceControl();
        attendanceContent = new AttendanceContent();
        attendanceContentDB = new AttendanceContentDB();
        int attendanceID = attendanceControl.getID(month, year, locationName);
        List<string> list = new List<string>();

        foreach(DataGridViewRow row in dataGridView.Rows)
        {
            list.Clear();
            int code = int.Parse(row.Cells[0].Value.ToString());
            //string name = row.Cells[1].Value.ToString();
            list.Add(row.Cells[2].Value.ToString());
            list.Add(row.Cells[3].Value.ToString());
            list.Add(row.Cells[4].Value.ToString());
            list.Add(row.Cells[5].Value.ToString());
            list.Add(row.Cells[6].Value.ToString());
            list.Add(row.Cells[7].Value.ToString());
            list.Add(row.Cells[8].Value.ToString());
            list.Add(row.Cells[9].Value.ToString());
            list.Add(row.Cells[10].Value.ToString());
            list.Add(row.Cells[11].Value.ToString());
            list.Add(row.Cells[12].Value.ToString());
            list.Add(row.Cells[13].Value.ToString());
            list.Add(row.Cells[14].Value.ToString());
            list.Add(row.Cells[15].Value.ToString());
            list.Add(row.Cells[16].Value.ToString());
            list.Add(row.Cells[17].Value.ToString());
            list.Add(row.Cells[18].Value.ToString());
            list.Add(row.Cells[19].Value.ToString());
            list.Add(row.Cells[20].Value.ToString());
            list.Add(row.Cells[21].Value.ToString());
            list.Add(row.Cells[22].Value.ToString());
            list.Add(row.Cells[23].Value.ToString());
            list.Add(row.Cells[24].Value.ToString());
            list.Add(row.Cells[25].Value.ToString());
            list.Add(row.Cells[26].Value.ToString());
            list.Add(row.Cells[27].Value.ToString());
            list.Add(row.Cells[28].Value.ToString());
            list.Add(row.Cells[29].Value.ToString());
            list.Add(row.Cells[30].Value.ToString());
            list.Add(row.Cells[31].Value.ToString());
            list.Add(row.Cells[32].Value.ToString());
            attendanceContent.setDays(list);
            attendanceContent.setEmpID(code);
            attendanceContent.setAttendanceID(attendanceID);
            attendanceContentDB.update(attendanceContent);
        }
    }

    public void insertUpdate(int month , int year , string locationName , DataGridView dataGridView)
    {
        attendanceControl = new AttendanceControl();
        bool flag = attendanceControl.checkIfLocationAttendanceSubmitted(month, year, locationName);
        if (flag == true)
        {
            //submitted //update
            this.update(month, year, locationName, dataGridView);
        }
        else if (flag == false)
        {
            //not submitted //insert
            attendanceControl.insert(month, year, locationName);
            this.insert(dataGridView);
        }
    }
}
