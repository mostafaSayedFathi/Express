using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

class EmployeeControl
{
    Employee employee;
    EmployeeDB employeeDB;
    LocationControl locationControl;
    SourceControl sourceControl;

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
}
