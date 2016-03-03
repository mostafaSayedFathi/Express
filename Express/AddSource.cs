using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Express_Project
{
    public partial class AddSource : Form
    {
        private SourceControl sourceControl; 
        public AddSource()
        {
            InitializeComponent();
        }

        public void setZero()
        {
            if(txtSourcePhone1.Text=="")
            {
                txtSourcePhone1.Text = "0";
            }

            if (txtSourcePhone2.Text == "")
            {
                txtSourcePhone2.Text = "0";
            }

            if (txtSourcePhone3.Text == "")
            {
                txtSourcePhone3.Text = "0";
            }
        }
        private void btnAddSource_Click(object sender, EventArgs e)
        {
            try
            {
                sourceControl = new SourceControl();
                if (txtSourceName.Text == "")
                {
                    MessageBox.Show("!خطأ لم يتم إدخال اسم المكتب", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Boolean check = false;
                    string name = txtSourceName.Text;
                    string address = txtSourceAddress.Text;
                    string EmployeeName1 = txtSourceEmployee1.Text;
                    string EmployeeName2 = txtSourceEmployee2.Text;
                    setZero();
                    string phone1 = txtSourcePhone1.Text;
                    string phone2 = txtSourcePhone2.Text;
                    string phone3 = txtSourcePhone3.Text;

                    check = sourceControl.insertSource(name, address, EmployeeName1, EmployeeName2, phone1, phone2, phone3);
                    if (check == false)
                    {
                        MessageBox.Show("!لقد تم إضافة هذا المكتب من قبل ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("تمت إضافةالمكتب بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSourceName.Text = "";
                        txtSourceAddress.Text = "";
                        txtSourceEmployee1.Text = "";
                        txtSourceEmployee2.Text = "";
                        txtSourcePhone1.Text = "";
                        txtSourcePhone2.Text = "";
                        txtSourcePhone3.Text = "";
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSourcePhone1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            
        }

        private void txtSourcePhone2_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txtSourcePhone3_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtSourcePhone3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSourcePhone2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
