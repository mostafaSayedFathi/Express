using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ApplicationDB
{
    private DBConnection connection;
    private SqlCommand command;
    private Source source;
    private SourceControl sourceControl;

    public ApplicationDB()
    {
        connection = new DBConnection();
    }

    public void insert(ApplicationForm application)
    {
        connection.open();
        command = new SqlCommand("insert into Application values('" + application.getName() + "' , '" + application.getSex() + "' , '" + application.getPhone() + "','" + application.getMobilePhone() + "','" + application.getFamilyPhone() + "','" + application.getAddress() + "','" + application.getBirthDate() + "','" + application.getNationalID() + "','" + application.getEducation() + "','" + application.getWorkHours() + "','" + application.getSalary() + "','" + application.getApplayDate() + "','" + application.getComment() + "','" + application.getState() + "','" + application.getSource() + "','" + application.getImage() + "')", connection.getConnection());
        command.ExecuteNonQuery();
        connection.close();
    }

    public Boolean checkApplication(ApplicationForm application)
    {
        connection.open();
        command = new SqlCommand("select count(*) from Application where nationalID='" + application.getNationalID() + "'", connection.getConnection());

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
