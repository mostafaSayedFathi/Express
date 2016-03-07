using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

class LocationClothesControl
{
    LocationClothes locationClothes;
    LocationClothesDB locationClothesDB;
    LocationControl locationControl;

    public void insert(double total , string locationName)
    {
        locationControl = new LocationControl();
        locationClothes = new LocationClothes();
        locationClothesDB = new LocationClothesDB();
        locationControl.getLocationID(locationName);
        int ID = locationControl.getID(locationName);
        locationClothes.setLocationID(ID);
        locationClothes.setTotal(total);
        locationClothesDB.insert(locationClothes);
    }

    public int getLastID()
    {
        locationClothes = new LocationClothes();
        locationClothesDB = new LocationClothesDB();
        locationClothesDB.selectLastID(locationClothes);
        return locationClothes.getID();
    }

    public int getID(string locationName)
    {
        locationControl = new LocationControl();
        locationClothes = new LocationClothes();
        locationClothesDB = new LocationClothesDB();
        int ID = locationControl.getID(locationName);
        locationClothes.setLocationID(ID);
        locationClothesDB.selectID(locationClothes);
        return locationClothes.getID();
    }

    public double getTotal(string locationName)
    {
        locationControl = new LocationControl();
        locationClothes = new LocationClothes();
        locationClothesDB = new LocationClothesDB();
        int ID = locationControl.getID(locationName);
        locationClothes.setLocationID(ID);
        locationClothesDB.selectTotal(locationClothes);
        return locationClothes.getTotal();
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

    public void update(double total ,string locationName)
    {
        locationControl = new LocationControl();
        locationClothes = new LocationClothes();
        locationClothesDB = new LocationClothesDB();
        int ID = locationControl.getID(locationName);
        locationClothes.setLocationID(ID);
        locationClothes.setTotal(total);
        locationClothesDB.updateTotal(locationClothes);
    }

    public bool checkIfLocationHasClothes(string locationName)
    {
        locationControl = new LocationControl();
        locationClothes = new LocationClothes();
        locationClothesDB = new LocationClothesDB();
        int ID = locationControl.getID(locationName);
        locationClothes.setLocationID(ID);
        bool check = locationClothesDB.checkIfLocationHasClothes(locationClothes);
        return check;
    }
}
