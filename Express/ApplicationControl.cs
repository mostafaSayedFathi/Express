using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

class ApplicationControl
{
    private ApplicationForm application;
    private ApplicationDB applicationDB;
    private SourceDB sourceDB;
    private SourceControl sourceControl;
    private DBConnection connection;
    private Boolean check;

    public Boolean insertApplication(string applayDate, string name, string sex, string address, string birthDate, string education, string source, string state, string comment, double salary, int workHours, int mobilePhone, int phone, int familyPhone, string nationalID, byte[] image)
    {
        application = new ApplicationForm();
        applicationDB = new ApplicationDB();
        sourceControl = new SourceControl();

        application.setName(name);
        application.setApplayDate(applayDate);
        application.setSex(sex);
        application.setAddress(address);
        application.setBirthDate(birthDate);
        application.setEducation(education);
        application.setSource(sourceControl.selectID(source));
        application.setState(state);
        application.setComment(comment);
        application.setSalary(salary);
        application.setWorkHours(workHours);
        application.setMobilePhone(mobilePhone);
        application.setPhone(phone);
        application.setFamilyPhone(familyPhone);
        application.setNationalID(nationalID);
        application.setImage(image);
        check = applicationDB.checkApplication(application);
        if (check == true)
        {
            return false;
        }
        else
        {
            applicationDB.insert(application);
            return true;
        }

    }

    public void fillComboboxSourceName(ComboBox comboBox)
    {
        comboBox.Items.Clear();
        sourceDB = new SourceDB();
        connection = new DBConnection();
        SqlDataReader reader = sourceDB.fillComboboxSourceName();
        while (reader.Read())
        {
            comboBox.Items.Add(reader["sourceName"]);
        }
        connection.close();
        comboBox.SelectedIndex = 0;
    }

    public void fillComboboxSex(ComboBox comboBox)
    {
        comboBox.Items.Clear();
        comboBox.Items.Add("ذكر");
        comboBox.Items.Add("انثي");
        comboBox.SelectedIndex = 0;

    }

    public void fillComboboxWorkHours(ComboBox comboBox)
    {
        comboBox.Items.Clear();
        comboBox.Items.Add("8");
        comboBox.Items.Add("12");
        comboBox.SelectedIndex = 0;
    }

    public void fillComboboxEducation(ComboBox comboBox)
    {
        comboBox.Items.Clear();
        comboBox.Items.Add("مؤهل متوسط");
        comboBox.Items.Add("مؤهل فوق المتوسط");
        comboBox.Items.Add("مؤهل عالي");
        comboBox.SelectedIndex = 0;

    }

    public string imageBrows(PictureBox picture)
    {
        Stream myStream = null;
        string filePath = "";
        OpenFileDialog openFileDialog = new OpenFileDialog();
        // openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.bmp)|*.jpg; *.jpeg; *.bmp";
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                if ((myStream = openFileDialog.OpenFile()) != null)
                {
                    filePath = openFileDialog.FileName;
                    if (myStream.Length > 512000)
                    {
                        MessageBox.Show("File size limit exceed");
                    }
                    else
                    {
                        //pb is my pictureBox name load image in pb
                        picture.SizeMode = PictureBoxSizeMode.StretchImage;
                        picture.Load(filePath);
                    }
                    //MessageBox.Show(myStream.Length.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read file from disk. error: " + ex.Message);
            }
        }
        return filePath;
    }

    public byte[] ReadImageFile(string imageLocation)
    {
        byte[] imageData = null;
        FileInfo fileInfo = new FileInfo(imageLocation);
        long imageFileLength = fileInfo.Length;
        FileStream fs = new FileStream(imageLocation, FileMode.Open, FileAccess.Read);
        BinaryReader br = new BinaryReader(fs);
        imageData = br.ReadBytes((int)imageFileLength);
        return imageData;
    }
}
