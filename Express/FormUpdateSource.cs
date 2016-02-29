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
                txtSourceName.Text = sourceName;
                txtSourceAddress.Text = address;
                txtSourceEmployee1.Text = employee1;
                txtSourceEmployee2.Text = employee2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
