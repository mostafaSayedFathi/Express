using Express_Project;
using System;
using System.Collections;
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
    public partial class Form1 : Form
    {
        //dateTimePicker3.Value = Convert.ToDateTime("3-5-2012");
        LocationControl locationControl;
        EmployeeControl employeeControl;
        private ApplicationControl applicationControl;
        private DevicesStoreControl devicesStoreControl;
        private ClothesStoreControl clothesStoreControl;
        private LocationClothesContentControl locationClothesContentControl;
        private LocationEquipsContentControl locationEquipsContentControl;
        private LocationClothesControl locationClothesControl;
        private LocationEquipsConrol locationEquipsConrol;
        private SourceControl sourceControl;
        private AttendanceControl attendanceControl;
        private AttendanceContentControl attendanceContentControl;
        private byte[] imageByte = null;
        private ArrayList listCheck = new ArrayList();
        private ArrayList listCheckDevices = new ArrayList();
        private string PreviousUpdateDeviceName = "";
        private string PreviousUpdateClotheType = "";
        private HashSet<string> deletedClothes;
        private HashSet<string> deletedDevices;

        public Form1()
        {
            InitializeComponent();
            disaplePanels();
            deletedClothes = new HashSet<string>();
            deletedDevices = new HashSet<string>();
        }

        public List<string> getCompinations(int s)
        {
            List<string> c = new List<string>();
            var alphabet = "APSLO";
            var q = alphabet.Select(x => x.ToString());
            int size = s;
            for (int i = 0; i < size - 1; i++)
                q = q.SelectMany(x => alphabet, (x, y) => x + y);

            foreach (var item in q)
                c.Add(item);
            return c;
        }

        public void disaplePanels()
        {
            panelNewEmployee.Visible = false;
            panelNewLocation.Visible = false;
            panelLocationCosts.Visible = false;
            PanelNewApplication.Visible = false;
            PanelUpdateClotheStore.Visible = false;
            PanelAddClothe.Visible = false;
            PanelDeleteFromclothesStore.Visible = false;
            PanelAddDevices.Visible = false;
            PanelUpdateDeviceStore.Visible = false;
            PanelDeleteFromDevicesStore.Visible = false;
            panelUpdateLocation.Visible = false;
            panelUpdateLocationCosts.Visible = false;
            panelUpdateEmployee.Visible = false;
            panelSourceEvaluation.Visible = false;
            panelAttendance.Visible = false;
        }

        private void btnStartOperation_Click(object sender, EventArgs e)
        {
            try
            {
                locationControl = new LocationControl();
                //converting date to SQL format
                DateTime startDate = dtpStartdate.Value;
                DateTime endDate = dtpEndDate.Value;
                string startDateSQL = startDate.ToString("yyyy-MM-dd");
                string endDateSQL = endDate.ToString("yyyy-MM-dd");
                string locationName;
                string locationAdress;
                int securityNumbers;
                int supervisorNumbers;
                int managerNumbers;
                int workHours;

                if (txtLocationName.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل اسم الموقع", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtLocationAddress.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل عنوان الموقع", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtSecurityNumbers.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل عدد فرد امن", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtSupervisorNumbers.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل عدد مشرف موقع", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtManagerNumbers.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل عدد مدير موقع", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (comboBoxWorkHours.Text == "")
                {
                    MessageBox.Show("من فضلك اختر عدد ساعات العمل بالموقع", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult result = MessageBox.Show("هل قمت بمراجعة البيانات", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        locationName = txtLocationName.Text;
                        locationAdress = txtLocationAddress.Text;
                        securityNumbers = int.Parse(txtSecurityNumbers.Text);
                        supervisorNumbers = int.Parse(txtSupervisorNumbers.Text);
                        managerNumbers = int.Parse(txtManagerNumbers.Text);
                        workHours = int.Parse(comboBoxWorkHours.Text);
                        locationControl.insertLocation(locationName, locationAdress, startDateSQL, endDateSQL, securityNumbers, supervisorNumbers, managerNumbers, workHours);
                        MessageBox.Show("تم بدأ تشغيل الموقع بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (result == DialogResult.No)
                    {
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void التكاليفToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxLocationName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                locationControl = new LocationControl();
                locationControl.getLocationID(comboBoxLocationName.Text);
                txtCostSecurityNumbers.Text = locationControl.getSecurityNumbers().ToString();
                txtCostSupervisorNumbers.Text = locationControl.getSupervisorNumbers().ToString();
                txtCostManagerNumbers.Text = locationControl.getManagerNumbers().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCostSecuritySalary_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtCostSecuritySalary.Text == "")
                {
                    txtCostTotalSecurity.Text = "0";
                }
                else
                {
                    txtCostTotalSecurity.Text = (int.Parse(txtCostSecurityNumbers.Text) * int.Parse(txtCostSecuritySalary.Text)).ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCostSupervisorSalary_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtCostSupervisorSalary.Text == "")
                {
                    txtCostTotalSupervisor.Text = "0";
                }
                else
                {
                    txtCostTotalSupervisor.Text = (int.Parse(txtCostSupervisorNumbers.Text) * int.Parse(txtCostSupervisorSalary.Text)).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCostManagerSalary_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtCostManagerSalary.Text == "")
                {
                    txtCostTotalManager.Text = "0";
                }
                else
                {
                    txtCostTotalManager.Text = (int.Parse(txtCostManagerNumbers.Text) * int.Parse(txtCostManagerSalary.Text)).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void تعيينجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                panelNewEmployee.Visible = true;
                panelNewLocation.Visible = false;
                panelLocationCosts.Visible = false;
                PanelNewApplication.Visible = false;
                PanelAddClothe.Visible = false;
                PanelUpdateClotheStore.Visible = false;
                PanelDeleteFromclothesStore.Visible = false;
                PanelAddDevices.Visible = false;
                PanelUpdateDeviceStore.Visible = false;
                PanelDeleteFromDevicesStore.Visible = false;
                panelUpdateLocation.Visible = false;
                panelUpdateLocationCosts.Visible = false;
                panelUpdateEmployee.Visible = false;
                panelSourceEvaluation.Visible = false;
                panelAttendance.Visible = false;
                employeeControl = new EmployeeControl();
                locationControl = new LocationControl();
                sourceControl = new SourceControl();
                locationControl.fillComboboxLocationNameReady(comboBoxNewEmployeeLocation);
                sourceControl.fillComboboxSourceName(comboBoxNewEmployeeSource);
                txtNewEmployeeID.Text = employeeControl.lastIDPlusOne().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxNewEmployeePosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxNewEmployeeLocation.Text == "")
                {
                    MessageBox.Show("من فضلك اختر اسم الموقع اولاً", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBoxNewEmployeePosition.Items.Clear();
                    comboBoxNewEmployeePosition.Items.Add("موظف امن");
                    comboBoxNewEmployeePosition.Items.Add("مشرف امن");
                    comboBoxNewEmployeePosition.Items.Add("مدير موقع");
                }
                else
                {
                    locationControl = new LocationControl();
                    employeeControl = new EmployeeControl();
                    string locationName = comboBoxNewEmployeeLocation.Text;
                    if (comboBoxNewEmployeePosition.Text == "موظف امن")
                    {
                        string securitySalary = locationControl.getSecuritySalary(locationName).ToString();
                        txtNewEmployeeSalary.Text = securitySalary;
                        txtNewEmployeeAvailable.Text = employeeControl.availableSecurityInLocation(locationName).ToString();
                    }
                    else if (comboBoxNewEmployeePosition.Text == "مشرف امن")
                    {
                        string supervisorSalary = locationControl.getSupervisorSalary(locationName).ToString();
                        txtNewEmployeeSalary.Text = supervisorSalary;
                        txtNewEmployeeAvailable.Text = employeeControl.availableSupervisorInLocation(locationName).ToString();
                    }
                    else if (comboBoxNewEmployeePosition.Text == "مدير موقع")
                    {
                        string managerSalary = locationControl.getManagerSalary(locationName).ToString();;
                        txtNewEmployeeSalary.Text = managerSalary;
                        txtNewEmployeeAvailable.Text = employeeControl.availableManagerInLocation(locationName).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxNewEmployeeLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxNewEmployeePosition.Items.Clear();
            comboBoxNewEmployeePosition.Items.Add("موظف امن");
            comboBoxNewEmployeePosition.Items.Add("مشرف امن");
            comboBoxNewEmployeePosition.Items.Add("مدير موقع");
            txtNewEmployeeSalary.Text = "";
            txtNewEmployeeAvailable.Text = "";
        }

        private void btnAddNewEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNewEmployeeNationalID.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل الرقم القومي", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtNewEmployeeName.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل اسم الموظف", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (comboBoxNewEmployeeLocation.Text == "")
                {
                    MessageBox.Show("من فضلك اختر اسم الموقع", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (comboBoxNewEmployeePosition.Text == "")
                {
                    MessageBox.Show("من فضلك اختر الوظيفة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtNewEmployeeSalary.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل المرتب", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult result = MessageBox.Show("هل قمت بمراجعة البيانات؟", "سؤال", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        MessageBox.Show("من فضلك قم بمراجعة البيانات", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if(result == DialogResult.Yes)
                    {
                        employeeControl = new EmployeeControl();
                        string nationalID = txtNewEmployeeNationalID.Text;
                        string employeeName = txtNewEmployeeName.Text;
                        DateTime date = dtpNewEmployee.Value;
                        string dateSQL = date.ToString("yyyy-MM-dd");
                        string ID = txtNewEmployeeID.Text;
                        string locationName = comboBoxNewEmployeeLocation.Text;
                        string position = comboBoxNewEmployeePosition.Text;
                        double salary = double.Parse(txtNewEmployeeSalary.Text);
                        string source = comboBoxNewEmployeeSource.Text;
                        employeeControl.insertEmployee(nationalID, employeeName, dateSQL, position, salary, locationName, source);
                        MessageBox.Show("تمت العملية بنجاح" + Environment.NewLine + "اسم الموظف: " + employeeName + Environment.NewLine + "الكود: " + ID + Environment.NewLine + "الموقع: " + locationName, "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripDropDownButton4_Click(object sender, EventArgs e)
        {

        }

        private void toolStripDropDownButton3_Click(object sender, EventArgs e)
        {

        }

        private void اضافةمصدرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSource form = new AddSource();
            form.ShowDialog();

        }

        private void تقديمطلبتوظيفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                panelNewEmployee.Visible = false;
                panelNewLocation.Visible = false;
                panelLocationCosts.Visible = false;
                PanelNewApplication.Visible = true;
                PanelAddClothe.Visible = false;
                PanelUpdateClotheStore.Visible = false;
                PanelDeleteFromclothesStore.Visible = false;
                PanelAddDevices.Visible = false;
                PanelUpdateDeviceStore.Visible = false;
                PanelDeleteFromDevicesStore.Visible = false;
                panelUpdateLocation.Visible = false;
                panelUpdateLocationCosts.Visible = false;
                panelUpdateEmployee.Visible = false;
                panelSourceEvaluation.Visible = false;
                panelAttendance.Visible = false;
                applicationControl = new ApplicationControl();
                //InitializeComponent();
                applicationControl.fillComboboxSex(comboBoxAppSex);
                applicationControl.fillComboboxEducation(comboBoxAppEducation);
                applicationControl.fillComboboxSourceName(comboBoxAppSource);
                applicationControl.fillComboboxWorkHours(comboBoxAppWorkHours);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAppAdd_Click(object sender, EventArgs e)
        {
            try
            {
                setValue();
                DateTime applayDateForm = dateTimePickerApplayDate.Value;
                string applayDate = applayDateForm.ToString("MM-dd-yyyy");
                string name = txtAppName.Text;
                string sex = comboBoxAppSex.Text;
                string address = txtAppAddress.Text;
                DateTime birthDateForm = dateTimePickerAppBirthDate.Value;
                string birthDate = birthDateForm.ToString("MM-dd-yyyy");
                string education = comboBoxAppEducation.Text;
                string source = comboBoxAppSource.Text;
                string state = "";
                if (radioButtonAppAccepted.Checked)
                {
                    state = "Accepted";
                }
                else
                {
                    state = "Rejected";
                }
                string comment = richTextBoxAppComent.Text;
                double salary = double.Parse(txtAppSalary.Text);
                int workHours = Int32.Parse(comboBoxAppWorkHours.Text);
                int mobilePhone = Int32.Parse(txtAppMobilePhone.Text);
                int phone = Int32.Parse(txtAppHomePhone.Text);
                int familyPhone = Int32.Parse(txtAppFamilyPhone.Text);
                string nationalID = txtAppNationalD.Text;
                if (name == "")
                {
                    MessageBox.Show("من فضلك ادخل اسم المتقدم للعمل", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (sex == "")
                {
                    MessageBox.Show("من فضلك ادخل جنس المتقدم للعمل", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (address == "")
                {
                    MessageBox.Show("من فضلك ادخل عنوان المتقدم للعمل", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (education == "")
                {
                    MessageBox.Show("من فضلك ادخل المؤهل العلمي المتقدم للعمل", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (nationalID == "")
                {
                    MessageBox.Show("من فضلك ادخل رقم بطاقة المتقدم للعمل", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (salary == 0)
                {
                    MessageBox.Show("من فضلك ادخل المرتب المطلوب", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (mobilePhone == 0 && phone == 0 && familyPhone == 0)
                {
                    MessageBox.Show("من فضلك ادخل رقم واحد علي الاقل للتواصل", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Boolean check = applicationControl.insertApplication(applayDate, name, sex, address, birthDate, education, source, state, comment, salary, workHours, mobilePhone, phone, familyPhone, nationalID, imageByte);

                    if (check == true)
                        MessageBox.Show("!تمت عملية الاضافة بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("!لقد تم تسجيل هذا الطلب من قبل", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void setValue()
        {
            if (txtAppFamilyPhone.Text == "")
            {
                txtAppFamilyPhone.Text = "0";
            }
            if (txtAppHomePhone.Text == "")
            {
                txtAppHomePhone.Text = "0";
            }
            if (txtAppMobilePhone.Text == "")
            {
                txtAppMobilePhone.Text = "0";
            }
            if (txtAppSalary.Text == "")
            {
                txtAppSalary.Text = "0";
            }
        }

        private void btnClossImageApplication_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            imageByte = null;
        }

        private void btnChooseImageApp_Click(object sender, EventArgs e)
        {
            applicationControl = new ApplicationControl();
            string filePath = applicationControl.imageBrows(pictureBox1);
            imageByte = applicationControl.ReadImageFile(filePath);
        }

        private void txtAppMobilePhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtAppHomePhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtAppFamilyPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtAppNationalD_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtAppNationalD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSaveClothStore_Click(object sender, EventArgs e)
        {
            try
            {
                clothesStoreControl = new ClothesStoreControl();
                if (ListViewClothesStore.Items.Count == 0)
                {
                    MessageBox.Show("!لا يوجد ملابس ليتم اضافتها", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    Boolean check = false;
                    int count = 0;
                    foreach (ListViewItem lvi in ListViewClothesStore.Items)
                    {
                        string name = lvi.SubItems[0].Text;
                        double price = double.Parse(lvi.SubItems[1].Text);
                        double quantity = double.Parse(lvi.SubItems[2].Text);
                        double total = double.Parse(lvi.SubItems[3].Text);
                        check = clothesStoreControl.insertClothes(name, price, quantity, total);
                        if (check == false)
                        {
                            MessageBox.Show("! لقد تمت اضافة هذا الصنف  ('" + name + "')من قبل ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            count++;
                        }
                    }
                    if (count > 0)
                    {
                        MessageBox.Show("!تمت عملية الاضافة بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    ListViewClothesStore.Items.Clear();
                    listCheck.Clear();
                    txtClothTotalStore.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteClothStore_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewClothesStore.Items.Clear();
                txtClothPriceStore.Text = "";
                txtClothQuantityStore.Text = "";
                txtClothTotalStore.Text = "";
                txtClothTypeStore.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeletRowClothStore_Click(object sender, EventArgs e)
        {
            try
            {
                double total = 0;
                clothesStoreControl = new ClothesStoreControl();
                if (ListViewClothesStore.CheckedItems.Count == 0)
                {
                    MessageBox.Show("لم يتم تحديد الملابس المراد حذفها", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    foreach (ListViewItem checkedItem in ListViewClothesStore.CheckedItems)
                    {
                        total += double.Parse(checkedItem.SubItems[3].Text);
                        checkedItem.Remove();
                    }
                    total = clothesStoreControl.totalAll(double.Parse(txtClothTotalStore.Text), -total);
                    txtClothTotalStore.Text = total.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtClothTypeStore_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtClothPriceStore.Focus();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtClothPriceStore_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtClothQuantityStore.Focus();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtClothQuantityStore_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtClothTypeStore.Text == "")
                    {
                        MessageBox.Show("من فضلك ادخل اسم الصنف", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (txtClothPriceStore.Text == "")
                    {
                        MessageBox.Show("من فضلك ادخل سعر الصنف ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (txtClothQuantityStore.Text == "")
                    {
                        MessageBox.Show("من فضلك ادخل كميه الصنف", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        clothesStoreControl = new ClothesStoreControl();
                        double total = clothesStoreControl.total(double.Parse(txtClothPriceStore.Text), double.Parse(txtClothQuantityStore.Text));
                        ListViewItem lvi = new ListViewItem(txtClothTypeStore.Text);
                        lvi.SubItems.Add(txtClothPriceStore.Text);
                        lvi.SubItems.Add(txtClothQuantityStore.Text);
                        lvi.SubItems.Add(total.ToString());


                        if (listCheck.Count == 0 || !listCheck.Contains(lvi.SubItems[0].Text))
                        {
                            ListViewClothesStore.Items.Add(lvi);
                            listCheck.Add(lvi.SubItems[0].Text);

                            if (txtClothTotalStore.Text == "")
                            {
                                total = clothesStoreControl.totalAll(0, total);
                            }
                            else
                            {
                                total = clothesStoreControl.totalAll(double.Parse(txtClothTotalStore.Text), total);
                            }

                            txtClothTotalStore.Text = total.ToString();
                        }
                        else
                        {
                            MessageBox.Show("!لقد تم اضافه هذا النوع من الملابس", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        txtClothPriceStore.Text = "";
                        txtClothQuantityStore.Text = "";
                        txtClothTypeStore.Text = "";
                        txtClothTypeStore.Focus();
                    }
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtClothPriceStore_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtClothQuantityStore_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            
        }

        private void listViewUpdateClothesStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listViewUpdateClothesStore.SelectedItems.Count > 0)
                {
                    ListViewItem lvi = listViewUpdateClothesStore.SelectedItems[0];
                    string name = lvi.SubItems[0].Text;
                    string price = lvi.SubItems[1].Text;
                    string quantity = lvi.SubItems[2].Text;
                    txtUpdateClotheName.Text = name;
                    PreviousUpdateClotheType = name;
                    txtUpdateClothePrice.Text = price;
                    txtUpdateClotheQuantity.Text = quantity;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdateClothesStore_Click(object sender, EventArgs e)
        {
            try
            {
                clothesStoreControl = new ClothesStoreControl();

                if (PreviousUpdateClotheType.Equals(""))
                {
                    MessageBox.Show("من فضلك اختر النوع المراد تعديله", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    if (txtUpdateClotheName.Text == "")
                    {
                        MessageBox.Show("من فضلك ادخل اسم الجهاز المراد تعديلة", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (txtUpdateClothePrice.Text == "")
                    {
                        MessageBox.Show("من فضلك ادخل سعر النوع المراد تعديلة", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (txtUpdateClotheQuantity.Text == "")
                    {
                        MessageBox.Show("من فضلك ادخل كمية النوع المراد تعديلة", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {

                        string name = txtUpdateClotheName.Text;
                        double price = double.Parse(txtUpdateClothePrice.Text);
                        double quantity = double.Parse(txtUpdateClotheQuantity.Text);
                        double total = clothesStoreControl.total(double.Parse(txtUpdateClothePrice.Text), double.Parse(txtUpdateClotheQuantity.Text));

                        if (PreviousUpdateClotheType.Equals(name))
                        {
                            PreviousUpdateClotheType = "NOT CHANAGEE";
                        }
                        Boolean check = clothesStoreControl.UpdateClothe(PreviousUpdateClotheType, name, price, quantity, total);
                        if (check == true)
                        {
                            MessageBox.Show("تمت عملية التعديل بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clothesStoreControl.fillListViewClothesStore(listViewUpdateClothesStore);
                            txtUpdateTotalAllClothesStore.Text = clothesStoreControl.totalAllUpdate(listViewUpdateClothesStore).ToString();
                        }
                        else
                        {
                            MessageBox.Show("!هذا النوع مسجل", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        PreviousUpdateClotheType = "";
                        txtUpdateClotheName.Text = "";
                        txtUpdateClothePrice.Text = "";
                        txtUpdateClotheQuantity.Text = "";
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void اضافةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelNewEmployee.Visible = false;
            panelNewLocation.Visible = false;
            panelLocationCosts.Visible = false;
            PanelNewApplication.Visible = false;
            PanelAddClothe.Visible = true;
            PanelUpdateClotheStore.Visible = false;
            PanelDeleteFromclothesStore.Visible = false;
            PanelAddDevices.Visible = false;
            PanelUpdateDeviceStore.Visible = false;
            PanelDeleteFromDevicesStore.Visible = false;
            panelUpdateLocation.Visible = false;
            panelUpdateLocationCosts.Visible = false;
            panelUpdateEmployee.Visible = false;
            panelSourceEvaluation.Visible = false;
            panelAttendance.Visible = false;
        }

        private void تعديلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                panelNewEmployee.Visible = false;
                panelNewLocation.Visible = false;
                panelLocationCosts.Visible = false;
                PanelNewApplication.Visible = false;
                PanelAddClothe.Visible = false;
                PanelUpdateClotheStore.Visible = true;
                PanelDeleteFromclothesStore.Visible = false;
                PanelUpdateDeviceStore.Visible = false;
                PanelDeleteFromDevicesStore.Visible = false;
                panelUpdateLocation.Visible = false;
                panelUpdateLocationCosts.Visible = false;
                panelUpdateEmployee.Visible = false;
                panelSourceEvaluation.Visible = false;
                panelAttendance.Visible = false;
                clothesStoreControl = new ClothesStoreControl();
                clothesStoreControl.fillListViewClothesStore(listViewUpdateClothesStore);
                txtUpdateTotalAllClothesStore.Text = clothesStoreControl.totalAllUpdate(listViewUpdateClothesStore).ToString();
                PreviousUpdateClotheType = "";
                txtUpdateClotheName.Text = "";
                txtUpdateClothePrice.Text = "";
                txtUpdateClotheQuantity.Text = "";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtUpdateClotheQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtUpdateClothePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtUpdateClotheName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtUpdateClothePrice.Focus();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtUpdateClothePrice_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtUpdateClotheQuantity.Focus();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtUpdateClotheQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtUpdateClotheName.Focus();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listViewDeleteClotheStore_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                panelNewEmployee.Visible = false;
                panelNewLocation.Visible = false;
                panelLocationCosts.Visible = false;
                PanelNewApplication.Visible = false;
                PanelAddClothe.Visible = false;
                PanelUpdateClotheStore.Visible = false;
                PanelDeleteFromclothesStore.Visible = true;
                PanelAddDevices.Visible = false;
                PanelUpdateDeviceStore.Visible = false;
                PanelDeleteFromDevicesStore.Visible = false;
                panelUpdateLocation.Visible = false;
                panelUpdateLocationCosts.Visible = false;
                panelUpdateEmployee.Visible = false;
                panelSourceEvaluation.Visible = false;
                panelAttendance.Visible = false;
                clothesStoreControl = new ClothesStoreControl();
                clothesStoreControl.fillListViewClothesStore(listViewDeleteClotheStore);
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteFromStors_Click(object sender, EventArgs e)
        {
            try
            {
                clothesStoreControl = new ClothesStoreControl();
                if (listViewDeleteClotheStore.CheckedItems.Count == 0)
                {
                    MessageBox.Show("لم يتم تحديد الملابس المراد حزفها", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    foreach (ListViewItem checkedItem in listViewDeleteClotheStore.CheckedItems)
                    {
                        string name = checkedItem.SubItems[0].Text;
                        clothesStoreControl.deleteClothes(name);
                        clothesStoreControl.fillListViewClothesStore(listViewDeleteClotheStore);
                    }
                    MessageBox.Show("تمت عملية الحذف بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clothesStoreControl.fillListViewClothesStore(listViewDeleteClotheStore);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtDeviceQuantityStore_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSaveDeviceStore_Click(object sender, EventArgs e)
        {
            try
            {
                devicesStoreControl = new DevicesStoreControl();
                if (ListViewDeviceStore.Items.Count == 0)
                {
                    MessageBox.Show("!لا يوجد ملابس ليتم اضافتها", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    Boolean check = false;
                    int count = 0;
                    foreach (ListViewItem lvi in ListViewDeviceStore.Items)
                    {
                        string name = lvi.SubItems[0].Text;
                        double price = double.Parse(lvi.SubItems[1].Text);
                        double quantity = double.Parse(lvi.SubItems[2].Text);
                        double total = double.Parse(lvi.SubItems[3].Text);
                        check = devicesStoreControl.insertDevices(name, price, quantity, total);
                        if (check == false)
                        {
                            MessageBox.Show("! لقد تمت اضافة هذا الجهاز  ('" + name + "')من قبل ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            count++;
                        }
                    }
                    if (count > 0)
                    {
                        MessageBox.Show("!تمت عملية الاضافة بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    ListViewDeviceStore.Items.Clear();
                    listCheckDevices.Clear();
                    txtDeviceTotalStore.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteAlItemsDeviceStore_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewDeviceStore.Items.Clear();
                txtDeviceTotalStore.Text = "";
                txtDeviceQuantityStore.Text = "";
                txtDevicePriceStore.Text = "";
                txtDeviceNameStore.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteItemsDeviceStore_Click(object sender, EventArgs e)
        {
            try
            {
                double total = 0;
                devicesStoreControl = new DevicesStoreControl();
                if (ListViewDeviceStore.CheckedItems.Count == 0)
                {
                    MessageBox.Show("لم يتم تحديد الجهاز المراد حذفة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    foreach (ListViewItem checkedItem in ListViewDeviceStore.CheckedItems)
                    {
                        total += double.Parse(checkedItem.SubItems[3].Text);
                        checkedItem.Remove();
                    }
                    total = devicesStoreControl.totalAll(double.Parse(txtDeviceTotalStore.Text), -total);
                    txtDeviceTotalStore.Text = total.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txtDeviceQuantityStore_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtDeviceNameStore.Text == "")
                    {
                        MessageBox.Show("من فضلك ادخل اسم الجهاز", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (txtDevicePriceStore.Text == "")
                    {
                        MessageBox.Show("من فضلك ادخل سعر الجهاز ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (txtDeviceQuantityStore.Text == "")
                    {
                        MessageBox.Show("من فضلك ادخل كميه الجهاز", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        devicesStoreControl = new DevicesStoreControl();
                        double total = devicesStoreControl.total(double.Parse(txtDevicePriceStore.Text), double.Parse(txtDeviceQuantityStore.Text));
                        ListViewItem lvi = new ListViewItem(txtDeviceNameStore.Text);
                        lvi.SubItems.Add(txtDevicePriceStore.Text);
                        lvi.SubItems.Add(txtDeviceQuantityStore.Text);
                        lvi.SubItems.Add(total.ToString());


                        if (listCheckDevices.Count == 0 || !listCheckDevices.Contains(lvi.SubItems[0].Text))
                        {
                            ListViewDeviceStore.Items.Add(lvi);
                            listCheckDevices.Add(lvi.SubItems[0].Text);

                            if (txtDeviceTotalStore.Text == "")
                            {
                                total = devicesStoreControl.totalAll(0, total);
                            }
                            else
                            {
                                total = devicesStoreControl.totalAll(double.Parse(txtDeviceTotalStore.Text), total);
                            }

                            txtDeviceTotalStore.Text = total.ToString();
                        }
                        else
                        {
                            MessageBox.Show("!لقد تم اضافه هذا الجهاز", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        txtDevicePriceStore.Text = "";
                        txtDeviceQuantityStore.Text = "";
                        txtDeviceNameStore.Text = "";
                        txtDeviceNameStore.Focus();

                    }
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtDeviceNameStore_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtDevicePriceStore.Focus();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtDevicePriceStore_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtDeviceQuantityStore.Focus();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtDevicePriceStore_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtDeviceQuantityStore_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
            
        }

        private void اضافةToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            panelNewEmployee.Visible = false;
            panelNewLocation.Visible = false;
            panelLocationCosts.Visible = false;
            PanelNewApplication.Visible = false;
            PanelAddClothe.Visible = false;
            PanelUpdateClotheStore.Visible = false;
            PanelDeleteFromclothesStore.Visible = false;
            PanelAddDevices.Visible = true;
            PanelUpdateDeviceStore.Visible = false;
            PanelDeleteFromDevicesStore.Visible = false;
            panelUpdateLocation.Visible = false;
            panelUpdateLocationCosts.Visible = false;
            panelUpdateEmployee.Visible = false;
            panelSourceEvaluation.Visible = false;
            panelAttendance.Visible = false;
        }

        private void txtUpdateDevicePrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void listViewUpdateDeviceStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listViewUpdateDeviceStore.SelectedItems.Count > 0)
                {
                    ListViewItem lvi = listViewUpdateDeviceStore.SelectedItems[0];
                    string name = lvi.SubItems[0].Text;
                    string price = lvi.SubItems[1].Text;
                    string quantity = lvi.SubItems[2].Text;
                    txtUpdateDeviceName.Text = name;
                    PreviousUpdateDeviceName = name;
                    txtUpdateDevicePrice.Text = price;
                    txtUpdateDeviceQuantity.Text = quantity;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdateDeviceStore_Click(object sender, EventArgs e)
        {
            try
            {
                devicesStoreControl = new DevicesStoreControl();

                if (PreviousUpdateDeviceName.Equals(""))
                {
                    MessageBox.Show("من فضلك اختر الجهاز المراد تعديله", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    if (txtUpdateDeviceName.Text == "")
                    {
                        MessageBox.Show("من فضلك ادخل اسم الجهاز المراد تعديلة", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (txtUpdateDevicePrice.Text == "")
                    {
                        MessageBox.Show("من فضلك ادخل سعر الجهاز المراد تعديلة", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (txtUpdateDeviceQuantity.Text == "")
                    {
                        MessageBox.Show("من فضلك ادخل كمية الجهاز المراد تعديلة", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {

                        string name = txtUpdateDeviceName.Text;
                        double price = double.Parse(txtUpdateDevicePrice.Text);
                        double quantity = double.Parse(txtUpdateDeviceQuantity.Text);
                        double total = devicesStoreControl.total(double.Parse(txtUpdateDevicePrice.Text), double.Parse(txtUpdateDeviceQuantity.Text));

                        if (PreviousUpdateDeviceName.Equals(name))
                        {
                            PreviousUpdateDeviceName = "NOT CHANAGEE";
                        }
                        Boolean check = devicesStoreControl.UpdateDevice(PreviousUpdateDeviceName, name, price, quantity, total);
                        if (check == true)
                        {
                            MessageBox.Show("تمت عملية التعديل بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            devicesStoreControl.fillListViewDevicesStore(listViewUpdateDeviceStore);
                            txtUpdateAllTotalDeviceStore.Text = devicesStoreControl.totalAllUpdate(listViewUpdateDeviceStore).ToString();
                        }
                        else
                        {
                            MessageBox.Show("!هذا الجهاز مسجل", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        PreviousUpdateDeviceName = "";
                        txtUpdateDeviceName.Text = "";
                        txtUpdateDevicePrice.Text = "";
                        txtUpdateDeviceQuantity.Text = "";
                    }

                }
            }
            catch
            {

            }
        }

        private void تعديلToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                panelNewEmployee.Visible = false;
                panelNewLocation.Visible = false;
                panelLocationCosts.Visible = false;
                PanelNewApplication.Visible = false;
                PanelAddClothe.Visible = false;
                PanelUpdateClotheStore.Visible = false;
                PanelDeleteFromclothesStore.Visible = false;
                PanelAddDevices.Visible = false;
                PanelUpdateDeviceStore.Visible = true;
                PanelDeleteFromDevicesStore.Visible = false;
                panelUpdateLocation.Visible = false;
                panelUpdateLocationCosts.Visible = false;
                panelUpdateEmployee.Visible = false;
                panelSourceEvaluation.Visible = false;
                panelAttendance.Visible = false;
                devicesStoreControl = new DevicesStoreControl();
                devicesStoreControl.fillListViewDevicesStore(listViewUpdateDeviceStore);
                txtUpdateAllTotalDeviceStore.Text = devicesStoreControl.totalAllUpdate(listViewUpdateDeviceStore).ToString();
                PreviousUpdateDeviceName = "";
                txtUpdateDeviceName.Text = "";
                txtUpdateDevicePrice.Text = "";
                txtUpdateDeviceQuantity.Text = "";
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

        private void txtUpdateDevicePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtUpdateDeviceQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUpdateDeviceQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
          
        }

        private void txtUpdateDeviceName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtUpdateDevicePrice.Focus();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtUpdateDevicePrice_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtUpdateDeviceQuantity.Focus();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtUpdateDeviceQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtUpdateDeviceName.Focus();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteFromDevicesStore_Click(object sender, EventArgs e)
        {
            try
            {
                devicesStoreControl = new DevicesStoreControl();
                if (listViewDeleteDevicesStoree.CheckedItems.Count == 0)
                {
                    MessageBox.Show("لم يتم تحديد الجهاز المراد حذفة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    foreach (ListViewItem checkedItem in listViewDeleteDevicesStoree.CheckedItems)
                    {
                        string name = checkedItem.SubItems[0].Text;
                        devicesStoreControl.deleteDevices(name);
                    }
                    MessageBox.Show("تمت عملية الحذف بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    devicesStoreControl.fillListViewDevicesStore(listViewDeleteDevicesStoree);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void حذفToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                panelNewEmployee.Visible = false;
                panelNewLocation.Visible = false;
                panelLocationCosts.Visible = false;
                PanelNewApplication.Visible = false;
                PanelAddClothe.Visible = false;
                PanelUpdateClotheStore.Visible = false;
                PanelDeleteFromclothesStore.Visible = false;
                PanelAddDevices.Visible = false;
                PanelUpdateDeviceStore.Visible = false;
                PanelDeleteFromDevicesStore.Visible = true;
                devicesStoreControl = new DevicesStoreControl();
                devicesStoreControl.fillListViewDevicesStore(listViewDeleteDevicesStoree);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void اضافةبياناتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelNewEmployee.Visible = false;
            panelNewLocation.Visible = true;
            panelLocationCosts.Visible = false;
            PanelNewApplication.Visible = false;
            PanelUpdateClotheStore.Visible = false;
            PanelAddClothe.Visible = false;
            PanelDeleteFromclothesStore.Visible = false;
            PanelAddDevices.Visible = false;
            PanelUpdateDeviceStore.Visible = false;
            PanelDeleteFromDevicesStore.Visible = false;
            panelUpdateLocation.Visible = false;
            panelUpdateLocationCosts.Visible = false;
            panelUpdateEmployee.Visible = false;
            panelSourceEvaluation.Visible = false;
            panelAttendance.Visible = false;
        }

        private void تعديلToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            panelNewEmployee.Visible = false;
            panelNewLocation.Visible = false;
            panelLocationCosts.Visible = false;
            PanelNewApplication.Visible = false;
            PanelUpdateClotheStore.Visible = false;
            PanelAddClothe.Visible = false;
            PanelDeleteFromclothesStore.Visible = false;
            PanelAddDevices.Visible = false;
            PanelUpdateDeviceStore.Visible = false;
            PanelDeleteFromDevicesStore.Visible = false;
            panelUpdateLocation.Visible = true;
            panelUpdateEmployee.Visible = false;
            panelSourceEvaluation.Visible = false;
            panelAttendance.Visible = false;
            locationControl = new LocationControl();
            locationControl.fillComboboxLocationName(comboBoxUpdateLocationName);
        }

        private void اضافةتكاليفموقعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                panelNewEmployee.Visible = false;
                panelNewLocation.Visible = false;
                panelLocationCosts.Visible = true;
                PanelNewApplication.Visible = false;
                PanelAddClothe.Visible = false;
                PanelUpdateClotheStore.Visible = false;
                PanelDeleteFromclothesStore.Visible = false;
                PanelAddDevices.Visible = false;
                PanelUpdateDeviceStore.Visible = false;
                PanelDeleteFromDevicesStore.Visible = false;
                panelUpdateLocation.Visible = false;
                panelUpdateLocationCosts.Visible = false;
                panelUpdateEmployee.Visible = false;
                panelSourceEvaluation.Visible = false;
                panelAttendance.Visible = false;
                locationControl = new LocationControl();
                clothesStoreControl = new ClothesStoreControl();
                devicesStoreControl = new DevicesStoreControl();
                locationControl.fillComboboxLocationName(comboBoxLocationName);
                clothesStoreControl.fillComboboxClothesName(comboBoxCostClothesName);
                devicesStoreControl.fillComboboxDevicesName(comboBoxCostDevicesName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void تعديلتكاليفموقعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                panelNewEmployee.Visible = false;
                panelNewLocation.Visible = false;
                panelLocationCosts.Visible = false;
                PanelNewApplication.Visible = false;
                PanelAddClothe.Visible = false;
                PanelUpdateClotheStore.Visible = false;
                PanelDeleteFromclothesStore.Visible = false;
                PanelAddDevices.Visible = false;
                PanelUpdateDeviceStore.Visible = false;
                PanelDeleteFromDevicesStore.Visible = false;
                panelUpdateLocation.Visible = false;
                panelUpdateLocationCosts.Visible = true;
                panelUpdateEmployee.Visible = false;
                panelSourceEvaluation.Visible = false;
                panelAttendance.Visible = false;
                locationControl = new LocationControl();
                devicesStoreControl = new DevicesStoreControl();
                clothesStoreControl = new ClothesStoreControl();
                locationControl.fillComboboxLocationName(comboBoxUpdateCostLocationName);
                clothesStoreControl.fillComboboxClothesName(comboBoxUpdateCostClothesName);
                devicesStoreControl.fillComboboxDevicesName(comboBoxUpdateCostDevicesName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxUpdateLocationName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                locationControl = new LocationControl();
                string locationName = comboBoxUpdateLocationName.Text;
                string locationAddress = locationControl.getLocationAddress(locationName);
                string startDate = locationControl.getStartDate(locationName);
                string endDate = locationControl.getEndDate(locationName);
                string securityNumbers = locationControl.getLocationSecurityNumbers(locationName).ToString();
                string supervisorNumbers = locationControl.getLocationSupervisorNumbers(locationName).ToString();
                string managerNumbers = locationControl.getLocationManagerNumbers(locationName).ToString();
                string workHours = locationControl.getLocationWorkHours(locationName).ToString();
                txtUpdateLocationName.Text = locationName;
                txtUpdateLocationAddress.Text = locationAddress;
                dtpUpdateStartDate.Value = Convert.ToDateTime(startDate);
                dtpUpdateEndDate.Value = Convert.ToDateTime(endDate);
                txtUpdateSecurityNumbers.Text = securityNumbers;
                txtUpdateSupervisorNumbers.Text = supervisorNumbers;
                txtUpdateManagerNumbers.Text = managerNumbers;
                comboBoxUpdateWorkHours.Text = workHours;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdateLocation_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUpdateLocationName.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل اسم الموقع", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtUpdateLocationAddress.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل العنوان", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtUpdateSecurityNumbers.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل عدد فرد امن", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtUpdateSupervisorNumbers.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل عدد مشرف موقع", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtUpdateManagerNumbers.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل عدد مدير موقع", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (comboBoxUpdateWorkHours.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل عدد ساعات العمل ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    locationControl = new LocationControl();
                    string previousLoctionName = comboBoxUpdateLocationName.Text;
                    string name = txtUpdateLocationName.Text;
                    string address = txtUpdateLocationAddress.Text;
                    DateTime startDate = dtpUpdateStartDate.Value;
                    string startDateSQL = startDate.ToString("yyyy-MM-dd");
                    DateTime endDate = dtpUpdateEndDate.Value;
                    string endDateSQL = endDate.ToString("yyyy-MM-dd");
                    int securityNumbers = int.Parse(txtUpdateSecurityNumbers.Text);
                    int supervisourNumbers = int.Parse(txtUpdateSupervisorNumbers.Text);
                    int managerNumbers = int.Parse(txtUpdateManagerNumbers.Text);
                    int workHours = int.Parse(comboBoxUpdateWorkHours.Text);
                    locationControl.updateLocation(previousLoctionName, name, address, startDateSQL, endDateSQL, securityNumbers, supervisourNumbers, managerNumbers, workHours);
                    MessageBox.Show("تم تعديل بيانات الموقع بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxUpdateCostLocationName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                locationControl = new LocationControl();
                locationClothesContentControl = new LocationClothesContentControl();
                locationEquipsContentControl = new LocationEquipsContentControl();
                locationClothesControl = new LocationClothesControl();
                locationEquipsConrol = new LocationEquipsConrol();
                string locationName = comboBoxUpdateCostLocationName.Text;
                int securityNumbers = locationControl.getLocationSecurityNumbers(locationName);
                int supervisorNumbers = locationControl.getLocationSupervisorNumbers(locationName);
                int managerNumbers = locationControl.getLocationManagerNumbers(locationName);
                double securityCost = locationControl.getSecuritySalary(locationName);
                double supervisorCost = locationControl.getSupervisorSalary(locationName);
                double managerCost = locationControl.getManagerSalary(locationName);
                double totalSecurity = securityNumbers * securityCost;
                double totalSupervisour = supervisorNumbers * supervisorCost;
                double totalManager = managerNumbers * managerCost;
                double totalClothes = locationClothesControl.getTotal(locationName);
                double totalDevices = locationEquipsConrol.getTotal(locationName);

                txtUpdateCostSecurityNumbers.Text = securityNumbers.ToString();
                txtUpdateCostSupervisorNumbers.Text = supervisorNumbers.ToString();
                txtUpdateCostManagerNumbers.Text = managerNumbers.ToString();
                txtUpdateCostSecurityCost.Text = securityCost.ToString();
                txtUpdateCostSupervisorCost.Text = supervisorCost.ToString();
                txtUpdateCostManagerCost.Text = managerCost.ToString();
                txtUpdateCostTotalSecurity.Text = totalSecurity.ToString();
                txtUpdateCostTotalSupervisor.Text = totalSupervisour.ToString();
                txtUpdateCostTotalManager.Text = totalManager.ToString();
                locationClothesContentControl.fillListView(listViewUpdateCostClothes, locationName);
                locationEquipsContentControl.fillListView(listViewUpdateCostDevices, locationName);
                txtUpdateCostTotalClothes.Text = totalClothes.ToString();
                txtUpdateCostTotalDevices.Text = totalDevices.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdateLocationCost_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxUpdateCostLocationName.Text == "")
                {
                    MessageBox.Show("من فضلك اختر اسم الموقع", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtUpdateCostSecurityCost.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل تكلفة موظف الأمن", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtUpdateCostSupervisorCost.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل تكلفة مشرف الأمن", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtUpdateCostManagerCost.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل تكلفة مدير الموقع", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    locationControl = new LocationControl();
                    locationClothesControl = new LocationClothesControl();
                    locationClothesContentControl = new LocationClothesContentControl();
                    locationEquipsConrol = new LocationEquipsConrol();
                    locationEquipsContentControl = new LocationEquipsContentControl();
                    string locationName = comboBoxUpdateCostLocationName.Text;
                    double securitySalary = double.Parse(txtUpdateCostSecurityCost.Text);
                    double supervisorSalary = double.Parse(txtUpdateCostSupervisorCost.Text);
                    double managerSalary = double.Parse(txtUpdateCostManagerCost.Text);
                    double totalClothes = double.Parse(txtUpdateCostTotalClothes.Text);
                    double totalDevices = double.Parse(txtUpdateCostTotalDevices.Text);

                    locationControl.updateLocationCost(locationName, securitySalary, supervisorSalary, managerSalary);
                    locationClothesControl.update(totalClothes, locationName);
                    locationClothesContentControl.updateInsert(locationName, listViewUpdateCostClothes);
                    locationClothesContentControl.deletedClothesItems(deletedClothes, locationName);
                    locationEquipsConrol.update(totalDevices, locationName);
                    locationEquipsContentControl.updateInsert(locationName, listViewUpdateCostDevices);
                    locationEquipsContentControl.deletedDevicesItems(deletedDevices, locationName);
                    deletedDevices.Clear();
                    deletedClothes.Clear();
                    MessageBox.Show("تم تعديل بيانات التكلفة بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxUpdateCostClothesName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                clothesStoreControl = new ClothesStoreControl();
                txtUpdateCostClothesPrice.Text = clothesStoreControl.getClothePrice(comboBoxUpdateCostClothesName.Text).ToString();
                txtUpdateCostClothesQuantity.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxUpdateCostDevicesName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                devicesStoreControl = new DevicesStoreControl();
                txtUpdateCostDevicePrice.Text = devicesStoreControl.getDevicePrice(comboBoxUpdateCostDevicesName.Text).ToString();
                txtUpdateCostDeviceQuantity.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtUpdateCostClothesQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    if (txtUpdateCostClothesQuantity.Text == "")
                    {
                        MessageBox.Show("من فضلك ادخل الكمية", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (comboBoxUpdateCostClothesName.Text == "")
                    {
                        MessageBox.Show("من فضلك اختر اسم القطعة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        clothesStoreControl = new ClothesStoreControl();
                        locationClothesControl = new LocationClothesControl();
                        string name = comboBoxUpdateCostClothesName.Text;
                        string price = txtUpdateCostClothesPrice.Text;
                        string quantity = txtUpdateCostClothesQuantity.Text;
                        string total = clothesStoreControl.total(double.Parse(price), double.Parse(quantity)).ToString();
                        bool flag = clothesStoreControl.checkItemExistInListView(listViewUpdateCostClothes, name);
                        double totalAll = double.Parse(txtUpdateCostTotalClothes.Text);
                        if (flag == true)
                        {
                            MessageBox.Show("هذه القطعة تم اضافتها للفاتورة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (flag == false)
                        {
                            ListViewItem lvi = new ListViewItem(name);
                            lvi.SubItems.Add(price);
                            lvi.SubItems.Add(quantity);
                            lvi.SubItems.Add(total);
                            listViewUpdateCostClothes.Items.Add(lvi);
                            double totalClothes = locationClothesControl.updateListViewTotal(listViewUpdateCostClothes);
                            txtUpdateCostTotalClothes.Text = totalClothes.ToString();
                            if (deletedClothes.Contains(name))
                            {
                                deletedClothes.Remove(name);
                            }
                        }
                    }
                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtUpdateCostDeviceQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                    if (txtUpdateCostDeviceQuantity.Text == "")
                    {
                        MessageBox.Show("من فضلك ادخل الكمية", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (comboBoxUpdateCostDevicesName.Text == "")
                    {
                        MessageBox.Show("من فضلك اختر اسم الجهاز", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        devicesStoreControl = new DevicesStoreControl();
                        locationEquipsConrol = new LocationEquipsConrol();
                        string name = comboBoxUpdateCostDevicesName.Text;
                        string price = txtUpdateCostDevicePrice.Text;
                        string quantity = txtUpdateCostDeviceQuantity.Text;
                        string total = devicesStoreControl.total(double.Parse(price), double.Parse(quantity)).ToString();
                        bool flag = devicesStoreControl.checkItemExistInListView(listViewUpdateCostDevices, name);
                        double totalAll = double.Parse(txtUpdateCostTotalDevices.Text);
                        if (flag == true)
                        {
                            MessageBox.Show("هذه الجهاز تم اضافته للفاتورة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (flag == false)
                        {
                            ListViewItem lvi = new ListViewItem(name);
                            lvi.SubItems.Add(price);
                            lvi.SubItems.Add(quantity);
                            lvi.SubItems.Add(total);
                            listViewUpdateCostDevices.Items.Add(lvi);
                            double totalDevices = locationEquipsConrol.updateListViewTotal(listViewUpdateCostDevices);
                            txtUpdateCostTotalDevices.Text = totalDevices.ToString();
                            if (deletedDevices.Contains(name))
                            {
                                deletedDevices.Remove(name);
                            }
                        }
                    }
                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdateCostUpdateClothes_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxUpdateCostClothesName.Text == "")
                {
                    MessageBox.Show("من فضلك اختر اسم القطعة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (txtUpdateCostClothesQuantity.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل الكمية", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    locationClothesControl = new LocationClothesControl();
                    foreach (ListViewItem item in listViewUpdateCostClothes.Items)
                    {
                        if (item.SubItems[0].Text == comboBoxUpdateCostClothesName.Text)
                        {
                            double price = double.Parse(item.SubItems[1].Text);
                            double quantity = double.Parse(txtUpdateCostClothesQuantity.Text);
                            double total = price * quantity;
                            item.SubItems[2].Text = txtUpdateCostClothesQuantity.Text;
                            item.SubItems[3].Text = total.ToString();
                        }
                    }
                    double totalClothes = locationClothesControl.updateListViewTotal(listViewUpdateCostClothes);
                    txtUpdateCostTotalClothes.Text = totalClothes.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdateCostUpdateDevices_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxUpdateCostDevicesName.Text == "")
                {
                    MessageBox.Show("من فضلك اختر اسم الجهاز", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (txtUpdateCostDeviceQuantity.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل الكمية", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    locationEquipsConrol = new LocationEquipsConrol();
                    foreach (ListViewItem item in listViewUpdateCostDevices.Items)
                    {
                        if (item.SubItems[0].Text == comboBoxUpdateCostDevicesName.Text)
                        {
                            double price = double.Parse(item.SubItems[1].Text);
                            double quantity = double.Parse(txtUpdateCostDeviceQuantity.Text);
                            double total = price * quantity;
                            item.SubItems[2].Text = txtUpdateCostDeviceQuantity.Text;
                            item.SubItems[3].Text = total.ToString();
                        }
                    }
                    double totalDevices = locationEquipsConrol.updateListViewTotal(listViewUpdateCostDevices);
                    txtUpdateCostTotalDevices.Text = totalDevices.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdateCostDeleteClothes_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewUpdateCostClothes.CheckedItems.Count == 0)
                {
                }
                else
                {
                    locationClothesControl = new LocationClothesControl();
                    deletedClothes = new HashSet<string>();
                    foreach (ListViewItem item in listViewUpdateCostClothes.CheckedItems)
                    {
                        string name = item.SubItems[0].Text;
                        deletedClothes.Add(name);
                        item.Remove();
                    }
                    double total = locationClothesControl.updateListViewTotal(listViewUpdateCostClothes);
                    txtUpdateCostTotalClothes.Text = total.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdateCostDeleteDevice_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewUpdateCostDevices.CheckedItems.Count == 0)
                {
                }
                else
                {
                    deletedDevices = new HashSet<string>();
                    locationEquipsConrol = new LocationEquipsConrol();
                    foreach (ListViewItem item in listViewUpdateCostDevices.CheckedItems)
                    {
                        string name = item.SubItems[0].Text;
                        deletedDevices.Add(name);
                        item.Remove();
                    }
                    double total = locationEquipsConrol.updateListViewTotal(listViewUpdateCostDevices);
                    txtUpdateCostTotalDevices.Text = total.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listViewUpdateCostClothes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listViewUpdateCostClothes.SelectedItems.Count > 0)
                {
                    ListViewItem lvi = listViewUpdateCostClothes.SelectedItems[0];
                    comboBoxUpdateCostClothesName.Text = lvi.SubItems[0].Text;
                    txtUpdateCostClothesPrice.Text = lvi.SubItems[1].Text;
                    txtUpdateCostClothesQuantity.Text = lvi.SubItems[2].Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listViewUpdateCostDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listViewUpdateCostDevices.SelectedItems.Count > 0)
                {
                    ListViewItem lvi = listViewUpdateCostDevices.SelectedItems[0];
                    comboBoxUpdateCostDevicesName.Text = lvi.SubItems[0].Text;
                    txtUpdateCostDevicePrice.Text = lvi.SubItems[1].Text;
                    txtUpdateCostDeviceQuantity.Text = lvi.SubItems[2].Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtUpdateCostSecurityCost_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtUpdateCostSecurityCost.Text == "")
                {
                    txtUpdateCostTotalSecurity.Text = "0";
                }
                else
                {
                    txtUpdateCostTotalSecurity.Text = (int.Parse(txtUpdateCostSecurityNumbers.Text) * int.Parse(txtUpdateCostSecurityCost.Text)).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtUpdateCostSupervisorCost_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtUpdateCostSupervisorCost.Text == "")
                {
                    txtUpdateCostTotalSupervisor.Text = "0";
                }
                else
                {
                    txtUpdateCostTotalSupervisor.Text = (int.Parse(txtUpdateCostSupervisorNumbers.Text) * int.Parse(txtUpdateCostSupervisorCost.Text)).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtUpdateCostManagerCost_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtUpdateCostManagerCost.Text == "")
                {
                    txtUpdateCostTotalManager.Text = "0";
                }
                else
                {
                    txtUpdateCostTotalManager.Text = (int.Parse(txtUpdateCostManagerNumbers.Text) * int.Parse(txtUpdateCostManagerCost.Text)).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void تعديلبياناتموظفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                panelNewEmployee.Visible = false;
                panelNewLocation.Visible = false;
                panelLocationCosts.Visible = false;
                PanelNewApplication.Visible = false;
                PanelUpdateClotheStore.Visible = false;
                PanelAddClothe.Visible = false;
                PanelDeleteFromclothesStore.Visible = false;
                PanelAddDevices.Visible = false;
                PanelUpdateDeviceStore.Visible = false;
                PanelDeleteFromDevicesStore.Visible = false;
                panelUpdateLocation.Visible = false;
                panelUpdateLocationCosts.Visible = false;
                panelUpdateEmployee.Visible = true;
                panelSourceEvaluation.Visible = false;
                panelAttendance.Visible = false;
                sourceControl = new SourceControl();
                locationControl = new LocationControl();
                locationControl.fillComboboxLocationNameReady(ComboBoxUpdateEmployeeLocation);
                sourceControl.fillComboboxSourceName(comboBoxUpdateEmployeeSource);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message)
;
            }
        }

        private void txtUpdateEmployeeCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    employeeControl = new EmployeeControl();
                    int ID = int.Parse(txtUpdateEmployeeCode.Text);
                    string employeeName = employeeControl.getEmployeeName(ID);
                    string salary = employeeControl.getSalary(ID).ToString();
                    string position = employeeControl.getPosition(ID);
                    string nationalID = employeeControl.getNationalID(ID);
                    string location = employeeControl.getLocationName(ID);
                    string source = employeeControl.getSourceName(ID);
                    string employDate = employeeControl.getEmployDate(ID);

                    txtUpdateEmployeeName.Text = employeeName;
                    txtUpdateEmployeeSalary.Text = salary;
                    comboBoxUpdateEmployeeSource.Text = source;
                    ComboBoxUpdateEmployeeLocation.Text = location;
                    txtUpdateEmployeeNationalID.Text = nationalID;
                    dtpUpdateEmployeeDate.Value = Convert.ToDateTime(employDate);
                    comboboxUpdateEmployeePosition.Text = position;
                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboboxUpdateEmployeePosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ComboBoxUpdateEmployeeLocation.Text == "")
                {
                    MessageBox.Show("من فضلك اختر اسم الموقع اولاً", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboboxUpdateEmployeePosition.Items.Clear();
                    comboboxUpdateEmployeePosition.Items.Add("موظف امن");
                    comboboxUpdateEmployeePosition.Items.Add("مشرف امن");
                    comboboxUpdateEmployeePosition.Items.Add("مدير موقع");
                }
                else
                {
                    locationControl = new LocationControl();
                    employeeControl = new EmployeeControl();
                    string locationName = ComboBoxUpdateEmployeeLocation.Text;
                    if (comboboxUpdateEmployeePosition.Text == "موظف امن")
                    {
                        string securitySalary = locationControl.getSecuritySalary(locationName).ToString();
                        txtUpdateEmployeeSalary.Text = securitySalary;
                        txtUpdateEmployeeAvailableNumbers.Text = employeeControl.availableSecurityInLocation(locationName).ToString();
                    }
                    else if (comboboxUpdateEmployeePosition.Text == "مشرف امن")
                    {
                        string supervisorSalary = locationControl.getSupervisorSalary(locationName).ToString();
                        txtUpdateEmployeeSalary.Text = supervisorSalary;
                        txtUpdateEmployeeAvailableNumbers.Text = employeeControl.availableSupervisorInLocation(locationName).ToString();
                    }
                    else if (comboboxUpdateEmployeePosition.Text == "مدير موقع")
                    {
                        string managerSalary = locationControl.getManagerSalary(locationName).ToString(); ;
                        txtUpdateEmployeeSalary.Text = managerSalary;
                        txtUpdateEmployeeAvailableNumbers.Text = employeeControl.availableManagerInLocation(locationName).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ComboBoxUpdateEmployeeLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboboxUpdateEmployeePosition.Items.Clear();
            comboboxUpdateEmployeePosition.Items.Add("موظف امن");
            comboboxUpdateEmployeePosition.Items.Add("مشرف امن");
            comboboxUpdateEmployeePosition.Items.Add("مدير موقع");
            txtUpdateEmployeeSalary.Text = "";
            txtUpdateEmployeeAvailableNumbers.Text = "";
        }

        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUpdateEmployeeNationalID.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل الرقم القومي", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtUpdateEmployeeName.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل اسم الموظف", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ComboBoxUpdateEmployeeLocation.Text == "")
                {
                    MessageBox.Show("من فضلك اختر اسم الموقع", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (comboboxUpdateEmployeePosition.Text == "")
                {
                    MessageBox.Show("من فضلك اختر الوظيفة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtUpdateEmployeeSalary.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل المرتب", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (comboBoxUpdateEmployeeSource.Text == "")
                {
                    MessageBox.Show("من فضلك  اختر المصدر", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult result = MessageBox.Show("هل قمت بمراجعة البيانات؟", "سؤال", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        MessageBox.Show("من فضلك قم بمراجعة البيانات", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (result == DialogResult.Yes)
                    {
                        employeeControl = new EmployeeControl();
                        string nationalID = txtUpdateEmployeeNationalID.Text;
                        string name = txtUpdateEmployeeName.Text;
                        string location = ComboBoxUpdateEmployeeLocation.Text;
                        string position = comboboxUpdateEmployeePosition.Text;
                        double salary = double.Parse(txtUpdateEmployeeSalary.Text);
                        int ID = int.Parse(txtUpdateEmployeeCode.Text);
                        string source = comboBoxUpdateEmployeeSource.Text;
                        DateTime employDate = dtpUpdateEmployeeDate.Value;
                        string employDateSQL = employDate.ToString("yyyy-MM-dd");
                        employeeControl.update(nationalID, name, employDateSQL, position, salary, location, source, ID);
                        MessageBox.Show("تم تعديل البيانات" + Environment.NewLine + "اسم الموظف: " + name + Environment.NewLine + "الكود: " + ID + Environment.NewLine + "الموقع: " + location, "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void تقييمToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                panelNewEmployee.Visible = false;
                panelNewLocation.Visible = false;
                panelLocationCosts.Visible = false;
                PanelNewApplication.Visible = false;
                PanelUpdateClotheStore.Visible = false;
                PanelAddClothe.Visible = false;
                PanelDeleteFromclothesStore.Visible = false;
                PanelAddDevices.Visible = false;
                PanelUpdateDeviceStore.Visible = false;
                PanelDeleteFromDevicesStore.Visible = false;
                panelUpdateLocation.Visible = false;
                panelUpdateLocationCosts.Visible = false;
                panelUpdateEmployee.Visible = false;
                panelSourceEvaluation.Visible = true;
                sourceControl = new SourceControl();
                sourceControl.fillComboboxSourceName(comboBoxEvaluateSourceName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxEvaluateSourceName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                sourceControl = new SourceControl();
                employeeControl = new EmployeeControl();
                string sourceName = comboBoxEvaluateSourceName.Text;
                DateTime dateFrom = dtpEvaluateFrom.Value;
                string dateFromSQL = dateFrom.ToString("yyyy-MM-dd");
                DateTime dateTo = dtpEvaluateTo.Value;
                string dateToSQL = dateTo.ToString("yyyy-MM-dd");
                int count = employeeControl.countEmployeeNumbersRelatedToSource(sourceName, dateFromSQL, dateToSQL);
                txtEvaluateNumbers.Text = count.ToString();
                employeeControl.fillListViewForEvaluation(listViewEvaluate, sourceName, dateFromSQL, dateToSQL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtpEvaluateFrom_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxEvaluateSourceName.Text == "")
                {
                    MessageBox.Show("من فضلك اختر اسم المكتب", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    sourceControl = new SourceControl();
                    employeeControl = new EmployeeControl();
                    string sourceName = comboBoxEvaluateSourceName.Text;
                    DateTime dateFrom = dtpEvaluateFrom.Value;
                    string dateFromSQL = dateFrom.ToString("yyyy-MM-dd");
                    DateTime dateTo = dtpEvaluateTo.Value;
                    string dateToSQL = dateTo.ToString("yyyy-MM-dd");
                    int count = employeeControl.countEmployeeNumbersRelatedToSource(sourceName, dateFromSQL, dateToSQL);
                    txtEvaluateNumbers.Text = count.ToString();
                    employeeControl.fillListViewForEvaluation(listViewEvaluate, sourceName, dateFromSQL, dateToSQL);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtpEvaluateTo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxEvaluateSourceName.Text == "")
                {
                    MessageBox.Show("من فضلك اختر اسم المكتب", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    sourceControl = new SourceControl();
                    employeeControl = new EmployeeControl();
                    string sourceName = comboBoxEvaluateSourceName.Text;
                    DateTime dateFrom = dtpEvaluateFrom.Value;
                    string dateFromSQL = dateFrom.ToString("yyyy-MM-dd");
                    DateTime dateTo = dtpEvaluateTo.Value;
                    string dateToSQL = dateTo.ToString("yyyy-MM-dd");
                    int count = employeeControl.countEmployeeNumbersRelatedToSource(sourceName, dateFromSQL, dateToSQL);
                    txtEvaluateNumbers.Text = count.ToString();
                    employeeControl.fillListViewForEvaluation(listViewEvaluate, sourceName, dateFromSQL, dateToSQL);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void حضوروانصرافToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                panelNewEmployee.Visible = false;
                panelNewLocation.Visible = false;
                panelLocationCosts.Visible = false;
                PanelNewApplication.Visible = false;
                PanelUpdateClotheStore.Visible = false;
                PanelAddClothe.Visible = false;
                PanelDeleteFromclothesStore.Visible = false;
                PanelAddDevices.Visible = false;
                PanelUpdateDeviceStore.Visible = false;
                PanelDeleteFromDevicesStore.Visible = false;
                panelUpdateLocation.Visible = false;
                panelUpdateLocationCosts.Visible = false;
                panelUpdateEmployee.Visible = false;
                panelSourceEvaluation.Visible = false;
                panelAttendance.Visible = true;
                locationControl = new LocationControl();
                locationControl.fillComboboxLocationNameReady(comboBoxAttendanceLocationName);
                domainUpDownAttendanceMonth.Text = DateTime.Now.Month.ToString();
                domainUpDownAttendanceYear.Text = DateTime.Now.Year.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxAttendanceLocationName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                attendanceControl = new AttendanceControl();
                string locationName = comboBoxAttendanceLocationName.Text;
                int month = int.Parse(domainUpDownAttendanceMonth.Text);
                int year = int.Parse(domainUpDownAttendanceYear.Text);
                bool flag = attendanceControl.checkIfLocationAttendanceSubmitted(month, year, locationName);
                if (flag == false && DateTime.Now.Month == int.Parse(domainUpDownAttendanceMonth.Text) && DateTime.Now.Year == int.Parse(domainUpDownAttendanceYear.Text))
                {
                    attendanceControl.insert(month, year, locationName);
                }
                else
                {
                    
                }

                attendanceControl.fillDataGridViewLocationAttendance(dataGridViewAttendance, locationName, month, year);
                dataGridViewAttendance.Columns[0].HeaderText = "الكود";
                dataGridViewAttendance.Columns[0].Width = 50;
                dataGridViewAttendance.Columns[1].HeaderText = "الأسم";
                dataGridViewAttendance.Columns[1].Width = 177;
                for (int i = 2; i < 33; i++)
                {
                    dataGridViewAttendance.Columns[i].HeaderText = (i - 1).ToString(); ;
                    dataGridViewAttendance.Columns[i].Width = 22;
                }
                //disable autogenerating new rows automatically
                dataGridViewAttendance.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveAttendance_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxAttendanceLocationName.Text == "")
                {
                    MessageBox.Show("من فضلك اختر اسم الموقع", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //attendanceControl = new AttendanceControl();
                    attendanceContentControl = new AttendanceContentControl();
                    int month = int.Parse(domainUpDownAttendanceMonth.Text);
                    int year = int.Parse(domainUpDownAttendanceYear.Text);
                    string locationName = comboBoxAttendanceLocationName.Text;
                    attendanceContentControl.insertUpdate(month, year, locationName, dataGridViewAttendance);
                    MessageBox.Show("تم تسجيل غياب و حضور الموقع", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewAttendance_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string value = dataGridViewAttendance.SelectedCells[0].Value.ToString().ToUpper();
            dataGridViewAttendance.SelectedCells[0].Value = value;
            if (value.Length == 1)
            {
                List<string> c = getCompinations(1);
                if (c.Contains(value))
                {
                }
                else
                {
                    MessageBox.Show("خطأ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridViewAttendance.SelectedCells[0].Value = "";
                }
            }
            else if (value.Length == 2)
            {
                List<string> c = getCompinations(2);
                if (c.Contains(value))
                {
                }
                else
                {
                    MessageBox.Show("خطأ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridViewAttendance.SelectedCells[0].Value = "";
                }
            }
            else if (value.Length == 3)
            {
                List<string> c = getCompinations(3);
                if (c.Contains(value))
                {
                }
                else
                {
                    MessageBox.Show("خطأ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridViewAttendance.SelectedCells[0].Value = "";
                }
            }
            else
            {
                MessageBox.Show("خطأ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridViewAttendance.SelectedCells[0].Value = "";
            }
        }

        private void comboBoxCostClothesName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                clothesStoreControl = new ClothesStoreControl();
                txtCostClothePrice.Text = clothesStoreControl.getClothePrice(comboBoxCostClothesName.Text).ToString();
                txtCostClotheQuantity.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBoxCostDevicesName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                devicesStoreControl = new DevicesStoreControl();
                txtCostDevicePrice.Text = (devicesStoreControl.getDevicePrice(comboBoxCostDevicesName.Text)).ToString();
                txtCostDeviceQuantity.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCostClotheQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtCostClotheQuantity.Text == "")
                    {
                        MessageBox.Show("من فضلك ادخل الكمية", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (comboBoxCostClothesName.Text == "")
                    {
                        MessageBox.Show("من فضلك اختر اسم القطعة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        clothesStoreControl = new ClothesStoreControl();
                        string name = comboBoxCostClothesName.Text;
                        string price = txtCostClothePrice.Text;
                        string quantity = txtCostClotheQuantity.Text;
                        string total = clothesStoreControl.total(double.Parse(price), double.Parse(quantity)).ToString();
                        bool flag = clothesStoreControl.checkItemExistInListView(listViewCostClothes, name);
                        double totalAll = double.Parse(txtCostTotalClothes.Text);
                        if (flag == true)
                        {
                            MessageBox.Show("هذه القطعة تم اضافتها للفاتورة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (flag == false)
                        {
                            ListViewItem lvi = new ListViewItem(name);
                            lvi.SubItems.Add(price);
                            lvi.SubItems.Add(quantity);
                            lvi.SubItems.Add(total);
                            listViewCostClothes.Items.Add(lvi);
                            txtCostTotalClothes.Text = clothesStoreControl.totalAll(double.Parse(total), totalAll).ToString();
                        }
                    }
                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCostDeviceQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtCostDeviceQuantity.Text == "")
                    {
                        MessageBox.Show("من فضلك ادخل الكمية", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (comboBoxCostDevicesName.Text == "")
                    {
                        MessageBox.Show("من فضلك اختر اسم الجهاز", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        devicesStoreControl = new DevicesStoreControl();
                        string name = comboBoxCostDevicesName.Text;
                        string price = txtCostDevicePrice.Text;
                        string quantity = txtCostDeviceQuantity.Text;
                        string total = devicesStoreControl.total(double.Parse(price), double.Parse(quantity)).ToString();
                        bool flag = devicesStoreControl.checkItemExistInListView(listViewCostDevices, name);
                        double totalAll = double.Parse(txtCostTotalDevices.Text);
                        if (flag == true)
                        {
                            MessageBox.Show("هذه القطعة تم اضافتها للفاتورة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (flag == false)
                        {
                            ListViewItem lvi = new ListViewItem(name);
                            lvi.SubItems.Add(price);
                            lvi.SubItems.Add(quantity);
                            lvi.SubItems.Add(total);
                            listViewCostDevices.Items.Add(lvi);
                            txtCostTotalDevices.Text = devicesStoreControl.totalAll(double.Parse(total), totalAll).ToString();
                        }
                    }
                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCostDeleteClothesItem_Click(object sender, EventArgs e)
        {
            try
            {
                clothesStoreControl = new ClothesStoreControl();
                txtCostTotalClothes.Text = (clothesStoreControl.deleteListViewItem(listViewCostClothes, double.Parse(txtCostTotalClothes.Text))).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCostDeleteDevicesItem_Click(object sender, EventArgs e)
        {
            try
            {
                devicesStoreControl = new DevicesStoreControl();
                txtCostTotalDevices.Text = (devicesStoreControl.deleteListViewItem(listViewCostDevices, double.Parse(txtCostTotalDevices.Text))).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveLocationCosts_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxLocationName.Text == "")
                {
                    MessageBox.Show("من فضلك اختر الموقع", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtCostSecuritySalary.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل راتب موظف الأمن", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtCostSupervisorSalary.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل راتب مشرف الأمن", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txtCostManagerSalary.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل راتب مدير الأمن", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    locationControl = new LocationControl();
                    locationClothesControl = new LocationClothesControl();
                    locationClothesContentControl = new LocationClothesContentControl();
                    locationEquipsConrol = new LocationEquipsConrol();
                    locationEquipsContentControl = new LocationEquipsContentControl();
                    string locationName = comboBoxLocationName.Text;
                    double securitySalary = double.Parse(txtCostSecuritySalary.Text);
                    double supervisorSalary = double.Parse(txtCostSupervisorSalary.Text);
                    double managerSalary = double.Parse(txtCostManagerSalary.Text);
                    double totalClothes = double.Parse(txtCostTotalClothes.Text);
                    double totalDevices = double.Parse(txtCostTotalDevices.Text);

                    locationControl.updateLocationCost(locationName, securitySalary, supervisorSalary, managerSalary);
                    locationClothesControl.insert(totalClothes, locationName);
                    locationClothesContentControl.insert(listViewCostClothes);
                    locationEquipsConrol.insert(totalDevices, locationName);
                    locationEquipsContentControl.insert(listViewCostDevices);
                    MessageBox.Show("تم حفظ التكاليف بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void تقيممصدرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUpdateSource f = new FormUpdateSource();
            f.ShowDialog();
        }

    }
}