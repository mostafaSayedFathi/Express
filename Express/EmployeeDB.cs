using System;
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

    public void update(Employee employee)
    {
        connection.open();
        command = new SqlCommand("update Employee set name='"+employee.getName()+"' , employDate='"+employee.getEmployDate()+"' , salary='"+employee.getSalary()+"' , position='"+employee.getPosition()+"' , nationalID='"+employee.getNationalID()+"' , locationID='"+employee.getLocationID()+"' , sourceID='"+employee.getSourceID()+"' where ID='"+employee.getID()+"'", connection.getConnection());
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

    public void selectEmployeeName(Employee employee)
    {
        connection.open();
        command = new SqlCommand("select name from Employee where ID='"+employee.getID()+"'", connection.getConnection());
        employee.setName(command.ExecuteScalar() as string);
        connection.close();
    }

    public void selectEmployDate(Employee employee)
    {
        connection.open();
        command = new SqlCommand("select employDate from Employee where ID='" + employee.getID() + "'", connection.getConnection());
        employee.setEmployDate(command.ExecuteScalar().ToString());
        connection.close();
    }

    public void selectSalary(Employee employee)
    {
        connection.open();
        command = new SqlCommand("select salary from Employee where ID='" + employee.getID() + "'", connection.getConnection());
        employee.setSalary((double)command.ExecuteScalar());
        connection.close();
    }

    public void selectPosition(Employee employee)
    {
        connection.open();
        command = new SqlCommand("select position from Employee where ID='" + employee.getID() + "'", connection.getConnection());
        employee.setPosition(command.ExecuteScalar() as string);
        connection.close();
    }

    public void selectNationalID(Employee employee)
    {
        connection.open();
        command = new SqlCommand("select nationalID from Employee where ID='" + employee.getID() + "'", connection.getConnection());
        employee.setNationalID(command.ExecuteScalar() as string);
        connection.close();
    }

    public void selectLocationID(Employee employee)
    {
        connection.open();
        command = new SqlCommand("select locationID from Employee where ID='" + employee.getID() + "'", connection.getConnection());
        employee.setLocationID((int)command.ExecuteScalar());
        connection.close();
    }

    public void selectSourceID(Employee employee)
    {
        connection.open();
        command = new SqlCommand("select sourceID from Employee where ID='" + employee.getID() + "'", connection.getConnection());
        employee.setSourceID((int)command.ExecuteScalar());
        connection.close();
    }

    public void countEmployeeNumbersRelatedToSource(Employee employee)
    {
        connection.open();
        command = new SqlCommand("select COUNT(*) from Employee where sourceID='"+employee.getSourceID()+"' and employDate between '"+employee.getDateFrom()+"' and '"+employee.getDateTo()+"'", connection.getConnection());
        employee.setNumberOfEmployee((int)command.ExecuteScalar());
        connection.close();
    }

    public SqlDataReader fillListViewRelatedToSource(Employee employee)
    {
        connection.open();
        command = new SqlCommand("select * from Employee where sourceID='" + employee.getSourceID() + "' and employDate between '" + employee.getDateFrom() + "' and '" + employee.getDateTo() + "'", connection.getConnection());
        SqlDataReader reader = command.ExecuteReader();
        return reader;
    }

    public Boolean checkEmployee(Employee employee)
    {
        connection.open();
        command = new SqlCommand("select count(*) from Employee where ID='" + employee.getID() + "'", connection.getConnection());

        int check = (int)command.ExecuteScalar();
        connection.close();

        if (check > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}
