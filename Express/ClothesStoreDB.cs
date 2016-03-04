using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ClothesStoreDB
{
    private DBConnection connection;
    private SqlCommand command;

    public ClothesStoreDB()
    {
        connection = new DBConnection();

    }

    public void insert(ClothesStore clothesStore)
    {
        connection.open();
        command = new SqlCommand("insert into ClothesStore values('" + clothesStore.getName() + "' , '" + clothesStore.getPrice() + "' , '" + clothesStore.getQuantity() + "','" + clothesStore.getTotal() + "')", connection.getConnection());
        command.ExecuteNonQuery();
        connection.close();
    }

    public void delete(ClothesStore clothesStore)
    {
        connection.open();
        command = new SqlCommand("delete from ClothesStore where name='" + clothesStore.getName() + "'", connection.getConnection());
        command.ExecuteNonQuery();
        connection.close();
    }

    public Boolean checkCloth(ClothesStore clothesStore)
    {
        connection.open();
        command = new SqlCommand("select count(*) from ClothesStore where name='" + clothesStore.getName() + "'", connection.getConnection());

        int PriceCount = (int)command.ExecuteScalar();
        connection.close();

        if (PriceCount > 0)
        {
            return true; // exiting price.
        }
        else
        {
            return false; // new price.
        }
    }

    public void update(ClothesStore clothesStore)
    {
        connection.open();
        command = new SqlCommand("update ClothesStore set name='" + clothesStore.getName() + "',price='" + clothesStore.getPrice() + "',quantity='" + clothesStore.getQuantity() + "' ,total='" + clothesStore.getTotal() + "' where ID='" + clothesStore.getID() + "'", connection.getConnection());
        command.ExecuteNonQuery();
        connection.close();
    }

    public SqlDataReader fillListViewClothes()
    {
        connection.open();
        command = new SqlCommand("select * from ClothesStore", connection.getConnection());
        SqlDataReader reader = command.ExecuteReader();
        return reader;
    }

    public int selectClotheId(ClothesStore clothesStore)
    {
        connection.open();
        command = new SqlCommand("select ID from ClothesStore where name='" + clothesStore.getName() + "'", connection.getConnection());
        int ID = (int)command.ExecuteScalar();
        connection.close();
        return ID;
    }

    public void selectPrice(ClothesStore clothesStore)
    {
        connection.open();
        command = new SqlCommand("select price from ClothesStore where name='" + clothesStore.getName() + "'", connection.getConnection());
        clothesStore.setPrice(double.Parse(command.ExecuteScalar().ToString()));
        connection.close();
    }

    public SqlDataReader fillComboboxClothesName()
    {
        connection.open();
        command = new SqlCommand("select * from ClothesStore", connection.getConnection());
        SqlDataReader reader = command.ExecuteReader();
        return reader;
    }

    public void updateQuantityMinus(ClothesStore clothesStore)
    {
        connection.open();
        command = new SqlCommand("update ClothesStore set quantity=quantity-'"+clothesStore.getQuantity()+"' where name='" + clothesStore.getName() + "'", connection.getConnection());
        command.ExecuteNonQuery();
        connection.close();
    }

    public void selectQuantity(ClothesStore clothesStore)
    {
        connection.open();
        command = new SqlCommand("select quantity from ClothesStore where name='"+clothesStore.getName()+"'", connection.getConnection());
        clothesStore.setQuantity(double.Parse(command.ExecuteScalar().ToString()));
        connection.close();
    }

}
