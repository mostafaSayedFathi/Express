using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

class LocationEquipsConrol
{
    LocationEquips locationEquips;
    LocationEquipsDB locationEquipsDB;
    LocationControl locationControl;

    public void insert(double total, string locationName)
    {
        locationControl = new LocationControl();
        locationEquips = new LocationEquips();
        locationEquipsDB = new LocationEquipsDB();
        locationControl.getLocationID(locationName);
        int ID = locationControl.getID(locationName);
        locationEquips.setLocationID(ID);
        locationEquips.setTotal(total);
        locationEquipsDB.insert(locationEquips);
    }

    public int getLastID()
    {
        locationEquips = new LocationEquips();
        locationEquipsDB = new LocationEquipsDB();
        locationEquipsDB.selectLastID(locationEquips);
        return locationEquips.getID();
    }

    public int getID(string locationName)
    {
        locationControl = new LocationControl();
        locationEquips = new LocationEquips();
        locationEquipsDB = new LocationEquipsDB();
        int ID = locationControl.getID(locationName);
        locationEquips.setLocationID(ID);
        locationEquipsDB.selectID(locationEquips);
        return locationEquips.getID();
    }

    public double getTotal(string locationName)
    {
        locationControl = new LocationControl();
        locationEquips = new LocationEquips();
        locationEquipsDB = new LocationEquipsDB();
        int ID = locationControl.getID(locationName);
        locationEquips.setLocationID(ID);
        locationEquipsDB.getTotal(locationEquips);
        return locationEquips.getTotal();
    }

    public double updateListViewTotal(ListView listView)
    {
        double totalAll = 0;
        foreach (ListViewItem lvi in listView.Items)
        {
            double total = double.Parse(lvi.SubItems[3].Text);
            totalAll += total;
        }
        return totalAll;
    }

    public void update(double total, string locationName)
    {
        locationControl = new LocationControl();
        locationEquips = new LocationEquips();
        locationEquipsDB = new LocationEquipsDB();
        int ID = locationControl.getID(locationName);
        locationEquips.setLocationID(ID);
        locationEquips.setTotal(total);
        locationEquipsDB.updateTotal(locationEquips);
    }

    public bool checkIfLocationHasEquips(string locationName)
    {
        locationControl = new LocationControl();
        locationEquips = new LocationEquips();
        locationEquipsDB = new LocationEquipsDB();
        int ID = locationControl.getID(locationName);
        locationEquips.setLocationID(ID);
        bool check = locationEquipsDB.checkIfLocationHasDevices(locationEquips);
        return check;
    }
}
