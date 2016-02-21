using System.Data.SqlClient;
using System;

class LocationClothesContentDB
{
    DBConnection connection;
    SqlCommand command;

    public LocationClothesContentDB()
    {
        connection = new DBConnection();
    }

    public void insert(LocationClothesContent locationClothesContent)
    {
        connection.open();
        command = new SqlCommand("insert into LocationClothesContent values('" + locationClothesContent.getName() + "' , '" + locationClothesContent.getPrice() + "' , '" + locationClothesContent.getQuantity() + "' , '" + locationClothesContent.getTotal() + "' , '" + locationClothesContent.getLocationClothesID() + "')", connection.getConnection());
        command.ExecuteNonQuery();
        connection.close();
    }

    public SqlDataReader fillListView(LocationClothesContent locationClothesContent)
    {
        connection.open();
        command = new SqlCommand("select * from LocationClothesContent where locationClothesID='" + locationClothesContent.getLocationClothesID() + "'", connection.getConnection());
        SqlDataReader reader = command.ExecuteReader();
        return reader;
    }

    public void delete(LocationClothesContent locationClothesContent)
    {
        connection.open();
        command = new SqlCommand("delete from LocationClothesContent where name='" + locationClothesContent.getName() + "' and locationClothesID='" + locationClothesContent.getLocationClothesID() + "'", connection.getConnection());
        command.ExecuteNonQuery();
        connection.close();
    }

    public void update(LocationClothesContent locationClothesContent)
    {
        connection.open();
        command = new SqlCommand("update LocationClothesContent set quantity='" + locationClothesContent.getQuantity() + "' where name='" + locationClothesContent.getName() + "' and locationClothesID='" + locationClothesContent.getLocationClothesID() + "'", connection.getConnection());
        command.ExecuteNonQuery();
        connection.close();
    }

    public bool checkIfExist(LocationClothesContent locationClothesContent)
    {
        connection.open();
        command = new SqlCommand("select count(*) from LocationClothesContent where name='" + locationClothesContent.getName() + "'", connection.getConnection());

        int count = (int)command.ExecuteScalar();
        connection.close();

        if (count > 0)
        {
            return true; // exiting item.
        }
        else
        {
            return false; // new item.
        }
    }
}
