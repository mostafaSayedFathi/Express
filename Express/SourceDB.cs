﻿using System;
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

    public void update(Source source)
    {
        connection.open();
        command = new SqlCommand("update Source set sourceName='" + source.getName() + "' , phone1='" + source.getPhone1() + "' , phone2='" + source.getPhone2() + "' , phone3='" + source.getPhone3() + "' , employee1='" + source.getEmployeeName1() + "' , employee2='" + source.getEmployeeName2() + "' , address='"+source.getAddress()+"' where ID='"+source.getID()+"'", connection.getConnection());
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

    public void selectSourceName(Source source)
    {
        connection.open();
        command = new SqlCommand("select sourceName from Source where ID='" + source.getID() + "'", connection.getConnection());
        source.setName(command.ExecuteScalar() as string);
        connection.close();
    }

    public void selectSourceAdress(Source source)
    {
        connection.open();
        command = new SqlCommand("select address from Source where ID='" + source.getID() + "'", connection.getConnection());
        source.setAddress(command.ExecuteScalar() as string);
        connection.close();
    }

    public void selectEmployeeName1(Source source)
    {
        connection.open();
        command = new SqlCommand("select employee1 from Source where ID='" + source.getID() + "'", connection.getConnection());
        source.setEmployeeName1(command.ExecuteScalar() as string);
        connection.close();
    }

    public void selectEmployeeName2(Source source)
    {
        connection.open();
        command = new SqlCommand("select employee2 from Source where ID='" + source.getID() + "'", connection.getConnection());
        source.setEmployeeName2(command.ExecuteScalar() as string);
        connection.close();
    }

    public void selectPhone1(Source source)
    {
        connection.open();
        command = new SqlCommand("select phone1 from Source where ID='" + source.getID() + "'", connection.getConnection());
        source.setPhone1(command.ExecuteScalar() as string);
        connection.close();
    }

    public void selectPhone2(Source source)
    {
        connection.open();
        command = new SqlCommand("select phone2 from Source where ID='" + source.getID() + "'", connection.getConnection());
        source.setPhone2(command.ExecuteScalar() as string);
        connection.close();
    }

    public void selectPhone3(Source source)
    {
        connection.open();
        command = new SqlCommand("select phone3 from Source where ID='" + source.getID() + "'", connection.getConnection());
        source.setPhone3(command.ExecuteScalar() as string);
        connection.close();
    }
}

