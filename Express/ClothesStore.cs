using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ClothesStore
{
    private string name;
    private double quantity;
    private double price;
    private double total;
    private int ID;

    public ClothesStore()
    {
        name = "";
        quantity = 0.0f;
        price = 0.0f;
        total = 0.0f;
        ID = 0;
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

    public void setQuantity(double quantity)
    {
        this.quantity = quantity;
    }

    public double getQuantity()
    {
        return quantity;
    }

    public void setPrice(double price)
    {
        this.price = price;
    }

    public double getPrice()
    {
        return price;
    }

    public void setTotal(double total)
    {
        this.total = total;
    }

    public double getTotal()
    {
        return total;
    }
}
