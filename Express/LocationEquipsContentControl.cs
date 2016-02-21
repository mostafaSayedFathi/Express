using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

class LocationEquipsContentControl
{
    LocationEquipsContent locationEquipsContent;
    LocationEquipsContentDB locationEquipsContentDB;
    LocationEquipsConrol locationEquipsConrol;
    DBConnection connection;

    public void insert(ListView listView)
    {
        if (listView.Items.Count == 0)
        {
        }
        else
        {
            locationEquipsContent = new LocationEquipsContent();
            locationEquipsContentDB = new LocationEquipsContentDB();
            locationEquipsConrol = new LocationEquipsConrol();
            int locationClothesID = locationEquipsConrol.getLastID();
            foreach (ListViewItem lvi in listView.Items)
            {
                string name = lvi.SubItems[0].Text;
                double price = double.Parse(lvi.SubItems[1].Text);
                double quantity = double.Parse(lvi.SubItems[2].Text);
                double total = double.Parse(lvi.SubItems[3].Text);
                locationEquipsContent.setName(name);
                locationEquipsContent.setPrice(price);
                locationEquipsContent.setQuantity(quantity);
                locationEquipsContent.setTotal(total);
                locationEquipsContent.setLocationClothesID(locationClothesID);
                locationEquipsContentDB.insert(locationEquipsContent);
            }
        }
    }

    public void fillListView(ListView listView, string locationName)
    {
        locationEquipsConrol = new LocationEquipsConrol();
        locationEquipsContent = new LocationEquipsContent();
        locationEquipsContentDB = new LocationEquipsContentDB();
        //bool check = locationEquipsConrol.checkIfLocationHasEquips(locationName);
        double total = locationEquipsConrol.getTotal(locationName);
        //MessageBox.Show(total.ToString());
        if (total == 0)
        {
        }
        else
        {
            connection = new DBConnection();
            listView.Items.Clear();
            int ID = locationEquipsConrol.getID(locationName);
            locationEquipsContent.setLocationClothesID(ID);
            SqlDataReader reader = locationEquipsContentDB.fillListView(locationEquipsContent);
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

    public void deletedDevicesItems(HashSet<string> deleted, string locationName)
    {
        locationEquipsConrol = new LocationEquipsConrol();
        locationEquipsContent = new LocationEquipsContent();
        locationEquipsContentDB = new LocationEquipsContentDB();
        int locationClothesID = locationEquipsConrol.getID(locationName);
        foreach (String element in deleted)
        {
            locationEquipsContent.setName(element);
            locationEquipsContent.setLocationClothesID(locationClothesID);
            locationEquipsContentDB.delete(locationEquipsContent);
        }
    }

    public void updateInsert(string locationName, ListView listView)
    {
        locationEquipsConrol = new LocationEquipsConrol();
        locationEquipsContent = new LocationEquipsContent();
        locationEquipsContentDB = new LocationEquipsContentDB();
        int locationClothesID = locationEquipsConrol.getID(locationName);

        foreach (ListViewItem item in listView.Items)
        {
            string name = item.SubItems[0].Text;
            double price = double.Parse(item.SubItems[1].Text);
            double quantity = double.Parse(item.SubItems[2].Text);
            double total = double.Parse(item.SubItems[3].Text);
            locationEquipsContent.setName(name);
            locationEquipsContent.setLocationClothesID(locationClothesID);
            locationEquipsContent.setQuantity(quantity);
            bool check = locationEquipsContentDB.checkIfExist(locationEquipsContent);
            if (check == true)
            {
                locationEquipsContentDB.update(locationEquipsContent);
            }
            else
            {
                locationEquipsContent.setPrice(price);
                locationEquipsContent.setQuantity(quantity);
                locationEquipsContent.setTotal(total);
                locationEquipsContentDB.insert(locationEquipsContent);
            }
        }
    }
}
