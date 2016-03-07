using System.Data.SqlClient;

class LocationEquipsContentDB
{
    DBConnection connection;
    SqlCommand command;

    public LocationEquipsContentDB()
    {
        connection = new DBConnection();
    }

    public void insert(LocationEquipsContent locationEquipsContent)
    {
        connection.open();
        command = new SqlCommand("insert into LocationEquipsContent values('" + locationEquipsContent.getName() + "' , '" + locationEquipsContent.getPrice() + "' , '" + locationEquipsContent.getQuantity() + "' , '" + locationEquipsContent.getTotal() + "' , '" + locationEquipsContent.getLocationClothesID() + "')", connection.getConnection());
        command.ExecuteNonQuery();
        connection.close();
    }

    public SqlDataReader fillListView(LocationEquipsContent locationEquipsContent)
    {
        connection.open();
        command = new SqlCommand("select * from LocationEquipsContent where locationEquipsID='" + locationEquipsContent.getLocationClothesID() + "'", connection.getConnection());
        SqlDataReader reader = command.ExecuteReader();
        return reader;
    }

    public void delete(LocationEquipsContent locationEquipsContent)
    {
        connection.open();
        command = new SqlCommand("delete from LocationEquipsContent where name='" + locationEquipsContent.getName() + "' and locationEquipsID='" + locationEquipsContent.getLocationClothesID() + "'", connection.getConnection());
        command.ExecuteNonQuery();
        connection.close();
    }

    public void update(LocationEquipsContent locationEquipsContent)
    {
        connection.open();
        command = new SqlCommand("update LocationEquipsContent set quantity='" + locationEquipsContent.getQuantity() + "' where name='" + locationEquipsContent.getName() + "' and locationEquipsID='" + locationEquipsContent.getLocationClothesID() + "'", connection.getConnection());
        command.ExecuteNonQuery();
        connection.close();
    }

    public void updateItem(LocationEquipsContent locationEquipsContent)
    {
        connection.open();
        command = new SqlCommand("update LocationEquipsContent set quantity='" + locationEquipsContent.getQuantity() + "' , total='"+locationEquipsContent.getTotal()+"' where name='" + locationEquipsContent.getName() + "' and locationEquipsID='" + locationEquipsContent.getLocationClothesID() + "'", connection.getConnection());
        command.ExecuteNonQuery();
        connection.close();
    }

    public bool checkIfExist(LocationEquipsContent locationEquipsContent)
    {
        connection.open();
        command = new SqlCommand("select count(*) from LocationEquipsContent where name='" + locationEquipsContent.getName() + "'", connection.getConnection());

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
