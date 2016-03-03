using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Source
{
    private int ID;
    private string name;
    private string EmployeeName1;
    private string EmployeeName2;
    private string address;
    private string phone1;
    private string phone2;
    private string phone3;

    public Source()
    {
        ID = 0;
        name = "";
        EmployeeName1 = "";
        EmployeeName2 = "";
        address = "";
        phone1 = "";
        phone2 = "";
        phone3 = "";
    }

    public void setID(int ID)
    {
        this.ID = ID;
    }

    public int getID()
    {
        return ID;
    }

    public void setName(string name)
    {
        this.name = name;
    }

    public string getName()
    {
        return name;
    }

    public void setEmployeeName1(string EmployeeName1)
    {
        this.EmployeeName1 = EmployeeName1;
    }

    public string getEmployeeName1()
    {
        return EmployeeName1;
    }

    public void setEmployeeName2(string EmployeeName2)
    {
        this.EmployeeName2 = EmployeeName2;
    }

    public string getEmployeeName2()
    {
        return EmployeeName2;
    }

    public void setAddress(string address)
    {
        this.address = address;
    }

    public string getAddress()
    {
        return address;
    }

    public void setPhone1(string phone1)
    {
        this.phone1 = phone1;
    }

    public string getPhone1()
    {
        return phone1;
    }

    public void setPhone2(string phone2)
    {
        this.phone2 = phone2;
    }

    public string getPhone2()
    {
        return phone2;
    }

    public void setPhone3(string phone3)
    {
        this.phone3 = phone3;
    }

    public string getPhone3()
    {
        return phone3;
    }

}

