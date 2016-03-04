using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

class LocationClothesContentControl
{
    LocationClothesContent locationClothesContent;
    LocationClothesContentDB locationClothesContentDB;
    LocationClothesControl locationClothesControl;
    ClothesStoreControl clothesStoreControl;
    DBConnection connection;

    public void insert(ListView listView)
    {
        if (listView.Items.Count == 0)
        {
            return;
        }
        else
        {
            locationClothesContent = new LocationClothesContent();
            locationClothesContentDB = new LocationClothesContentDB();
            locationClothesControl = new LocationClothesControl();
            clothesStoreControl = new ClothesStoreControl();
            int locationClothesID = locationClothesControl.getLastID();
            foreach (ListViewItem lvi in listView.Items)
            {
                string name = lvi.SubItems[0].Text;
                double price = double.Parse(lvi.SubItems[1].Text);
                double quantity = double.Parse(lvi.SubItems[2].Text);
                double total = double.Parse(lvi.SubItems[3].Text);
                locationClothesContent.setName(name);
                locationClothesContent.setPrice(price);
                locationClothesContent.setQuantity(quantity);
                locationClothesContent.setTotal(total);
                locationClothesContent.setLocationClothesID(locationClothesID);
                clothesStoreControl.updateQuantityMinus(name, quantity);
                locationClothesContentDB.insert(locationClothesContent);
            }
        }
    }

    public void fillListView(ListView listView, string locationName)
    {
        locationClothesControl = new LocationClothesControl();
        locationClothesContent = new LocationClothesContent();
        locationClothesContentDB = new LocationClothesContentDB();
        //bool check = locationClothesControl.checkIfLocationHasClothes(locationName);
        double total = locationClothesControl.getTotal(locationName);
        if (total == 0)
        {
        }
        else
        {
            int ID = locationClothesControl.getID(locationName);
            connection = new DBConnection();
            listView.Items.Clear();
            locationClothesContent.setLocationClothesID(ID);
            SqlDataReader reader = locationClothesContentDB.fillListView(locationClothesContent);
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
    }

    public void deletedClothesItems(HashSet<string> deleted , string locationName)
    {
        locationClothesControl = new LocationClothesControl();
        locationClothesContent = new LocationClothesContent();
        locationClothesContentDB = new LocationClothesContentDB();
        int locationClothesID = locationClothesControl.getID(locationName);
        foreach (String element in deleted)
        {
            locationClothesContent.setName(element);
            locationClothesContent.setLocationClothesID(locationClothesID);
            locationClothesContentDB.delete(locationClothesContent);
        }
    }

    public void updateInsert(string locationName, ListView listView)
    {
        locationClothesControl = new LocationClothesControl();
        locationClothesContent = new LocationClothesContent();
        locationClothesContentDB = new LocationClothesContentDB();
        int locationClothesID = locationClothesControl.getID(locationName);

        foreach(ListViewItem item in listView.Items)
        {
            string name = item.SubItems[0].Text;
            double price = double.Parse(item.SubItems[1].Text);
            double quantity = double.Parse(item.SubItems[2].Text);
            double total = double.Parse(item.SubItems[3].Text);
            locationClothesContent.setName(name);
            locationClothesContent.setLocationClothesID(locationClothesID);
            locationClothesContent.setQuantity(quantity);
            bool check = locationClothesContentDB.checkIfExist(locationClothesContent);
            if (check == true)
            {
                locationClothesContentDB.update(locationClothesContent);
            }
            else
            {
                locationClothesContent.setPrice(price);
                locationClothesContent.setQuantity(quantity);
                locationClothesContent.setTotal(total);
                locationClothesContentDB.insert(locationClothesContent);
            }
        }
    }
}
