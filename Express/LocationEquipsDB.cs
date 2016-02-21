using System.Data.SqlClient;

class LocationEquipsDB
{
    DBConnection connection;
    SqlCommand command;

    public LocationEquipsDB()
    {
        connection = new DBConnection();
    }

    public void insert(LocationEquips locationEquips)
    {
        connection.open();
        command = new SqlCommand("insert into LocationEquips values('" + locationEquips.getTotal() + "' , '" + locationEquips.getLocationID() + "')", connection.getConnection());
        command.ExecuteNonQuery();
        connection.close();
    }

    public void selectLastID(LocationEquips locationEquips)
    {
        connection.open();
        command = new SqlCommand("select TOP 1 ID from LocationEquips ORDER BY ID DESC", connection.getConnection());
        locationEquips.setID((int)command.ExecuteScalar());
        connection.close();
    }

    public void selectID(LocationEquips locationEquips)
    {
        connection.open();
        command = new SqlCommand("select ID from LocationEquips where locationID='" + locationEquips.getLocationID() + "'", connection.getConnection());
        locationEquips.setID((int)command.ExecuteScalar());
        connection.close();
    }

    public void getTotal(LocationEquips locationEquips)
    {
        connection.open();
        command = new SqlCommand("select total from LocationEquips where locationID = '" + locationEquips.getLocationID() + "'", connection.getConnection());
        locationEquips.setTotal((double)command.ExecuteScalar());
        connection.close();
    }

    public void updateTotal(LocationEquips locationEquips)
    {
        connection.open();
        command = new SqlCommand("update LocationEquips set total='" + locationEquips.getTotal() + "' where locationID='" + locationEquips.getLocationID() + "'", connection.getConnection());
        command.ExecuteNonQuery();
        connection.close();
    }

    public bool checkIfLocationHasDevices(LocationEquips locationEquips)
    {
        connection.open();
        command = new SqlCommand("select count(*) from LocationEquips where locationID='" + locationEquips.getID() + "'", connection.getConnection());

        int count = (int)command.ExecuteScalar();
        connection.close();

        if (count > 0)
        {
            return true; // has devices.
        }
        else
        {
            return false; // don't has.
        }
    }
}
