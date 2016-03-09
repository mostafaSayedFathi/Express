using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

class EmployeeSalaryDB
{
    DBConnection connection;
    SqlCommand command;

    public EmployeeSalaryDB()
    {
        connection = new DBConnection();
    }

    public Boolean checkEmployeeSalary(EmployeeSalary employeeSalary)
    {
        connection.open();
        command = new SqlCommand("select count(*) from EmployeeSalary where EmployeeID='" + employeeSalary.getEmployeeID() + "' and month='" + employeeSalary.getMonth() + "' and year='" + employeeSalary.getYear() + "'  ", connection.getConnection());

        int check = (int)command.ExecuteScalar();
        connection.close();

        if (check > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void insert(EmployeeSalary employeeSalary)
    {
        connection.open();
        command = new SqlCommand("insert into EmployeeSalary(EmployeeID,LocationID,salaryDate,EmployeeSalary,workDay,extraDay,restDay,meal,home,rewarding,extras,advance,FixedInsurances,variableInsurances,monySanctions,daySanctions,uniform,insurancePolicy,finalSalaryBeforTax,tax,finalSalaryAfterTax,comment,type,fixedEmployee,fixedCompany,variableEmployee,variableCompany,month,year)values('" + employeeSalary.getEmployeeID() + "' , '" + employeeSalary.getLocationID() + "' , '" + employeeSalary.getSalaryDate() + "','" + employeeSalary.getEmployeSalary() + "' ,'" + employeeSalary.getWorkDay() + "' ,'" + employeeSalary.getExtraDay() + "' ,'" + employeeSalary.getRestDay() + "','" + employeeSalary.getMeal() + "' ,'" + employeeSalary.getHome() + "' ,'" + employeeSalary.getRewarding() + "' ,'" + employeeSalary.getExtras() + "','" + employeeSalary.getAdvance() + "' ,'" + employeeSalary.getFixedInsurances() + "','" + employeeSalary.getvariableInsurances() + "' ,'" + employeeSalary.getMoneySanctions() + "' ,'" + employeeSalary.getDaySanctions() + "' ,'" + employeeSalary.getUniform() + "' ,'" + employeeSalary.getInsurancePolicy() + "','" + employeeSalary.getFinalSalaryBeforTax() + "' ,'" + employeeSalary.getTax() + "' ,'" + employeeSalary.getFinalSalaryAfterTax() + "' ,'" + employeeSalary.getComment() + "' ,'" + employeeSalary.getType() + "','" + employeeSalary.getfixedEmployee() + "','" + employeeSalary.getfixedCompany() + "','" + employeeSalary.getvarEmployee() + "','" + employeeSalary.getvarCompany() + "','" + employeeSalary.getMonth() + "','" + employeeSalary.getYear() + "')", connection.getConnection());
        command.ExecuteNonQuery();
        connection.close();
    }

    public void selectSalaryEmployeeID(EmployeeSalary employeeSalary)
    {
        connection.open();
        command = new SqlCommand("select ID from EmployeeSalary where EmployeeID='" + employeeSalary.getEmployeeID() + "' and month='" + employeeSalary.getMonth() + "'and year='" + employeeSalary.getYear() + "'", connection.getConnection());
        employeeSalary.setSalaryID((int)command.ExecuteScalar());
        connection.close();
    }

    public void update(EmployeeSalary employeeSalary)
    {
        connection.open();
        command = new SqlCommand("update EmployeeSalary set EmployeeSalary='" + employeeSalary.getEmployeSalary() + "',workDay='" + employeeSalary.getWorkDay() + "',extraDay='" + employeeSalary.getExtraDay() + "' ,restDay='" + employeeSalary.getRestDay() + "' ,meal='" + employeeSalary.getMeal() + "' ,home='" + employeeSalary.getHome() + "',rewarding='" + employeeSalary.getRewarding() + "',extras='" + employeeSalary.getExtras() + "',advance='" + employeeSalary.getAdvance() + "',FixedInsurances='" + employeeSalary.getFixedInsurances() + "',variableInsurances='" + employeeSalary.getvariableInsurances() + "' ,monySanctions='" + employeeSalary.getMoneySanctions() + "',daySanctions='" + employeeSalary.getDaySanctions() + "',uniform='" + employeeSalary.getUniform() + "',insurancePolicy='" + employeeSalary.getInsurancePolicy() + "',finalSalaryBeforTax='" + employeeSalary.getFinalSalaryBeforTax() + "',tax='" + employeeSalary.getTax() + "' ,finalSalaryAfterTax='" + employeeSalary.getFinalSalaryAfterTax() + "',comment='" + employeeSalary.getComment() + "',type='" + employeeSalary.getType() + "',fixedEmployee='" + employeeSalary.getfixedEmployee() + "',fixedCompany='" + employeeSalary.getfixedCompany() + "',variableEmployee='" + employeeSalary.getvarEmployee() + "',variableCompany='" + employeeSalary.getvarCompany() + "'where ID='" + employeeSalary.getSalaryID() + "'", connection.getConnection());
        command.ExecuteNonQuery();
        connection.close();
    }

    public SqlDataReader fillInfoEmployeeSalary(EmployeeSalary employeeSalary)
    {
        connection.open();
        command = new SqlCommand("select * from EmployeeSalary where ID='" + employeeSalary.getSalaryID()+ "'", connection.getConnection());
        SqlDataReader reader = command.ExecuteReader();
        return reader;
    }
}