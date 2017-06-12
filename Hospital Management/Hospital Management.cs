using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_Management
{
    public partial class Form : System.Windows.Forms.Form
    {
        UserData data = new UserData();
        PatientData patientData = new PatientData();
        public Form()
        {
            InitializeComponent();
        }

        private bool CheckLine(TextBox label)
        {
            if (label.Text.Length == 0)
            {
                label.BackColor = Color.FromArgb(255, 178, 178);
                return false;
            }
            else
            {
                label.BackColor = Color.White;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string login = username.Text;
            string password = this.password.Text;
            if (true)// (data.checkUserExistence(login, password))
            {
                menuPanel.Visible = true;
            }
            else
            {
                username.BackColor = Color.FromArgb(255, 178, 178);
                this.password.BackColor = Color.FromArgb(255, 178, 178);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addPatient_Click(object sender, EventArgs e)
        {
            bool emptyLine = true;
            emptyLine = CheckLine(name);
            emptyLine = CheckLine(address);
            emptyLine = CheckLine(disease);
            emptyLine = CheckLine(disease);
            if (phone.Text.Length != 13)
            {
                phone.BackColor = Color.FromArgb(255, 178, 178);
                emptyLine = false;
            }
            else
            {
                phone.BackColor = Color.White;
            }
            if (emptyLine)
            {
                Calendar date = new Calendar(calendar.Value.ToString(), Convert.ToInt32(hour.SelectedItem.ToString()));
                AllMembers.RequestForConsultation(name.Text, Convert.ToInt32(age.Text), gender.SelectedItem.ToString(), date, phone.Text, address.Text, disease.Text);
                patientData.AddUser(name.Text, Convert.ToInt32(age.Text), gender.SelectedItem.ToString(), date, phone.Text, address.Text, disease.Text);
                name.Text = "";
                phone.Text = "";
                address.Text = "";
                disease.Text = "";
                request.Visible = false;
            }
        }

        private void patientRegister_Click(object sender, EventArgs e)
        {
            number.Text = Convert.ToString(Patient.numberOfPatients+1);
            string username = UserData.username;
            id.Text = (username + "").ToUpper() + (Patient.numberOfPatients+1);
            if(!request.Visible)
            request.Visible = true;
        }

        private void age_TextChanged(object sender, EventArgs e)
        {
            string text = age.Text;
            string newText = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] >= '0' && text[i] <= '9')
                    newText += text[i];
            }
            if (newText.Length > 0 && newText[0] == '0')
                newText = newText.Substring(1);
            if (newText.Length > 3)
                newText = newText.Substring(0, 3);
            age.Text = newText;
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            bool ready = true;
            ready = CheckLine(insertName);
            ready = CheckLine(insertUsername);
            ready = CheckLine(insertPassword);
            ready = CheckLine(insertConfirm);
            if (data.checkUsernameRepeation(insertUsername.Text))
            {
                MessageBox.Show("This username is busy.");
                insertUsername.BackColor = Color.FromArgb(255, 178, 178);
                ready = false;
            }
            if (insertPassword.Text != insertConfirm.Text)
                ready = false;
            if (ready)
            {
                data.AddUser(insertName.Text, insertUsername.Text, insertPassword.Text);
                menuPanel.Visible = true;
                registerPanel.Visible = false;
            }
        }

        private void insertConfirm_TextChanged(object sender, EventArgs e)
        {
            if (insertPassword.Text == insertConfirm.Text)
                insertConfirm.BackColor = Color.FromArgb(26, 188, 156);
            else
                insertConfirm.BackColor = Color.FromArgb(255, 178, 178);
        }

        private void insertPassword_TextChanged(object sender, EventArgs e)
        {
            if (insertPassword.Text == insertConfirm.Text)
                insertConfirm.BackColor = Color.FromArgb(26, 188, 156);
            else
                insertConfirm.BackColor = Color.FromArgb(255, 178, 178);
        }

        private void backLogin_Click(object sender, EventArgs e)
        {
            registerPanel.Visible = false;
            menuPanel.Visible = false;
        }

        private void register_Click(object sender, EventArgs e)
        {
            registerPanel.Visible = true;
        }

        private void closeRequest_Click(object sender, EventArgs e)
        {
            name.Text = "";
            phone.Text = "";
            address.Text = "";
            disease.Text = "";
            request.Visible = false;
        }

        private void information_Click(object sender, EventArgs e)
        {
            patientInformationPanel.Visible = true;
            list.Items.Clear();
            for (int i = 0; i < AllMembers.PatientList.Count; i++)
            {
                list.Items.Add(AllMembers.PatientList[i].Name);
            }            
        }

        private void list_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (list.SelectedItems.Count > 0)
            {
                string item = list.SelectedItems[0].ToString();
                item = item.Substring(item.IndexOf("{") + 1, item.IndexOf("}") - item.IndexOf("{") - 1);
                Patient patient = patientData.FindPatientByName(item);
                user.Text = patient.Username;
                informName.Text = patient.Name;
                informGender.Text = patient.Gender;
                informAge.Text = patient.Age.ToString();
                informPhone.Text = patient.Phone;
                informAddress.Text = patient.Address;
                informDisease.Text = patient.Disease;
            }

        }

        private void informClose_Click(object sender, EventArgs e)
        {
            patientInformationPanel.Visible = false;
        }

        private void doctor_Click(object sender, EventArgs e)
        {
            staffPanel.Visible = true;
        }

        private void staffClose_Click(object sender, EventArgs e)
        {
            staffPanel.Visible = false;
        }
    }
}
