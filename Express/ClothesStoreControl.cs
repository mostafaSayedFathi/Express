using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


class ClothesStoreControl
{
    private ClothesStore clothesStore;
    private ClothesStoreDB clothesStoreDB;
    private Boolean check;
    private DBConnection connection;

    public Boolean insertClothes(string name, double price, double quantity, double total)
    {
        clothesStore = new ClothesStore();
        clothesStoreDB = new ClothesStoreDB();
        clothesStore.setName(name);
        clothesStore.setPrice(price);
        clothesStore.setQuantity(quantity);
        clothesStore.setTotal(total);
        check = clothesStoreDB.checkCloth(clothesStore);
        if (check == true)
        {
            return false;
        }
        else
        {
            clothesStoreDB.insert(clothesStore);
            return true;
        }

    }

    public void deleteClothes(string clothType)
    {
        clothesStore = new ClothesStore();
        clothesStoreDB = new ClothesStoreDB();
        clothesStore.setName(clothType);
        clothesStoreDB.delete(clothesStore);
    }

    public double total(double num1, double num2)
    {
        return num1 * num2;
    }

    public double totalAll(double num1, double num2)
    {
        return num1 + num2;
    }

    public double totalMinus(double num1, double num2)
    {
        return num1 - num2;
    }

    public void fillComboboxClothesName(ComboBox combobox)
    {
        combobox.Items.Clear();
        connection = new DBConnection();
        clothesStoreDB = new ClothesStoreDB();
        SqlDataReader reader = clothesStoreDB.fillComboboxClothesName();
        while (reader.Read())
        {
            combobox.Items.Add(reader["name"]);
        }
        connection.close();
    }

    public void fillListViewClothesStore(ListView listView)
    {
        listView.Items.Clear();
        connection = new DBConnection();
        clothesStoreDB = new ClothesStoreDB();
        SqlDataReader reader = clothesStoreDB.fillListViewClothes();
        while (reader.Read())
        {
            ListViewItem lvi = new ListViewItem(reader["name"].ToString());
            lvi.SubItems.Add(reader["price"].ToString());
            lvi.SubItems.Add(reader["quantity"].ToString());
            lvi.SubItems.Add(reader["total"].ToString());
            listView.Items.Add(lvi);
        }
        connection.close();
    }

    public double totalAllUpdate(ListView listView)
    {
        double totalAll = 0.0;
        foreach (ListViewItem lvi in listView.Items)
        {
            double total = double.Parse(lvi.SubItems[3].Text);
            totalAll += total;
        }
        return totalAll;
    }

    public Boolean UpdateClothe(string prevoiusName, string name, double price, double quantity, double total)
    {
        Boolean check = false;
        clothesStore = new ClothesStore();
        clothesStoreDB = new ClothesStoreDB();

        if (prevoiusName.Equals("NOT CHANAGEE"))
        {
            clothesStore.setName(name);
        }
        else
        {
            clothesStore.setName(name);
            check = clothesStoreDB.checkCloth(clothesStore);
            clothesStore.setName(prevoiusName);
        }
        clothesStore.setPrice(price);
        clothesStore.setQuantity(quantity);
        clothesStore.setTotal(total);

        if (check == true)
        {
            return false;
        }
        else
        {
            int ID = clothesStoreDB.selectClotheId(clothesStore);
            clothesStore.setID(ID);
            clothesStore.setName(name);
            clothesStoreDB.update(clothesStore);
            return true;
        }
    }

    public double getClothePrice(string name)
    {
        clothesStoreDB = new ClothesStoreDB();
        clothesStore = new ClothesStore();
        clothesStore.setName(name);
        clothesStoreDB.selectPrice(clothesStore);
        return clothesStore.getPrice();
    }

    public bool checkItemExistInListView(ListView listView, string item)
    {
        bool flag = true;
        if (listView.Items.Count == 0)
        {
            //add item
            flag = false;
        }
        else
        {
            for (int j = 0; j < listView.Items.Count; j++)
            {
                if (listView.Items[j].SubItems[0].Text == item)
                {
                    // item exists
                    flag = true;
                    break;
                }
                else
                {
                    // item not exists
                    flag = false;
                }
            }
        }
        return flag;
    }

    public double deleteListViewItem(ListView listview, double total)
    {
        double newTotal = 0;
        foreach (ListViewItem checkedItem in listview.CheckedItems)
        {
            double totalItem = double.Parse(checkedItem.SubItems[3].Text);
            newTotal = totalMinus(total, totalItem);
            checkedItem.Remove();
        }
        return newTotal;
    }



}
