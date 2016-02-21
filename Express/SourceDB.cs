using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SourceDB
{
    private DBConnection connection;
    private SqlCommand command;

    public SourceDB()
    {
        connection = new DBConnection();
    }

    public void insert(Source source)
    {
        connection.open();
        command = new SqlCommand("insert into Source values('" + source.getName() + "' , '" + source.getPhone1() + "' , '" + source.getPhone2() + "','" + source.getPhone3() + "','" + source.getEmployeeName1() + "','" + source.getEmployeeName1() + "','" + source.getAddress() + "')", connection.getConnection());
        command.ExecuteNonQuery();
        connection.close();
    }

    public Boolean checkSource(Source source)
    {
        connection.open();
        command = new SqlCommand("select count(*) from Source where sourceName='" + source.getName() + "'", connection.getConnection());

        int check = (int)command.ExecuteScalar();
        connection.close();

        if (check > 0)
        {
            return true; // exiting price.
        }
        else
        {
            return false; // new price.
        }
    }

    public int selectSourceId(Source source)
    {
        connection.open();
        command = new SqlCommand("select ID from Source where sourceName='" + source.getName() + "'", connection.getConnection());
        int ID = (int)command.ExecuteScalar();
        connection.close();
        return ID;
    }

    public SqlDataReader fillComboboxSourceName()
    {
        connection.open();
        command = new SqlCommand("select sourceName from Source", connection.getConnection());
        SqlDataReader reader = command.ExecuteReader();
        return reader;
    }
}

