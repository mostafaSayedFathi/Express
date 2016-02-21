using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Express
{
    class EmployeeControl
    {
        Employee employee;
        EmployeeDB employeeDB;
        LocationControl locationControl;
        SourceControl sourceControl;

        public void insertEmployee(string nationalID , string employeeName , string date  , string position , double salary , string locationName , string sourceName)
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
    }
}
