using System.Data.SqlClient;

class LocationClothesDB
{
    DBConnection connection;
    SqlCommand command;

    public LocationClothesDB()
    {
        connection = new DBConnection();
    }

    public void insert(LocationClothes locationClothes)
    {
        connection.open();
        command = new SqlCommand("insert into LocationClothes values('" + locationClothes.getTotal() + "' , '" + locationClothes.getLocationID() + "')", connection.getConnection());
        command.ExecuteNonQuery();
        connection.close();
    }

    public void selectLastID(LocationClothes locationClothes)
    {
        connection.open();
        command = new SqlCommand("select top 1 ID from LocationClothes ORDER BY ID DESC", connection.getConnection());
        locationClothes.setID((int)command.ExecuteScalar());
        connection.close();
    }

    public void selectID(LocationClothes locationClothes)
    {
        connection.open();
        command = new SqlCommand("select ID from LocationClothes where locationID='" + locationClothes.getLocationID() + "'", connection.getConnection());
        locationClothes.setID((int)command.ExecuteScalar());
        connection.close();
    }

    public void selectTotal(LocationClothes locationClothes)
    {
        connection.open();
        command = new SqlCommand("select total from LocationClothes where locationID = '" + locationClothes.getLocationID() + "'", connection.getConnection());
        locationClothes.setTotal((double)command.ExecuteScalar());
        connection.close();
    }

    public void updateTotal(LocationClothes locationClothes)
    {
        connection.open();
        command = new SqlCommand("update LocationClothes set total='" + locationClothes.getTotal() + "' where locationID='" + locationClothes.getLocationID() + "'", connection.getConnection());
        command.ExecuteNonQuery();
        connection.close();
    }

    public bool checkIfLocationHasClothes(LocationClothes locationClothes)
    {
        connection.open();
        command = new SqlCommand("select count(*) from LocationClothes where locationID='" + locationClothes.getID() + "'", connection.getConnection());

        int count = (int)command.ExecuteScalar();
        connection.close();

        if (count > 0)
        {
            return true; // has clothes.
        }
        else
        {
            return false; // don't has.
        }
    }
}
