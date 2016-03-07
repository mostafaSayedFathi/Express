using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class EmployeeSalary
{
 
    private int employeeID; // done 
    private int locationID; // done 
    private int month; // done 
    private int year; // done 
    private string SalaryDate; // done
    private double extraDay; //done
    private double restDay; //done
    private double workDay; //done
    private double EmployeSalary;  //done
    private double home; //done
    private double meal; //done
    private double extras; //done
    private double rewarding; //done
    private double advance; //done
    private double fixedInsurances; //done
    private double variableInsurances; //done
    private double daySanctions;  //done
    private double moneySanctions;//done
    private double uniform; //done
    private double insurancePolicy; //done
    private double tax; //done
    private double finalSalaryBeforTax; //done
    private double finalSalaryAfterTax; //done
    private string comment; //done
    private string type; //done 
    private double total; //done
    private double fixedEmployee; //done
    private double fixedCompany; //done
    private double varEmployee; //done
    private double varCompany; //done
    private double totalTax;
    private double totalPolicy;
    private int ID;

    public EmployeeSalary()
    {
        employeeID = 0;
        locationID = 0;
        extraDay = 0;
        restDay = 0;
        workDay = 0;
        EmployeSalary = 0;
        home = 0;
        meal = 0;
        extras = 0;
        rewarding = 0;
        fixedInsurances = 0;
        variableInsurances = 0;
        daySanctions = 0;
        moneySanctions = 0;
        uniform = 0;
        insurancePolicy = 0;
        tax = 0;
        finalSalaryBeforTax = 0;
        finalSalaryAfterTax = 0;
        comment = "";
        type = "";
    }

    public void setSalaryID(int ID)
    {
        this.ID = ID;
    }

    public int getSalaryID()
    {
        return ID;
    }

    public void setEmployeeID(int employeeID)
    {
        this.employeeID = employeeID;
    }

    public int getEmployeeID()
    {
        return employeeID;
    }

    public void setLocationID(int locationID)
    {
        this.locationID = locationID;
    }

    public int getLocationID()
    {
        return locationID;
    }

    public void setYear(int year)
    {
        this.year = year;
    }

    public int getYear()
    {
        return year;
    }

    public void setMonth(int month)
    {
        this.month = month;
    }

    public int getMonth()
    {
        return month;
    }
    
    public void setSalaryDate(string SalaryDate)
    {
        this.SalaryDate = SalaryDate;
    }

    public string getSalaryDate()
    {
        return SalaryDate;
    }

    

    public void setExtraDay(double extraDay)
    {
        this.extraDay = extraDay;
    }

    public double getExtraDay()
    {
        return extraDay;
    }

    public void setRestDay(double restDay)
    {
        this.restDay = restDay;
    }

    public double getRestDay()
    {
        return restDay;
    }

    public void setWorkDay(double workDay)
    {
        this.workDay = workDay;
    }

    public double getWorkDay()
    {
        return workDay;
    }

    public void setEmployeSalary(double EmployeSalary)
    {
        this.EmployeSalary = EmployeSalary;
    }

    public double getEmployeSalary()
    {
        return EmployeSalary;
    }

   /* public void setLocationSalary(double locationSalary)
    {
        this.locationSalary = locationSalary;
    }

    public double getLocationSalary()
    {
        return locationSalary;
    }
    */

    public void setAdvance(double advance)
    {
        this.advance = advance;
    }

    public double getAdvance()
    {
        return advance;
    }
    public void setHome(double home)
    {
        this.home = home;
    }

    public double getHome()
    {
        return home;
    }

    public void setMeal(double meal)
    {
        this.meal = meal;
    }

    public double getMeal()
    {
        return meal;
    }

    public void setExtras(double extras)
    {
        this.extras = extras;
    }

    public double getExtras()
    {
        return extras;
    }

    public void setRewarding(double rewarding)
    {
        this.rewarding = rewarding;
    }

    public double getRewarding()
    {
        return rewarding;
    }

    public void setFixedInsurances(double fixedInsurances)
    {
        this.fixedInsurances = fixedInsurances;
    }

    public double getFixedInsurances()
    {
        return fixedInsurances;
    }

    public void setVariableInsurances(double variableInsurances)
    {
        this.variableInsurances = variableInsurances;
    }

    public double getvariableInsurances()
    {
        return variableInsurances;
    }

    public void setDaySanctions(double daySanctions)
    {
        this.daySanctions = daySanctions;
    }

    public double getDaySanctions()
    {
        return daySanctions;
    }

    public void setMoneySanctions(double moneySanctions)
    {
        this.moneySanctions = moneySanctions;
    }

    public double getMoneySanctions()
    {
        return moneySanctions;
    }

    public void setUniform(double uniform)
    {
        this.uniform = uniform;
    }

    public double getUniform()
    {
        return uniform;
    }

    public void setInsurancePolicy(double insurancePolicy)
    {
        this.insurancePolicy = insurancePolicy;
    }

    public double getInsurancePolicy()
    {
        return insurancePolicy;
    }

    public void setTax(double tax)
    {
        this.tax = tax;
    }

    public double getTax()
    {
        return tax;
    }

    public void setFinalSalaryBeforTax(double finalSalaryBeforTax)
    {
        this.finalSalaryBeforTax = finalSalaryBeforTax;
    }

    public double getFinalSalaryBeforTax()
    {
        return finalSalaryBeforTax;
    }

    public void setFinalSalaryAfterTax(double finalSalaryAfterTax)
    {
        this.finalSalaryAfterTax = finalSalaryAfterTax;
    }

    public double getFinalSalaryAfterTax()
    {
        return finalSalaryAfterTax;
    }

    public void setComment(string comment)
    {
        this.comment = comment;
    }

    public string getComment()
    {
        return comment;
    }

    public void setType(string type)
    {
        this.type = type;
    }

    public string getType()
    {
        return type;
    }

    public void setTotal(double total)
    {
        this.total = total;
    }

    public double getTotal()
    {
        return total;
    }

    public void setTotalTax(double totalTax)
    {
        this.totalTax = totalTax;
    }

    public double getTotalTax()
    {
        return totalTax;
    }

    public void setTotalPolicy(double totalPolicy)
    {
        this.totalPolicy = totalPolicy;
    }

    public double getTotalPolicy()
    {
        return totalPolicy;
    }

    public void setfixedEmployee(double fixedEmployee)
    {
        this.fixedEmployee = fixedEmployee;
    }

    public double getfixedEmployee()
    {
        return fixedEmployee;
    }

    public void setfixedCompany(double fixedCompany)
    {
        this.fixedCompany = fixedCompany;
    }

    public double getfixedCompany()
    {
        return fixedCompany;
    }

    public void setvarEmployee(double varEmployee)
    {
        this.varEmployee = varEmployee;
    }

    public double getvarEmployee()
    {
        return varEmployee;
    }

    public void setvarCompany(double varCompany)
    {
        this.varCompany = varCompany;
    }

    public double getvarCompany()
    {
        return varCompany;
    }
}
