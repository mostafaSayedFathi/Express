using System.Data.SqlClient;

class EmployeeDB
{
    DBConnection connection;
    SqlCommand command;

    public EmployeeDB()
    {
        connection = new DBConnection();
    }

    public void insertEmployee(Employee employee)
    {
        connection.open();
        command = new SqlCommand("insert into Employee values('"+employee.getName()+"' , '"+employee.getEmployDate()+"' , '"+employee.getSalary()+"' , '"+employee.getPosition()+"' , '"+employee.getNationalID()+"' , '"+employee.getLocationID()+"' , '"+employee.getSourceID()+"')", connection.getConnection());
        command.ExecuteNonQuery();
        connection.close();
    }

    public void countSecurityInLocation(Employee employee)
    {
        connection.open();
        command = new SqlCommand("select COUNT(*) from Employee where position='موظف امن' and locationID='" + employee.getLocationID() + "'", connection.getConnection());
        employee.setNumberOfEmployee((int)command.ExecuteScalar());
        connection.close();
    }

    public void countSupervisorInLocation(Employee employee)
    {
        connection.open();
        command = new SqlCommand("select COUNT(*) from Employee where position='مشرف امن' and locationID='" + employee.getLocationID() + "'", connection.getConnection());
        employee.setNumberOfEmployee((int)command.ExecuteScalar());
        connection.close();
    }

    public void countManagerInLocation(Employee employee)
    {
        connection.open();
        command = new SqlCommand("select COUNT(*) from Employee where position='مدير موقع' and locationID='" + employee.getLocationID() + "'", connection.getConnection());
        employee.setNumberOfEmployee((int)command.ExecuteScalar());
        connection.close();
    }

    public void selectLastID(Employee employee)
    {
        connection.open();
        try
        {
            command = new SqlCommand("SELECT TOP 1 ID FROM Employee ORDER BY ID DESC", connection.getConnection());
            employee.setID((int)command.ExecuteScalar());
        }
        catch
        {
            employee.setID(0);
        }
        connection.close();
    }
}
