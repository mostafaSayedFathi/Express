using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}