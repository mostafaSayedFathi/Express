class Location
{
    private int ID;
    private string name;
    private string address;
    private string startDate;
    private string endDate;
    private int workHours;
    private int securityNumbers;
    private double securitySalary;
    private int supervisorNumbers;
    private double supervisorSalary;
    private int managerNumbers;
    private double managerSalary;

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

    public void setAddress(string address)
    {
        this.address = address;
    }
    public string getAddress()
    {
        return address;
    }

    public void setStartDate(string startDate)
    {
        this.startDate = startDate;
    }
    public string getStartDate()
    {
        return startDate;
    }

    public void setEndDate(string endDate)
    {
        this.endDate = endDate;
    }
    public string getEndDate()
    {
        return endDate;
    }

    public void setWorkHours(int workHours)
    {
        this.workHours = workHours;
    }
    public int getWorkHours()
    {
        return workHours;
    }

    public void setSecurityNumbers(int securityNumbers)
    {
        this.securityNumbers = securityNumbers;
    }
    public int getSecurityNumbers()
    {
        return securityNumbers;
    }

    public void setSecuritySalary(double securitySalary)
    {
        this.securitySalary = securitySalary;
    }
    public double getSecuritySalary()
    {
        return securitySalary;
    }

    public void setSupervisorNumbers(int supervisorNumbers)
    {
        this.supervisorNumbers = supervisorNumbers;
    }
    public int getSupervisorNumbers()
    {
        return supervisorNumbers;
    }

    public void setSupervisorSalary(double supervisorSalary)
    {
        this.supervisorSalary = supervisorSalary;
    }
    public double getSupervisorSalary()
    {
        return supervisorSalary;
    }

    public void setManagerNumbers(int managerNumbers)
    {
        this.managerNumbers = managerNumbers;
    }
    public int getManagerNumbers()
    {
        return managerNumbers;
    }

    public void setManagerSalary(double managerSalary)
    {
        this.managerSalary = managerSalary;
    }
    public double getManagerSalary()
    {
        return managerSalary;
    }
}
