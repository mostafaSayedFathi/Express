using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

class DevicesStoreControl
{
    DevicesStore devicesStore;
    DevicesStoreDB devicesStoreDB;
    private Boolean check;
    private DBConnection connection;


    public Boolean insertDevices(string name, double price, double quantity, double total)
    {
        devicesStore = new DevicesStore();
        devicesStoreDB = new DevicesStoreDB();
        devicesStore.setName(name);
        devicesStore.setPrice(price);
        devicesStore.setQuantity(quantity);
        devicesStore.setTotal(total);
        check = devicesStoreDB.checkDevice(devicesStore);
        if (check == true)
        {
            return false;
        }
        else
        {
            devicesStoreDB.insert(devicesStore);
            return true;
        }
    }

    public void deleteDevices(string deviceName)
    {
        devicesStore = new DevicesStore();
        devicesStoreDB = new DevicesStoreDB();
        devicesStore.setName(deviceName);
        devicesStoreDB.delete(devicesStore);
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

    public void fillListViewDevicesStore(ListView listView)
    {
        listView.Items.Clear();
        connection = new DBConnection();
        devicesStoreDB = new DevicesStoreDB();
        SqlDataReader reader = devicesStoreDB.fillListViewDevices();
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

    public Boolean UpdateDevice(string prevoiusName, string name, double price, double quantity, double total)
    {
        Boolean check = false;
        devicesStore = new DevicesStore();
        devicesStoreDB = new DevicesStoreDB();

        if (prevoiusName.Equals("NOT CHANAGEE"))
        {
            devicesStore.setName(name);
        }
        else
        {
            devicesStore.setName(name);
            check = devicesStoreDB.checkDevice(devicesStore);
            devicesStore.setName(prevoiusName);
        }
        devicesStore.setPrice(price);
        devicesStore.setQuantity(quantity);
        devicesStore.setTotal(total);

        if (check == true)
        {
            return false;
        }
        else
        {
            int ID = devicesStoreDB.selectDeviceId(devicesStore);
            devicesStore.setID(ID);
            devicesStore.setName(name);
            devicesStoreDB.update(devicesStore);
            return true;
        }
    }

    public void fillComboboxDevicesName(ComboBox combobox)
    {
        combobox.Items.Clear();
        connection = new DBConnection();
        devicesStoreDB = new DevicesStoreDB();
        SqlDataReader reader = devicesStoreDB.fillComboboxDeviceName();
        while (reader.Read())
        {
            combobox.Items.Add(reader["name"]);
        }
        connection.close();
    }

    public double getDevicePrice(string name)
    {
        devicesStoreDB = new DevicesStoreDB();
        devicesStore = new DevicesStore();
        devicesStore.setName(name);
        devicesStoreDB.selectPrice(devicesStore);
        return devicesStore.getPrice();
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
        if (listview.CheckedItems.Count == 0)
            return total;
        else
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

    public void updateQuantityMinus(string deviceName , double quantity)
    {
        devicesStore = new DevicesStore();
        devicesStoreDB = new DevicesStoreDB();
        devicesStore.setName(deviceName);
        devicesStore.setQuantity(quantity);
        devicesStoreDB.updateQuantityMinus(devicesStore);
    }

    public void updateQuantityPlus(string deviceName, double quantity)
    {
        devicesStore = new DevicesStore();
        devicesStoreDB = new DevicesStoreDB();
        devicesStore.setName(deviceName);
        devicesStore.setQuantity(quantity);
        devicesStoreDB.updateQuantityPlus(devicesStore);
    }

    public bool checkItemQuantity(string itemName, double quantity)
    {
        devicesStore = new DevicesStore();
        devicesStoreDB = new DevicesStoreDB();
        devicesStore.setName(itemName);
        devicesStoreDB.selectQuantity(devicesStore);
        if (quantity > devicesStore.getQuantity())
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public double getQuantity(string itemName)
    {
        devicesStore = new DevicesStore();
        devicesStoreDB = new DevicesStoreDB();
        devicesStore.setName(itemName);
        devicesStoreDB.selectQuantity(devicesStore);
        return devicesStore.getQuantity();
    }

    public bool checkUpdatedQuantity(string itemName, double differenceQuantity)
    {
        double quantityInStore = this.getQuantity(itemName); ;
        bool flag = true;
        if (quantityInStore >= differenceQuantity)
        {
            flag = true;
        }
        else
        {
            flag = false;
        }
        return flag;
    }

    public bool checkItemInStore(string itemName)
    {
        devicesStore = new DevicesStore();
        devicesStoreDB = new DevicesStoreDB();
        devicesStore.setName(itemName);
        bool check = devicesStoreDB.checkDevice(devicesStore);
        return check;
    }
}


