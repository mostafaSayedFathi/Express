using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Express
{
    public partial class FormUpdateSource : Form
    {
        SourceControl sourceControl;

        public FormUpdateSource()
        {
            InitializeComponent();
            sourceControl = new SourceControl();
            sourceControl.fillComboboxSourceName(comboBoxSorceName);
        }

        private void comboBoxSorceName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                sourceControl = new SourceControl();
                string sourceName = comboBoxSorceName.Text;
                string address = sourceControl.getSourceAddress(sourceName);
                string employee1 = sourceControl.getSourceEmployee1(sourceName);
                string employee2 = sourceControl.getSourceEmployee2(sourceName);
                string phone1 = sourceControl.getSourcePhone1(sourceName);
                string phone2 = sourceControl.getSourcePhone2(sourceName);
                string phone3 = sourceControl.getSourcePhone3(sourceName);
                txtSourceName.Text = sourceName;
                txtSourceAddress.Text = address;
                txtSourceEmployee1.Text = employee1;
                txtSourceEmployee2.Text = employee2;
                txtSourcePhone1.Text = phone1;
                txtSourcePhone2.Text = phone2;
                txtSourcePhone3.Text = phone3;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdateSource_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxSorceName.Text == "")
                {
                    MessageBox.Show("من فضلك اختر المكتب", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtSourceName.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل اسم المكتب", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    sourceControl = new SourceControl();
                    string previousName = comboBoxSorceName.Text;
                    string sourceName = txtSourceName.Text;
                    string address = txtSourceAddress.Text;
                    string employee1 = txtSourceEmployee1.Text;
                    string employee2 = txtSourceEmployee2.Text;
                    string phone1 = txtSourcePhone1.Text;
                    string phone2 = txtSourcePhone2.Text;
                    string phone3 = txtSourcePhone3.Text;
                    sourceControl.updateSource(previousName, sourceName, address, employee1, employee2, phone1, phone2, phone3);
                    MessageBox.Show("تم تعديل البيانات بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSourceName.Text = "";
                    txtSourceAddress.Text = "";
                    txtSourceEmployee1.Text = "";
                    txtSourceEmployee2.Text = "";
                    txtSourcePhone1.Text = "";
                    txtSourcePhone2.Text = "";
                    txtSourcePhone3.Text = "";
                    sourceControl.fillComboboxSourceName(comboBoxSorceName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
