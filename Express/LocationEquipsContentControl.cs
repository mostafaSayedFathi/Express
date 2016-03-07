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
    DevicesStoreControl devicesStoreControl;
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
            devicesStoreControl = new DevicesStoreControl();
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
                devicesStoreControl.updateQuantityMinus(name, quantity);
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
            listView.Items.Clear();
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

    public void deletedDevicesItems(string itemName, string locationName)
    {
        locationEquipsConrol = new LocationEquipsConrol();
        locationEquipsContent = new LocationEquipsContent();
        locationEquipsContentDB = new LocationEquipsContentDB();
        int locationDevicesID = locationEquipsConrol.getID(locationName);
        locationEquipsContent.setName(itemName);
        locationEquipsContent.setLocationClothesID(locationDevicesID);
        locationEquipsContentDB.delete(locationEquipsContent);
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

    public void updateItem(string itemName, double quantity , double total, string locationName)
    {
        locationEquipsConrol = new LocationEquipsConrol();
        locationEquipsContent = new LocationEquipsContent();
        locationEquipsContentDB = new LocationEquipsContentDB();
        int locationDevicesID = locationEquipsConrol.getID(locationName);
        locationEquipsContent.setLocationClothesID(locationDevicesID);
        locationEquipsContent.setName(itemName);
        locationEquipsContent.setQuantity(quantity);
        locationEquipsContent.setTotal(total);
        locationEquipsContentDB.updateItem(locationEquipsContent);
    }

    public void insertItem(string itemName, double price, double quantity, double total, string locationName, ListView listview)
    {
        locationEquipsConrol = new LocationEquipsConrol();
        locationEquipsContent = new LocationEquipsContent();
        locationEquipsContentDB = new LocationEquipsContentDB();
        int locationDevicesID = locationEquipsConrol.getID(locationName);
        locationEquipsContent.setLocationClothesID(locationDevicesID);
        locationEquipsContent.setName(itemName);
        locationEquipsContent.setPrice(price);
        locationEquipsContent.setQuantity(quantity);
        locationEquipsContent.setTotal(total);
        locationEquipsContentDB.insert(locationEquipsContent);
        //insert to listView
        ListViewItem item = new ListViewItem(itemName);
        item.SubItems.Add(price.ToString());
        item.SubItems.Add(quantity.ToString());
        item.SubItems.Add(total.ToString());
        listview.Items.Add(item);
    }

    public void deleteCheckedItems(ListView listView, string locationName)
    {
        devicesStoreControl = new DevicesStoreControl();
        locationEquipsContent = new LocationEquipsContent();
        locationEquipsContentDB = new LocationEquipsContentDB();
        if (listView.CheckedItems.Count == 0)
            return;
        else
        {
            foreach (ListViewItem item in listView.CheckedItems)
            {
                string name = item.SubItems[0].Text;
                double price = double.Parse(item.SubItems[1].Text);
                double quantity = double.Parse(item.SubItems[2].Text);
                double total = double.Parse(item.SubItems[3].Text);
                item.Remove();
                this.deletedDevicesItems(name, locationName);
                bool flag = devicesStoreControl.insertDevices(name, price, quantity, total);
                if (flag == true)
                {
                    //inserted in store
                }
                else
                {
                    //update quantity in store
                    devicesStoreControl.updateQuantityPlus(name, quantity);
                }
            }
        }
    }
}
