using Express;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

class EmployeeSalaryControl
{
    private EmployeeSalaryControl employeeSalaryControl;
    private EmployeeSalary employeeSalary;
    private EmployeeSalaryDB employeeSalaryDB;
    private Employee employee ;
    private EmployeeDB employeeDB;
    private DBConnection connection;

    public Boolean checkEmployeeSalary(int ID, int month,int year)
    {
        employeeSalaryControl = new EmployeeSalaryControl();
        employeeSalary = new EmployeeSalary();
        employeeSalaryDB = new EmployeeSalaryDB();
        employeeSalary.setEmployeeID(ID);
        employeeSalary.setMonth(month);
        employeeSalary.setYear(year);

        Boolean check = employeeSalaryDB.checkEmployeeSalary(employeeSalary);
        if (check == true)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public void Calculation(TextBox txtSalaryEmployeeSalary, TextBox txtSalaryWorkDayes, TextBox txtSalaryRestDays, TextBox txtSalaryExtraDays, TextBox txtSalaryFixedInsurances, TextBox txtSalaryVaribaleInsurances, TextBox txtSalaryFixedEmployee, TextBox txtSalaryFixedCompany, TextBox txtSalaryVarEmployee, TextBox txtSalaryVarCompany, TextBox txtSalaryMoneySanctions, TextBox txtSalaryDaySanctions, TextBox txtSalaryUniform, TextBox txtSalaryInsurancePolicy, TextBox txtSalaryMeal, TextBox txtSalaryHome, TextBox txtSalaryRewarding, TextBox txtSalaryExtras, TextBox txtSalaryAdnace, RadioButton rdBtnSalaryTax, TextBox txtSalaryBeforTax, TextBox txtSalaryTax, TextBox txtSalaryAfterTax)
    {
        double EmployeeSalary = 0;
        double extraDay = 0;
        double RestDay = 0;
        double worSalarey=0;
        double meal = 0;
        double home = 0;
        double rewarding = 0;
        double extras = 0;
        double fixedInsurances = 0;
        double varibaleInsurances = 0;
        double moneySanctions = 0;
        double daySanctions = 0;
        double uniform = 0;
        double insurancePolicy = 0;
        double tax = 0;
        double workDayes = 0;
        double sum = 0;
        double fixedEmployee; 
        double fixedCompany;
        double varEmployee;
        double varCompany;
        double advance=0;


        if (txtSalaryEmployeeSalary.Text == "" || txtSalaryEmployeeSalary.Text == ".")
        {
            EmployeeSalary = 0;
        }

        else
        {
            EmployeeSalary = double.Parse(txtSalaryEmployeeSalary.Text);
            EmployeeSalary = Math.Round(EmployeeSalary, 2);

        }
        if (txtSalaryRestDays.Text == "" || txtSalaryRestDays.Text == ".")
        {
            RestDay = 0;
        }

        else
        {
            RestDay = double.Parse(txtSalaryRestDays.Text);

        }

        if (txtSalaryExtraDays.Text == "" || txtSalaryExtraDays.Text == ".")
        {
            extraDay = 0;
        }
        else
        {
            extraDay = double.Parse(txtSalaryExtraDays.Text);
            extraDay = (extraDay * EmployeeSalary / 30);
            extraDay = Math.Round(extraDay, 2);
        }

        if (txtSalaryWorkDayes.Text == "" || txtSalaryWorkDayes.Text == ".")
        {
            workDayes = 0;
        }
        else
        {

            workDayes = double.Parse(txtSalaryWorkDayes.Text);
            worSalarey = (workDayes + RestDay);
            worSalarey = worSalarey * (EmployeeSalary / 30);
            worSalarey = Math.Round(worSalarey, 2);

        }

        if (txtSalaryMeal.Text == "" || txtSalaryMeal.Text == ".")
        {
            meal = 0;
        }
        else
        {
            meal = double.Parse(txtSalaryMeal.Text);
            meal = meal * workDayes;
            meal = Math.Round(meal, 2);

        }

        if (txtSalaryHome.Text == "" || txtSalaryHome.Text == "")
        {
            home = 0;
        }
        else
        {
            home = double.Parse(txtSalaryHome.Text);
            home = Math.Round(home, 2);
        }

        if (txtSalaryRewarding.Text == "" || txtSalaryRewarding.Text == ".")
        {
            rewarding = 0;
        }
        else
        {
            rewarding = double.Parse(txtSalaryRewarding.Text);
            rewarding = Math.Round(rewarding, 2);
        }

        if (txtSalaryExtras.Text == "" || txtSalaryExtras.Text == ".")
        {
            extras = 0;
        }
        else
        {
            extras = double.Parse(txtSalaryExtras.Text);
            extras = Math.Round(extras, 2);
        }

        if (txtSalaryFixedInsurances.Text == "" || txtSalaryFixedInsurances.Text == ".")
        {
            fixedInsurances = 0;
            fixedEmployee = 0;
            fixedCompany = 0;
            txtSalaryFixedCompany.Text = "0";
            txtSalaryFixedEmployee.Text = "0";
        }
        else
        {
            fixedInsurances = double.Parse(txtSalaryFixedInsurances.Text);

            fixedEmployee = .14 * fixedInsurances;
            fixedCompany = .26 * fixedInsurances;
            txtSalaryFixedCompany.Text = fixedCompany.ToString();
            txtSalaryFixedEmployee.Text = fixedEmployee.ToString();

            //   fixedInsurances = (fixedInsurances / 100) * EmployeeSalary;
            // fixedInsurances = Math.Round(fixedInsurances, 2);
        }

        if (txtSalaryVaribaleInsurances.Text == "" || txtSalaryVaribaleInsurances.Text == ".")
        {
            varibaleInsurances = 0;
            varEmployee = 0;
            varCompany = 0;
            txtSalaryVarCompany.Text = "0";
            txtSalaryVarEmployee.Text = "0";
        }
        else
        {
            varibaleInsurances = double.Parse(txtSalaryVaribaleInsurances.Text);
            varEmployee = .11 * varibaleInsurances;
            varCompany = .25 * varibaleInsurances;
            txtSalaryVarCompany.Text = varCompany.ToString();
            txtSalaryVarEmployee.Text = varEmployee.ToString();
            //  varibaleInsurances = (varibaleInsurances / 100) * EmployeeSalary;
            // varibaleInsurances = Math.Round(varibaleInsurances, 2);
        }

        if (txtSalaryMoneySanctions.Text == "" || txtSalaryMoneySanctions.Text == ".")
        {
            moneySanctions = 0;
        }
        else
        {
            moneySanctions = double.Parse(txtSalaryMoneySanctions.Text);
            moneySanctions = Math.Round(moneySanctions, 2);
        }

        if (txtSalaryDaySanctions.Text == "" || txtSalaryDaySanctions.Text == ".")
        {
            daySanctions = 0;
        }
        else
        {
            daySanctions = double.Parse(txtSalaryDaySanctions.Text);
            daySanctions = daySanctions * (EmployeeSalary / 30);
            daySanctions = Math.Round(daySanctions, 2);
        }

        if (txtSalaryUniform.Text == "" || txtSalaryUniform.Text == ".")
        {
            uniform = 0;
        }
        else
        {
            uniform = double.Parse(txtSalaryUniform.Text);
            uniform = Math.Round(uniform, 2);
        }

        if (txtSalaryInsurancePolicy.Text == "" || txtSalaryInsurancePolicy.Text == ".")
        {
            insurancePolicy = 0;
        }
        else
        {
            insurancePolicy = double.Parse(txtSalaryInsurancePolicy.Text);
            insurancePolicy = Math.Round(insurancePolicy, 2);
        }
        

        if (txtSalaryAdnace.Text == "" || txtSalaryAdnace.Text == ".")
        {
            advance = 0;
        }
        else
        {

            advance = double.Parse(txtSalaryAdnace.Text);
            advance = Math.Round(advance, 2);

        }

        sum = worSalarey + extraDay + meal + home + rewarding + extras - fixedEmployee - varEmployee - moneySanctions - daySanctions - insurancePolicy - uniform-advance;
        sum = Math.Round(sum, 2);
        txtSalaryBeforTax.Text = sum.ToString();
        txtSalaryFixedCompany.Text = fixedCompany.ToString();
        txtSalaryFixedEmployee.Text = fixedEmployee.ToString();

        if (txtSalaryInsurancePolicy.Text == "" || txtSalaryInsurancePolicy.Text == ".")
        {
            insurancePolicy = 0;
        }
        else
        {
            insurancePolicy = double.Parse(txtSalaryInsurancePolicy.Text);
            insurancePolicy = Math.Round(insurancePolicy, 2);
        }

        if (sum > 1000)
        {
            if (rdBtnSalaryTax.Checked)
            {
                double result = sum - 1000;
                //  tax = double.Parse(txtTax.Text);
                sum = sum - (0.10 * result);
                sum = Math.Round(sum, 2);
                txtSalaryTax.Text = (0.10 * result).ToString();
            }
            else
            {
                txtSalaryTax.Text = "";
            }

        }
        else
        {
            txtSalaryTax.Text = "";
        }
        txtSalaryAfterTax.Text = sum.ToString();
    }

    public void insertEmployeeSalary(int ID, DateTime dateSalaryRecord, TextBox txtSalaryEmployeeSalary, TextBox txtSalaryWorkDayes, TextBox txtSalaryRestDays, TextBox txtSalaryExtraDays, TextBox txtSalaryFixedInsurances, TextBox txtSalaryVaribaleInsurances, TextBox txtSalaryFixedEmployee, TextBox txtSalaryFixedCompany, TextBox txtSalaryVarEmployee, TextBox txtSalaryVarCompany, TextBox txtSalaryMoneySanctions, TextBox txtSalaryDaySanctions, TextBox txtSalaryUniform, TextBox txtSalaryInsurancePolicy, TextBox txtSalaryMeal, TextBox txtSalaryHome, TextBox txtSalaryRewarding, TextBox txtSalaryExtras, TextBox txtSalaryAdnace, RadioButton rdBtnSalaryTax, TextBox txtSalaryBeforTax, TextBox txtSalaryTax, TextBox txtSalaryAfterTax, RichTextBox rTBSalaryComment,string type,int monthh , int yearr)
    {
        try
        {
            employee = new Employee();
            employeeDB = new EmployeeDB();
            employeeSalary = new EmployeeSalary();
            employeeSalaryDB = new EmployeeSalaryDB();

            int employeeID = ID;
            employee.setID(ID);
            employeeDB.selectLocationID(employee);
            int locationID = employee.getLocationID();
            string SalaryDate = dateSalaryRecord.ToString("dd-MM-yyyy");
            double EmployeeSalary = double.Parse(txtSalaryEmployeeSalary.Text);
            double workDayes = double.Parse(txtSalaryWorkDayes.Text);
            double extraDay = double.Parse(txtSalaryExtraDays.Text); ;
            double RestDay = double.Parse(txtSalaryRestDays.Text);
            double meal = double.Parse(txtSalaryMeal.Text);
            double home = double.Parse(txtSalaryHome.Text);
            double rewarding = double.Parse(txtSalaryRewarding.Text);
            double extras = double.Parse(txtSalaryExtras.Text);
            double advance = double.Parse(txtSalaryAdnace.Text);
            double fixedInsurances = double.Parse(txtSalaryFixedInsurances.Text);
            double varibaleInsurances = double.Parse(txtSalaryVaribaleInsurances.Text);
            double moneySanctions = double.Parse(txtSalaryMoneySanctions.Text);
            double daySanctions = double.Parse(txtSalaryDaySanctions.Text);
            double uniform = double.Parse(txtSalaryUniform.Text);
            double insurancePolicy = double.Parse(txtSalaryInsurancePolicy.Text);
            double BeforTax = double.Parse(txtSalaryBeforTax.Text);
            double tax = double.Parse(txtSalaryTax.Text);
            double AftrTax = double.Parse(txtSalaryAfterTax.Text);
            string comment = rTBSalaryComment.Text;
            string typeEmployee = type;
            double fixedEmployee = double.Parse(txtSalaryFixedEmployee.Text);
            double fixedCompany = double.Parse(txtSalaryFixedCompany.Text);
            double varEmployee = double.Parse(txtSalaryVarEmployee.Text);
            double varCompany = double.Parse(txtSalaryVarCompany.Text);
            int month = monthh;
            int year = yearr;

            employeeSalary.setEmployeeID(employeeID);
            employeeSalary.setLocationID(locationID);
            employeeSalary.setSalaryDate(SalaryDate);
            employeeSalary.setEmployeSalary(EmployeeSalary);
            employeeSalary.setWorkDay(workDayes);
            employeeSalary.setExtraDay(extraDay);
            employeeSalary.setRestDay(RestDay);
            employeeSalary.setMeal(meal);
            employeeSalary.setHome(home);
            employeeSalary.setRewarding(rewarding);
            employeeSalary.setExtras(extras);
            employeeSalary.setAdvance(advance);
            employeeSalary.setFixedInsurances(fixedInsurances);
            employeeSalary.setVariableInsurances(varibaleInsurances);
            employeeSalary.setMoneySanctions(moneySanctions);
            employeeSalary.setDaySanctions(daySanctions);
            employeeSalary.setUniform(uniform);
            employeeSalary.setInsurancePolicy(insurancePolicy);
            employeeSalary.setFinalSalaryBeforTax(BeforTax);
            employeeSalary.setTax(tax);
            employeeSalary.setFinalSalaryAfterTax(AftrTax);
            employeeSalary.setComment(comment);
            employeeSalary.setType(type);
            employeeSalary.setfixedEmployee(fixedEmployee);
            employeeSalary.setfixedCompany(fixedCompany);
            employeeSalary.setvarEmployee(varEmployee);
            employeeSalary.setvarCompany(varCompany);
            employeeSalary.setMonth(month);
            employeeSalary.setYear(year);
            employeeSalaryDB.insert(employeeSalary);
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    public void fillEmployeeSalaries(int ID, DateTimePicker dateSalaryRecord, TextBox txtSalaryEmployeeSalary, TextBox txtSalaryWorkDayes, TextBox txtSalaryRestDays, TextBox txtSalaryExtraDays, TextBox txtSalaryFixedInsurances, TextBox txtSalaryVaribaleInsurances, TextBox txtSalaryFixedEmployee, TextBox txtSalaryFixedCompany, TextBox txtSalaryVarEmployee, TextBox txtSalaryVarCompany, TextBox txtSalaryMoneySanctions, TextBox txtSalaryDaySanctions, TextBox txtSalaryUniform, TextBox txtSalaryInsurancePolicy, TextBox txtSalaryMeal, TextBox txtSalaryHome, TextBox txtSalaryRewarding, TextBox txtSalaryExtras, TextBox txtSalaryAdnace, RadioButton rdBtnSalaryTax, RadioButton rdBtnWithoutTaxUpTextBox, TextBox txtSalaryBeforTax, TextBox txtSalaryTax, TextBox txtSalaryAfterTax, RichTextBox rTBSalaryComment, string type, int month, int year)

    {
        employeeSalaryDB = new EmployeeSalaryDB();
        employeeSalary = new EmployeeSalary();
        connection = new DBConnection();
        employeeSalary.setSalaryID(SalaryID(ID, month, year));
        SqlDataReader reader = employeeSalaryDB.fillInfoEmployeeSalary(employeeSalary);
        while (reader.Read())
        {    
            dateSalaryRecord.Value = Convert.ToDateTime(reader["salaryDate"].ToString());
            txtSalaryEmployeeSalary.Text = reader["EmployeeSalary"].ToString() ;
            txtSalaryWorkDayes.Text = reader["workDay"].ToString() ;
            txtSalaryRestDays.Text = reader["restDay"].ToString() ;
            txtSalaryExtraDays.Text = reader["extraDay"].ToString() ;
            txtSalaryFixedInsurances.Text = reader["FixedInsurances"].ToString() ;
            txtSalaryVaribaleInsurances.Text = reader["variableInsurances"].ToString() ;
            txtSalaryFixedEmployee.Text = reader["fixedEmployee"].ToString() ;
            txtSalaryFixedCompany.Text = reader["fixedCompany"].ToString() ;
            txtSalaryVarEmployee.Text = reader["variableEmployee"].ToString() ;
            txtSalaryVarCompany.Text = reader["variableCompany"].ToString() ;
            txtSalaryMoneySanctions.Text = reader["monySanctions"].ToString() ;
            txtSalaryDaySanctions.Text = reader["daySanctions"].ToString() ;
            txtSalaryUniform.Text = reader["uniform"].ToString() ;
            txtSalaryInsurancePolicy.Text = reader["insurancePolicy"].ToString() ;
            txtSalaryMeal.Text = reader["meal"].ToString() ;
            txtSalaryHome.Text = reader["home"].ToString() ;
            txtSalaryRewarding.Text = reader["rewarding"].ToString() ;
            txtSalaryExtras.Text = reader["extras"].ToString() ;
            txtSalaryAdnace.Text = reader["advance"].ToString() ;
            txtSalaryBeforTax.Text = reader["finalSalaryBeforTax"].ToString() ;
            txtSalaryTax.Text = reader["tax"].ToString() ;
            txtSalaryAfterTax.Text = reader["finalSalaryAfterTax"].ToString() ;
            rTBSalaryComment.Text = reader["comment"].ToString();
            if (txtSalaryTax.Text == "0")
            {
                rdBtnSalaryTax.Checked = false;
                rdBtnWithoutTaxUpTextBox.Checked = true;
            }
            else
            {               
                rdBtnSalaryTax.Checked = true;
                rdBtnWithoutTaxUpTextBox.Checked = false;
            }

        }

        connection.close();
        
    }
    public void updateEmployeeSalary(int ID, DateTime dateSalaryRecord, TextBox txtSalaryEmployeeSalary, TextBox txtSalaryWorkDayes, TextBox txtSalaryRestDays, TextBox txtSalaryExtraDays, TextBox txtSalaryFixedInsurances, TextBox txtSalaryVaribaleInsurances, TextBox txtSalaryFixedEmployee, TextBox txtSalaryFixedCompany, TextBox txtSalaryVarEmployee, TextBox txtSalaryVarCompany, TextBox txtSalaryMoneySanctions, TextBox txtSalaryDaySanctions, TextBox txtSalaryUniform, TextBox txtSalaryInsurancePolicy, TextBox txtSalaryMeal, TextBox txtSalaryHome, TextBox txtSalaryRewarding, TextBox txtSalaryExtras, TextBox txtSalaryAdnace, RadioButton rdBtnSalaryTax, TextBox txtSalaryBeforTax, TextBox txtSalaryTax, TextBox txtSalaryAfterTax, RichTextBox rTBSalaryComment, string type, int monthh, int yearr)
    {
        try
        {
            employee = new Employee();
            employeeDB = new EmployeeDB();
            employeeSalary = new EmployeeSalary();
            employeeSalaryDB = new EmployeeSalaryDB();

            int employeeID = ID;
            employee.setID(ID);
            employeeDB.selectLocationID(employee);
            int locationID = employee.getLocationID();
            string SalaryDate = dateSalaryRecord.ToString("dd-MM-yyyy");
            double EmployeeSalary = double.Parse(txtSalaryEmployeeSalary.Text);
            double workDayes = double.Parse(txtSalaryWorkDayes.Text);
            double extraDay = double.Parse(txtSalaryExtraDays.Text); ;
            double RestDay = double.Parse(txtSalaryRestDays.Text);
            double meal = double.Parse(txtSalaryMeal.Text);
            double home = double.Parse(txtSalaryHome.Text);
            double rewarding = double.Parse(txtSalaryRewarding.Text);
            double extras = double.Parse(txtSalaryExtras.Text);
            double advance = double.Parse(txtSalaryAdnace.Text);
            double fixedInsurances = double.Parse(txtSalaryFixedInsurances.Text);
            double varibaleInsurances = double.Parse(txtSalaryVaribaleInsurances.Text);
            double moneySanctions = double.Parse(txtSalaryMoneySanctions.Text);
            double daySanctions = double.Parse(txtSalaryDaySanctions.Text);
            double uniform = double.Parse(txtSalaryUniform.Text);
            double insurancePolicy = double.Parse(txtSalaryInsurancePolicy.Text);
            double BeforTax = double.Parse(txtSalaryBeforTax.Text);
            double tax = double.Parse(txtSalaryTax.Text);
            double AftrTax = double.Parse(txtSalaryAfterTax.Text);
            string comment = rTBSalaryComment.Text;
            string typeEmployee = type;
            double fixedEmployee = double.Parse(txtSalaryFixedEmployee.Text);
            double fixedCompany = double.Parse(txtSalaryFixedCompany.Text);
            double varEmployee = double.Parse(txtSalaryVarEmployee.Text);
            double varCompany = double.Parse(txtSalaryVarCompany.Text);
            int month = monthh;
            int year = yearr;

          

            employeeSalary.setSalaryID(SalaryID(employeeID, month, year));
            employeeSalary.setEmployeeID(employeeID);
            employeeSalary.setLocationID(locationID);
            employeeSalary.setSalaryDate(SalaryDate);
            employeeSalary.setEmployeSalary(EmployeeSalary);
            employeeSalary.setWorkDay(workDayes);
            employeeSalary.setExtraDay(extraDay);
            employeeSalary.setRestDay(RestDay);
            employeeSalary.setMeal(meal);
            employeeSalary.setHome(home);
            employeeSalary.setRewarding(rewarding);
            employeeSalary.setExtras(extras);
            employeeSalary.setAdvance(advance);
            employeeSalary.setFixedInsurances(fixedInsurances);
            employeeSalary.setVariableInsurances(varibaleInsurances);
            employeeSalary.setMoneySanctions(moneySanctions);
            employeeSalary.setDaySanctions(daySanctions);
            employeeSalary.setUniform(uniform);
            employeeSalary.setInsurancePolicy(insurancePolicy);
            employeeSalary.setFinalSalaryBeforTax(BeforTax);
            employeeSalary.setTax(tax);
            employeeSalary.setFinalSalaryAfterTax(AftrTax);
            employeeSalary.setComment(comment);
            employeeSalary.setType(type);
            employeeSalary.setfixedEmployee(fixedEmployee);
            employeeSalary.setfixedCompany(fixedCompany);
            employeeSalary.setvarEmployee(varEmployee);
            employeeSalary.setvarCompany(varCompany);
            employeeSalary.setMonth(month);
            employeeSalary.setYear(year);

            employeeSalaryDB.update(employeeSalary);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    public int SalaryID(int ID , int month , int year)
    {
        employeeSalary = new EmployeeSalary();
        employeeSalaryDB = new EmployeeSalaryDB();
        employeeSalary.setEmployeeID(ID);
        employeeSalary.setMonth(month);
        employeeSalary.setYear(year);
        employeeSalaryDB.selectSalaryEmployeeID(employeeSalary);
        return employeeSalary.getSalaryID();
    }
}
