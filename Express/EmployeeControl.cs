using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

class EmployeeControl
{
    Employee employee;
    EmployeeDB employeeDB;
    LocationControl locationControl;
    SourceControl sourceControl;
    DBConnection connection;

    public void insertEmployee(string nationalID, string employeeName, string date, string position, double salary, string locationName, string sourceName)
    {
        employee = new Employee();
        employeeDB = new EmployeeDB();
        locationControl = new LocationControl();
        sourceControl = new SourceControl();
        employee.setNationalID(nationalID);
        employee.setName(employeeName);
        employee.setEmployDate(date);
        employee.setPosition(position);
        employee.setSalary(salary);
        int locationID = locationControl.getEmployeeLocationID(locationName);
        int sourceID = sourceControl.selectID(sourceName);
        employee.setLocationID(locationID);
        employee.setSourceID(sourceID);
        employeeDB.insertEmployee(employee);
    }

    public void update(string nationalID, string employeeName, string date, string position, double salary, string locationName, string sourceName, int ID)
    {
        employee = new Employee();
        employeeDB = new EmployeeDB();
        locationControl = new LocationControl();
        sourceControl = new SourceControl();
        employee.setNationalID(nationalID);
        employee.setName(employeeName);
        employee.setEmployDate(date);
        employee.setPosition(position);
        employee.setSalary(salary);
        int locationID = locationControl.getEmployeeLocationID(locationName);
        int sourceID = sourceControl.selectID(sourceName);
        employee.setLocationID(locationID);
        employee.setSourceID(sourceID);
        employee.setID(ID);
        employeeDB.update(employee);
    }

    public int lastIDPlusOne()
    {
        employee = new Employee();
        employeeDB = new EmployeeDB();
        employeeDB.selectLastID(employee);
        return employee.getID() + 1;
    }

    public int availableSecurityInLocation(string locationName)
    {
        locationControl = new LocationControl();
        employee = new Employee();
        employeeDB = new EmployeeDB();
        int locationID = locationControl.getEmployeeLocationID(locationName);
        employee.setLocationID(locationID);
        employeeDB.countSecurityInLocation(employee);
        return locationControl.getSecurityNumbers() - employee.getNumberOfEmployee();
    }

    public int availableSupervisorInLocation(string locationName)
    {
        locationControl = new LocationControl();
        employee = new Employee();
        employeeDB = new EmployeeDB();
        int locationID = locationControl.getEmployeeLocationID(locationName);
        employee.setLocationID(locationID);
        employeeDB.countSupervisorInLocation(employee);
        return locationControl.getSupervisorNumbers() - employee.getNumberOfEmployee();
    }

    public int availableManagerInLocation(string locationName)
    {
        locationControl = new LocationControl();
        employee = new Employee();
        employeeDB = new EmployeeDB();
        int locationID = locationControl.getEmployeeLocationID(locationName);
        employee.setLocationID(locationID);
        employeeDB.countManagerInLocation(employee);
        return locationControl.getManagerNumbers() - employee.getNumberOfEmployee();
    }

    public string getEmployeeName(int ID)
    {
        employee = new Employee();
        employeeDB = new EmployeeDB();
        employee.setID(ID);
        employeeDB.selectEmployeeName(employee);
        return employee.getName();
    }

    public string getEmployDate(int ID)
    {
        employee = new Employee();
        employeeDB = new EmployeeDB();
        employee.setID(ID);
        employeeDB.selectEmployDate(employee);
        return employee.getEmployDate();
    }

    public double getSalary(int ID)
    {
        employee = new Employee();
        employeeDB = new EmployeeDB();
        employee.setID(ID);
        employeeDB.selectSalary(employee);
        return employee.getSalary();
    }

    public string getPosition(int ID)
    {
        employee = new Employee();
        employeeDB = new EmployeeDB();
        employee.setID(ID);
        employeeDB.selectPosition(employee);
        return employee.getPosition();
    }

    public string getNationalID(int ID)
    {
        employee = new Employee();
        employeeDB = new EmployeeDB();
        employee.setID(ID);
        employeeDB.selectNationalID(employee);
        return employee.getNationalID();
    }

    public string getLocationName(int ID)
    {
        employee = new Employee();
        employeeDB = new EmployeeDB();
        locationControl = new LocationControl();
        employee.setID(ID);
        employeeDB.selectLocationID(employee);
        int locationID = employee.getLocationID();
        return locationControl.getLocationName(locationID);
    }

    public string getLocationAddress(int ID)
    {
        employee = new Employee();
        employeeDB = new EmployeeDB();
        locationControl = new LocationControl();
        employee.setID(ID);
        employeeDB.selectLocationID(employee);
        int locationID = employee.getLocationID();
        return locationControl.getLocationAddress(locationControl.getLocationName(locationID));
    }

    public string getSourceName(int ID)
    {
        employee = new Employee();
        employeeDB = new EmployeeDB();
        sourceControl = new SourceControl();
        employee.setID(ID);
        employeeDB.selectSourceID(employee);
        int sourceID = employee.getSourceID();
        return sourceControl.selectSourceName(sourceID);
    }

    public int countEmployeeNumbersRelatedToSource(string sourceName , string dateFrom , string dateTo)
    {
        sourceControl = new SourceControl();
        employee = new Employee();
        employeeDB = new EmployeeDB();
        int sourceID = sourceControl.selectID(sourceName);
        employee.setSourceID(sourceID);
        employee.setDateFrom(dateFrom);
        employee.setDateTo(dateTo);
        employeeDB.countEmployeeNumbersRelatedToSource(employee);
        return employee.getNumberOfEmployee();
    }

    public void fillListViewForEvaluation(ListView listView , string sourceName , string dateFrom , string dateTo)
    {
        listView.Items.Clear();
        locationControl = new LocationControl();
        sourceControl = new SourceControl();
        employee = new Employee();
        employeeDB = new EmployeeDB();
        connection = new DBConnection();
        int sourceID = sourceControl.selectID(sourceName);
        employee.setSourceID(sourceID);
        employee.setDateFrom(dateFrom);
        employee.setDateTo(dateTo);
        SqlDataReader reader = employeeDB.fillListViewRelatedToSource(employee);
        while (reader.Read())
        {
            ListViewItem lvi = new ListViewItem(reader["ID"].ToString());
            lvi.SubItems.Add(reader["name"].ToString());
            lvi.SubItems.Add(reader["position"].ToString());
            int locationID = int.Parse(reader["locationID"].ToString());
            string locationName = locationControl.getLocationName(locationID);
            lvi.SubItems.Add(locationName);
            listView.Items.Add(lvi);
        }
        connection.close();
    }

    public Boolean checkEmployee(int ID)
    {
        employee = new Employee();
        employeeDB = new EmployeeDB();
        employee.setID(ID);
        Boolean check = employeeDB.checkEmployee(employee);
        if (check == true)
        {
            return true; 
        }
        else
        {
            return false; 
        }
        
    }
}
