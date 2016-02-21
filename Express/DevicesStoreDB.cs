using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class DevicesStoreDB
{
    private DBConnection connection;
    private SqlCommand command;

    public DevicesStoreDB()
    {
        connection = new DBConnection();
    }

    public void insert(DevicesStore devicesStore)
    {
        connection.open();
        command = new SqlCommand("insert into EquipsStore values('" + devicesStore.getName() + "' , '" + devicesStore.getPrice() + "' , '" + devicesStore.getQuantity() + "','" + devicesStore.getTotal() + "')", connection.getConnection());
        command.ExecuteNonQuery();
        connection.close();
    }

    public void delete(DevicesStore devicesStore)
    {
        connection.open();
        command = new SqlCommand("delete from EquipsStore where name='" + devicesStore.getName() + "'", connection.getConnection());
        command.ExecuteNonQuery();
        connection.close();
    }

    public Boolean checkDevice(DevicesStore devicesStore)
    {
        connection.open();
        command = new SqlCommand("select count(*) from EquipsStore where name='" + devicesStore.getName() + "'", connection.getConnection());

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

    public void update(DevicesStore devicesStore)
    {
        connection.open();
        command = new SqlCommand("update EquipsStore set name='" + devicesStore.getName() + "',price='" + devicesStore.getPrice() + "',quantity='" + devicesStore.getQuantity() + "' ,total='" + devicesStore.getTotal() + "' where ID='" + devicesStore.getID() + "'", connection.getConnection());
        command.ExecuteNonQuery();
        connection.close();
    }

    public SqlDataReader fillListViewDevices()
    {
        connection.open();
        command = new SqlCommand("select * from EquipsStore", connection.getConnection());
        SqlDataReader reader = command.ExecuteReader();
        return reader;
    }

    public int selectDeviceId(DevicesStore devicesStore)
    {
        connection.open();
        command = new SqlCommand("select ID from EquipsStore where name='" + devicesStore.getName() + "'", connection.getConnection());
        int ID = (int)command.ExecuteScalar();
        connection.close();
        return ID;
    }

    public void selectPrice(DevicesStore devicesStore)
    {
        connection.open();
        command = new SqlCommand("select price from EquipsStore where name='" + devicesStore.getName() + "'", connection.getConnection());
        devicesStore.setPrice(double.Parse(command.ExecuteScalar().ToString()));
        connection.close();
    }

    public SqlDataReader fillComboboxDeviceName()
    {
        connection.open();
        command = new SqlCommand("select * from EquipsStore", connection.getConnection());
        SqlDataReader reader = command.ExecuteReader();
        return reader;
    }
}

