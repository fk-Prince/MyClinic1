using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ClinicSystem
{
    public partial class RegisterPatient : Form
    {


        private double bill;
        private Doctor doctorAssigned;
        private FrontDesk frontDesk;
        public RegisterPatient(ClinicSystem clinicSystem, FrontDesk frontDesk)
        {
            this.frontDesk = frontDesk;
            InitializeComponent();
            FirstName.BorderStyle = BorderStyle.None;
            MiddleName.BorderStyle = BorderStyle.None;
            LastName.BorderStyle = BorderStyle.None;
            Age.BorderStyle = BorderStyle.None;
            Address.BorderStyle = BorderStyle.None;
            Birthdate.BorderStyle = BorderStyle.None;
            ContactNumber.BorderStyle = BorderStyle.None;
            DateAdmitted.BorderStyle = BorderStyle.None;
            Bill.BorderStyle = BorderStyle.None;

            DateTime date = DateTime.Now;
            date = date.Date;
            DateAdmitted.Text = date.ToString(date.ToString("yyyy-MM-dd"));

            getOperation();
        }

        private void getOperation()
        {
           try
            {

                string driver = "server=localhost;username=root;password=root;database=clinicdatabase";
                MySqlConnection conn = new MySqlConnection(driver);
                conn.Open();
                string query = "SELECT * FROM clinicoperation_tbl";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

               while(reader.Read())
                {
                    ComboOperation.Items.Add(reader["OperationName"].ToString());
                }
                conn.Close();


            }
            catch (MySqlException ex)
            {
              MessageBox.Show(ex.Message);
            }
        }

        private void ComboOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboDoctor.Items.Clear();
            ComboDoctor.SelectedIndex = -1;
            ComboDoctor.Text = "";
            Bill.Text = "";
            string operationname = "";
            if (ComboOperation.SelectedItem == null)
            {
                return;
            }
            operationname = ComboOperation.SelectedItem.ToString();
            if (string.IsNullOrEmpty(operationname))
            {
                return;
            }
            try
            {
                int operationid = getOprationId(operationname);
                string driver = "server=localhost;username=root;password=root;database=clinicdatabase";
                MySqlConnection conn = new MySqlConnection(driver);
                conn.Open();
                string query = "SELECT * FROM doctor_tbl WHERE OPERATIONID = @OPERATIONID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@OPERATIONID", operationid);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                {
                    ComboDoctor.Items.Clear();
                    ComboDoctor.Items.Add("No Doctor Available");
                    ComboDoctor.SelectedIndex = 0;
                }
                else
                {

                    while (reader.Read())
                    {
                        doctorAssigned = new Doctor(
                           int.Parse(reader["DoctorID"].ToString()),
                           reader["FirstName"].ToString(),
                           reader["MiddleName"].ToString(),
                           reader["LastName"].ToString(),
                           int.Parse(reader["Age"].ToString()),
                           DateTime.Parse(reader["Date-Hired"].ToString()),
                           reader["Password"].ToString(),
                           int.Parse(reader["OperationID"].ToString())
                           );

                        string doctor = reader["DoctorID"] + ",  " + doctorAssigned.getDoctorFirstName() + ", " + doctorAssigned.getDoctorMiddleName() + " " + doctorAssigned.getDoctorLastName();
                        ComboDoctor.Items.Add(doctor.ToString());
                    }
                    ComboDoctor.SelectedIndex = 0;
                }
                conn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message+ "dgdfgdfg");
            }
        }

        private int getOprationId(string operationname)
        {
            try
            {
                string driver = "server=localhost;username=root;pwd=root;database=clinicdatabase";
                MySqlConnection conn = new MySqlConnection(driver);
                conn.Open();    
                string qry = "SELECT OperationID, Price FROM clinicoperation_tbl WHERE OperationName = @OperationName";
                MySqlCommand command = new MySqlCommand(qry, conn);
                command.Parameters.AddWithValue("@OperationName", operationname);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    bill = double.Parse(reader["Price"].ToString());
                    return int.Parse(reader["operationID"].ToString());
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message + "Xdasvd");
            }
            return 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Patient patient = getPatient();

            if (patient == null)
            {
                return;
            }

            try
            {
                string driver = "server=localhost;username=root;pwd=root;database=clinicdatabase";
                MySqlConnection conn = new MySqlConnection(driver);
                conn.Open();

                string query = "INSERT INTO patient_tbl " +
                "(FrontDeskID, DoctorID, OperationID, FirstName, MiddleName, LastName, " +
                "Age, Address, DateAdmitted, PatientCondition, MedicalHistory, Bill, Gender, ContactNumber, BirthDate) " +
                "VALUES " +
                "(@FrontDeskID, @DoctorID, @OperationID, @FirstName, @MiddleName, @LastName, " +
                "@Age, @Address, @DateAdmitted, @PatientCondition, @MedicalHistory, @Bill, " +
                "@Gender, @ContactNumber, @BirthDate) ";

               

                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@FrontDeskID", frontDesk.getId());
                command.Parameters.AddWithValue("@DoctorID", doctorAssigned.getDoctorID());
                command.Parameters.AddWithValue("@OperationID", patient.getOperationID());
                command.Parameters.AddWithValue("@FirstName", patient.getFirstName());
                command.Parameters.AddWithValue("@MiddleName", patient.getMiddleName());
                command.Parameters.AddWithValue("@LastName", patient.getLastName());
                command.Parameters.AddWithValue("@Age", patient.getAge());
                command.Parameters.AddWithValue("@Address", patient.getAddress());
                command.Parameters.AddWithValue("@DateAdmitted", patient.getDateAdmitted());
                command.Parameters.AddWithValue("@PatientCondition", patient.getCondition());
                command.Parameters.AddWithValue("@MedicalHistory", patient.getMedicalHistory());
                command.Parameters.AddWithValue("@Bill", patient.getBill());
                command.Parameters.AddWithValue("@Gender", patient.getGender());
                command.Parameters.AddWithValue("@ContactNumber", patient.getContactNumber());
                command.Parameters.AddWithValue("@BirthDate", patient.getBirthDate());
                command.ExecuteNonQuery();

                MessageBox.Show("Patient Registered Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                resetFields();      
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("DB ERROR: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void resetFields()
        {
            FirstName.Text = "";
            MiddleName.Text = "";
            LastName.Text = "";
            Address.Text = "";
            RadioMale.Checked = false;
            RadioFemale.Checked = false;
            Age.Text = "";
            Birthdate.Text = "";
            ContactNumber.Text = "";
            PatientCondition.Text = "";
            ComboOperation.SelectedIndex = -1;
            ComboDoctor.SelectedIndex = -1;
            MedicalHistory.Text = "";
            Bill.Text = "";
        }
        private Patient getPatient()
        {
            string firstName = FirstName.Text.Trim();
            string middleName = MiddleName.Text.Trim(); ;
            string lastName = LastName.Text.Trim(); ;
            string address = Address.Text.Trim();
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(middleName)
                || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(address)
                || string.IsNullOrWhiteSpace(Age.Text.Trim()) || string.IsNullOrWhiteSpace(Birthdate.Text.Trim())
                || string.IsNullOrWhiteSpace(DateAdmitted.Text.Trim()) || string.IsNullOrWhiteSpace(ContactNumber.Text.Trim()))
            {
                MessageBox.Show("Please Fill the fields.");
                return null;
            }
            string gender = "";
            if (!RadioMale.Checked && !RadioFemale.Checked)
            {
                MessageBox.Show("Please Select Gender");
                return null;
            }
            else if (RadioMale.Checked)
            {
                gender = "Male";
            }
            else if (RadioFemale.Checked)
            {
                gender = "Female";
            }
            ;
            int age;
            if (!int.TryParse(Age.Text.Trim(), out age))
            {
                MessageBox.Show("Enter age");
                return null;
            }

            if (age < 0)
            {
                MessageBox.Show("Invalid Age");
                return null;
            }
            DateTime birthDate;
            if (!DateTime.TryParse(Birthdate.Text.Trim(), out birthDate))
            {
                MessageBox.Show("Invalid date!1! Please enter a valid date (yyyy-MM-dd).");
                return null;
            }
            birthDate = birthDate.Date;
            int contactNumber;
            if (!int.TryParse(ContactNumber.Text.Trim(), out contactNumber))
            {
                MessageBox.Show("Enter Valid Contact Number.");
                return null;
            }

            DateTime dateAdmitted;
            if (!DateTime.TryParse(DateAdmitted.Text.Trim(), out dateAdmitted))
            {
                MessageBox.Show("Invalid date!1! Please enter a valid date (yyyy-MM-dd).");
                return null;
            }

            string condition = PatientCondition.Text.Trim();
            if (ComboOperation.SelectedIndex == -1)
            {
                MessageBox.Show("Enter Operation.");
                return null;
            }

            string SpecializedName = ComboOperation.SelectedItem.ToString();
            int operationid = getOprationId(SpecializedName);
            if (operationid == 0)
            {
                MessageBox.Show("Invalid Operation.");
                return null;
            }

            string doctor = ComboDoctor.SelectedItem.ToString();
            if (doctor.Equals("No Doctor Available", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("No Doctor Available");
                return null;
            }

            if (ComboDoctor.SelectedIndex == -1)
            {
                MessageBox.Show("Enter Doctor Assigned.");
                return null;
            }
            string doctorAssigned = ComboDoctor.SelectedItem.ToString();
            string medicalHistory = MedicalHistory.Text.Trim();
            double bill = double.Parse(Bill.Text.Trim());

            return new Patient(
                    firstName,
                    middleName,
                    lastName,
                    address,
                    gender,
                    age,
                    birthDate,
                    contactNumber,
                    dateAdmitted,
                    condition,
                    operationid,
                    doctorAssigned,
                    medicalHistory,
                    bill
            );

        }

        private void ComboDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bill.Text = bill.ToString();
        }
    }
}
