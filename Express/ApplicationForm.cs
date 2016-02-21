using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ApplicationForm
{
    private string applayDate;
    private string name;
    private string sex;
    private string address;
    private string birthDate;
    private string education;
    private string state;
    private string comment;
    private double salary;
    private int workHours;
    private int mobilePhone;
    private int phone;
    private int familyPhone;
    private string nationalID;
    private int source;
    private byte[] image;

    public ApplicationForm()
    {
        applayDate = ""; //done
        name = ""; //done
        sex = ""; //done
        address = ""; //done
        birthDate = ""; //done
        education = ""; //done
        source = 0; //done
        state = ""; //done
        comment = ""; //done
        salary = 0.0; // done
        workHours = 0; // done
        mobilePhone = 0; // done
        phone = 0; //done
        familyPhone = 0; //done
        nationalID = ""; //done
        image = null; //done
    }

    public void setApplayDate(string todayDate)
    {
        this.applayDate = todayDate;
    }

    public string getApplayDate()
    {
        return applayDate;
    }

    public void setName(string name)
    {
        this.name = name;
    }

    public string getName()
    {
        return name;
    }

    public void setSex(string sex)
    {
        this.sex = sex;
    }

    public string getSex()
    {
        return sex;
    }

    public void setAddress(string address)
    {
        this.address = address;
    }

    public string getAddress()
    {
        return address;
    }

    public void setBirthDate(string birthDate)
    {
        this.birthDate = birthDate;
    }

    public string getBirthDate()
    {
        return birthDate;
    }

    public void setEducation(string education)
    {
        this.education = education;
    }

    public string getEducation()
    {
        return education;
    }

    public void setSource(int source)
    {
        this.source = source;
    }

    public int getSource()
    {
        return source;
    }

    public void setState(string state)
    {
        this.state = state;
    }

    public string getState()
    {
        return state;
    }

    public void setComment(string comment)
    {
        this.comment = comment;
    }

    public string getComment()
    {
        return comment;
    }

    public void setSalary(double salary)
    {
        this.salary = salary;
    }

    public double getSalary()
    {
        return salary;
    }

    public void setWorkHours(int workHours)
    {
        this.workHours = workHours;
    }

    public int getWorkHours()
    {
        return workHours;
    }

    public void setMobilePhone(int mobilePhone)
    {
        this.mobilePhone = mobilePhone;
    }

    public int getMobilePhone()
    {
        return mobilePhone;
    }

    public void setPhone(int phone)
    {
        this.phone = phone;
    }

    public int getPhone()
    {
        return phone;
    }

    public void setFamilyPhone(int familyPhone)
    {
        this.familyPhone = familyPhone;
    }

    public int getFamilyPhone()
    {
        return familyPhone;
    }

    public void setNationalID(string nationalID)
    {
        this.nationalID = nationalID;
    }

    public string getNationalID()
    {
        return nationalID;
    }

    public void setImage(byte[] image)
    {
        this.image = image;
    }

    public byte[] getImage()
    {
        return image;
    }
}

