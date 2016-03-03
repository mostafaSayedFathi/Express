using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

class SourceControl
{
    Source source;
    SourceDB sourceDB;
    private Boolean check;
    DBConnection connection;

    public Boolean insertSource(string name, string address, string EmployeeName1, string EmployeeName2, string phone1, string phone2, string phone3)
    {
        source = new Source();
        sourceDB = new SourceDB();
        source.setName(name);
        source.setEmployeeName1(EmployeeName1);
        source.setEmployeeName2(EmployeeName2);
        source.setAddress(address);
        source.setPhone1(phone1);
        source.setPhone2(phone2);
        source.setPhone3(phone3);
        check = sourceDB.checkSource(source);
        if (check == true)
        {
            return false;
        }
        else
        {
            sourceDB.insert(source);
            return true;
        }
    }

    public void updateSource(string previousName ,string name, string address, string EmployeeName1, string EmployeeName2, string phone1, string phone2, string phone3)
    {
        source = new Source();
        sourceDB = new SourceDB();
        int ID = this.selectID(previousName);
        source.setID(ID);
        source.setName(name);
        source.setEmployeeName1(EmployeeName1);
        source.setEmployeeName2(EmployeeName2);
        source.setAddress(address);
        source.setPhone1(phone1);
        source.setPhone2(phone2);
        source.setPhone3(phone3);
        sourceDB.update(source);
    }

    public int selectID(string sourceName)
    {
        sourceDB = new SourceDB();
        source = new Source();
        source.setName(sourceName);
        return sourceDB.selectSourceId(source);
    }

    public void fillComboboxSourceName(ComboBox combobox)
    {
        combobox.Items.Clear();
        connection = new DBConnection();
        sourceDB = new SourceDB();
        SqlDataReader reader = sourceDB.fillComboboxSourceName();
        while (reader.Read())
        {
            combobox.Items.Add(reader["sourceName"]);
        }
        connection.close();
    }

    public string selectSourceName(int ID)
    {
        source = new Source();
        sourceDB = new SourceDB();
        source.setID(ID);
        sourceDB.selectSourceName(source);
        return source.getName();
    }

    public string getSourceAddress(string sourceName)
    {
        source = new Source();
        sourceDB = new SourceDB();
        int ID = this.selectID(sourceName);
        source.setID(ID);
        sourceDB.selectSourceAdress(source);
        return source.getAddress();
    }

    public string getSourceEmployee1(string sourceName)
    {
        source = new Source();
        sourceDB = new SourceDB();
        int ID = this.selectID(sourceName);
        source.setID(ID);
        sourceDB.selectEmployeeName1(source);
        return source.getEmployeeName1();
    }

    public string getSourceEmployee2(string sourceName)
    {
        source = new Source();
        sourceDB = new SourceDB();
        int ID = this.selectID(sourceName);
        source.setID(ID);
        sourceDB.selectEmployeeName2(source);
        return source.getEmployeeName2();
    }

    public string getSourcePhone1(string sourceName)
    {
        source = new Source();
        sourceDB = new SourceDB();
        int ID = this.selectID(sourceName);
        source.setID(ID);
        sourceDB.selectPhone1(source);
        return source.getPhone1();
    }

    public string getSourcePhone2(string sourceName)
    {
        source = new Source();
        sourceDB = new SourceDB();
        int ID = this.selectID(sourceName);
        source.setID(ID);
        sourceDB.selectPhone2(source);
        return source.getPhone2();
    }

    public string getSourcePhone3(string sourceName)
    {
        source = new Source();
        sourceDB = new SourceDB();
        int ID = this.selectID(sourceName);
        source.setID(ID);
        sourceDB.selectPhone3(source);
        return source.getPhone3();
    }
}

