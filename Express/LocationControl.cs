using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

class LocationControl
{
    DBConnection connection;
    Location location;
    LocationDB locationDB;

    public void insertLocation(string locationName, string locationAddress, string startdate, string endDate, int securityNumbers, int supervisorNumbers, int managerNumbers, int workHours)
    {
        location = new Location();
        locationDB = new LocationDB();
        location.setName(locationName);
        location.setAddress(locationAddress);
        location.setStartDate(startdate);
        location.setEndDate(endDate);
        location.setSecurityNumbers(securityNumbers);
        location.setSupervisorNumbers(supervisorNumbers);
        location.setManagerNumbers(managerNumbers);
        location.setWorkHours(workHours);
        locationDB.insertNewLocation(location);
    }

    public void updateLocation(string previousLocationName, string locationName, string locationAddress, string startdate, string endDate, int securityNumbers, int supervisorNumbers, int managerNumbers, int workHours)
    {
        location = new Location();
        locationDB = new LocationDB();
        int ID = getID(previousLocationName);
        location.setID(ID);
        location.setName(locationName);
        location.setAddress(locationAddress);
        location.setStartDate(startdate);
        location.setEndDate(endDate);
        location.setSecurityNumbers(securityNumbers);
        location.setSupervisorNumbers(supervisorNumbers);
        location.setManagerNumbers(managerNumbers);
        location.setWorkHours(workHours);
        locationDB.updateLocationInformation(location);
    }

    public void updateLocationCost(string locationName, double securitySalary, double supervisorSalary, double managerSalary)
    {
        location = new Location();
        locationDB = new LocationDB();
        location.setName(locationName);
        location.setSecuritySalary(securitySalary);
        location.setSupervisorSalary(supervisorSalary);
        location.setManagerSalary(managerSalary);
        locationDB.updateLocation(location);
    }

    public void fillComboboxLocationName(ComboBox comboBox)
    {
        comboBox.Items.Clear();
        locationDB = new LocationDB();
        connection = new DBConnection();
        SqlDataReader reader = locationDB.fillComboboxLocationName();
        while (reader.Read())
        {
            comboBox.Items.Add(reader["name"]);
        }
        connection.close();
    }

    public void fillComboboxLocationNameReady(ComboBox comboBox)
    {
        comboBox.Items.Clear();
        locationDB = new LocationDB();
        connection = new DBConnection();
        SqlDataReader reader = locationDB.fillComboboxLocationNameReaday();
        while (reader.Read())
        {
            comboBox.Items.Add(reader["name"]);
        }
        connection.close();
    }

    public void getLocationID(string locationName)
    {
        locationDB = new LocationDB();
        location = new Location();
        location.setName(locationName);
        locationDB.selectLocationIDbyName(location);
    }

    public int getID(string locationName)
    {
        locationDB = new LocationDB();
        location = new Location();
        location.setName(locationName);
        locationDB.selectLocationIDbyName(location);
        return location.getID();
    }

    public int getSecurityNumbers()
    {
        locationDB = new LocationDB();
        locationDB.selectSecurityNumbers(location);
        int securityNumbers = location.getSecurityNumbers();
        return securityNumbers;
    }

    public int getSupervisorNumbers()
    {
        locationDB = new LocationDB();
        locationDB.selectSupervisorNumbers(location);
        int supervisorNumbers = location.getSupervisorNumbers();
        return supervisorNumbers;
    }

    public int getManagerNumbers()
    {
        locationDB = new LocationDB();
        locationDB.selectManagerNumbers(location);
        int managerNumbers = location.getManagerNumbers();
        return managerNumbers;
    }

    public double getSecuritySalary(string locationName)
    {
        location = new Location();
        locationDB = new LocationDB();
        location.setName(locationName);
        locationDB.selectSecuritySalary(location);
        return location.getSecuritySalary();
    }

    public double getSupervisorSalary(string locationName)
    {
        location = new Location();
        locationDB = new LocationDB();
        location.setName(locationName);
        locationDB.selectSupervisorSalary(location);
        return location.getSupervisorSalary();
    }

    public double getManagerSalary(string locationName)
    {
        location = new Location();
        locationDB = new LocationDB();
        location.setName(locationName);
        locationDB.selectManagerSalary(location);
        return location.getManagerSalary();
    }

    public string getLocationAddress(string locationName)
    {
        location = new Location();
        locationDB = new LocationDB();
        location.setName(locationName);
        locationDB.selectAddress(location);
        return location.getAddress();
    }

    public string getStartDate(string locationName)
    {
        location = new Location();
        locationDB = new LocationDB();
        location.setName(locationName);
        locationDB.selectStartDate(location);
        return location.getStartDate();
    }

    public string getEndDate(string locationName)
    {
        location = new Location();
        locationDB = new LocationDB();
        location.setName(locationName);
        locationDB.selectEndDate(location);
        return location.getEndDate();
    }

    public int getLocationSecurityNumbers(string locationName)
    {
        location = new Location();
        locationDB = new LocationDB();
        location.setName(locationName);
        locationDB.selectSecurityNumbers(location);
        int securityNumbers = location.getSecurityNumbers();
        return securityNumbers;
    }

    public int getLocationSupervisorNumbers(string locationName)
    {
        location = new Location();
        locationDB = new LocationDB();
        location.setName(locationName);
        locationDB.selectSupervisorNumbers(location);
        int supervisorNumbers = location.getSupervisorNumbers();
        return supervisorNumbers;
    }

    public int getLocationManagerNumbers(string locationName)
    {
        location = new Location();
        locationDB = new LocationDB();
        location.setName(locationName);
        locationDB.selectManagerNumbers(location);
        int managerNumbers = location.getManagerNumbers();
        return managerNumbers;
    }

    public int getLocationWorkHours(string locationName)
    {
        location = new Location();
        locationDB = new LocationDB();
        location.setName(locationName);
        locationDB.selectWorkHours(location);
        return location.getWorkHours();
    }

    public int getEmployeeLocationID(string locationName)
    {
        locationDB = new LocationDB();
        location = new Location();
        location.setName(locationName);
        locationDB.selectLocationIDbyName(location);
        return location.getID();
    }

}