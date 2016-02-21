class LocationClothesContent
{
    private int ID;
    private string name;
    private double price;
    private double quantity;
    private double total;
    private int locationClothesID;

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

    public void setPrice(double price)
    {
        this.price= price;
    }
    public double getPrice()
    {
        return price;
    }

    public void setQuantity(double quantity)
    {
        this.quantity = quantity;
    }
    public double getQuantity()
    {
        return quantity;
    }

    public void setTotal(double total)
    {
        this.total = total;
    }
    public double getTotal()
    {
        return total;
    }

    public void setLocationClothesID(int locationClothesID)
    {
        this.locationClothesID = locationClothesID;
    }
    public int getLocationClothesID()
    {
        return locationClothesID;
    }
}