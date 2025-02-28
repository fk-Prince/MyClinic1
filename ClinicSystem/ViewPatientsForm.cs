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
using ClinicSystem.Main;
using MySql.Data.MySqlClient;

namespace ClinicSystem
{
    public partial class ViewPatientsForm : Form
    {
        private FrontDesk frontDesk;
        public ViewPatientsForm(FrontDesk frontDesk)
        {
            this.frontDesk = frontDesk;
            InitializeComponent();
            getPatients("Select * FROM patients", null);
        }

        private void getPatients(string query, string patientName)
        {
            try
            {
                FlowPanel.Controls.Clear();
                string driver = "server=localhost;username=root;password=root;database=clinicdb";
                MySqlConnection conn = new MySqlConnection(driver);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, conn);
                if (!string.IsNullOrWhiteSpace(patientName))
                {
                    cmd.Parameters.AddWithValue("@FirstName", patientName + "%");
                    cmd.Parameters.AddWithValue("@LastName", patientName + "%");
                }
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int patientId = int.Parse(reader["PatientId"].ToString());
                    Panel panel = new Panel();
                    panel.Size = new Size(800, 200);
                    panel.BackColor = Color.FromArgb(255, 255, 255);
                    panel.Margin = new Padding(10, 10, 10, 60);
                    panel.BorderStyle = BorderStyle.FixedSingle;

                    Label fullname = createLabel("Patient FullName", reader["FirstName"].ToString() + "    " + reader["MiddleName"].ToString() + "    " + reader["LastName"].ToString(), 10, 10);
                    panel.Controls.Add(fullname);

                    Label age = createLabel("Age", reader["Age"].ToString(), 10, 40);
                    panel.Controls.Add(age);

                    Label address = createLabel("Address", reader["Address"].ToString(), 10, 70);
                    panel.Controls.Add(address);

                    Label gender = createLabel("Gender", reader["Gender"].ToString(), 10, 100);
                    panel.Controls.Add(gender);

                    Label bday = createLabel("Birth-Date", Convert.ToDateTime(reader["BirthDate"]).ToString("yyyy-MM-dd"), 10, 130);
                    panel.Controls.Add(bday);

                    Label number = createLabel("Contact Number", reader["ContactNumber"].ToString(), 10, 160);
                    panel.Controls.Add(number);


                    getDoctorName(reader["DoctorID"].ToString(), reader["OperationCode"].ToString(), panel);

                    Label status = createLabel("Status", reader["Status"].ToString(), 400, 70);
                    panel.Controls.Add(status);

                    Label dateAdmitted = createLabel("Date-Admitted", Convert.ToDateTime(reader["DateAdmitted"]).ToString("yyyy-MM-dd"), 400, 100);
                    panel.Controls.Add(dateAdmitted);

                  
                    if (reader["DateDischarged"] == DBNull.Value)
                    {
                        Label title = createLabel("Date-Discharged", "", 400, 130);
                        panel.Controls.Add(title);
                        Button button = new Button();
                        button.Text = "Discharge";
                        button.Location = new Point(530, 128);
                        button.Click += new EventHandler(DischargeButton_Click);
                        button.Tag = patientId; 
                        panel.Controls.Add(button);
                    }
                    else
                    {
                        Label dateDischarge = createLabel("DateDischarged", Convert.ToDateTime(reader["DateDischarged"]).ToString("yyyy-MM-dd"), 400, 130);
                        panel.Controls.Add(dateDischarge);
                    }   

                    Label room = createLabel("Room Used", reader["RoomNo"].ToString(), 400, 160);
                    panel.Controls.Add(room);

                    FlowPanel.Controls.Add(panel);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERrorDB");
            }
        }

        private void DischargeButton_Click(object sender, EventArgs e)
        {
            try
            {
                Button button = sender as Button;
                int patientId = Convert.ToInt32(button.Tag);
                string driver = "server=localhost;username=root;pwd=root;database=clinicdb";
                MySqlConnection conn = new MySqlConnection(driver);
                conn.Open();
                DateTime now = DateTime.Now;
                string date = now.ToString("yyyy-MM-dd");
                string query = "UPDATE patients SET DateDischarged = @DateDischarged WHERE patientId = @patientId";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@patientId", patientId);
                command.Parameters.AddWithValue("@DateDischarged", date);
                command.ExecuteNonQuery();
                getPatients("Select * FROM patients", null);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("erqwv");
            }
        }

        private void getDoctorName(string doctorId,string operationCode, Panel panel)
        {
            try
            {
                string driver = "server=localhost;username=root;pwd=root;database=clinicdb";
                MySqlConnection conn = new MySqlConnection(driver);
                conn.Open();
                string query = "SELECT FirstName, MiddleName, LastName, " +
                        "doctoroperations.OperationCode,OperationName " +
                        "FROM doctors " +
                        "LEFT JOIN doctoroperations ON doctors.DoctorID = doctoroperations.DoctorID " +
                        "LEFT JOIN operations ON doctoroperations.OperationCode = operations.OperationCode " +
                        "WHERE doctors.DoctorID = @DoctorID AND doctoroperations.OperationCode = @OperationCode";

                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@DoctorID", doctorId);
                command.Parameters.AddWithValue("@OperationCode", operationCode);

                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Label dr = createLabel("Doctor Assigned", reader["FirstName"].ToString() + "    " + reader["MiddleName"].ToString() + "    " + reader["LastName"].ToString(), 400, 10);
                    panel.Controls.Add(dr);

                    Label operationname = createLabel("Operation Name", reader["OperationName"].ToString(), 400, 40);
                    panel.Controls.Add(operationname);
                } 
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("ERR" +ex.Message);
            }
        }

        private Label createLabel(string title,string value, int x,int y)
        {
            Label label = new Label();
            label.Text = $"{title}:  {value}";
            label.Location = new Point(x, y);
            label.AutoSize = true;
            label.Font = new Font("Arial", 10, FontStyle.Regular);
            return label;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchPatientName.Text))
            {
                getPatients("Select * FROM patients", null);
                return;
            }
            getPatients("Select * FROM patients WHERE FirstName LIKE @FirstName OR LastName LIKE @LastName", searchPatientName.Text.Trim());
        }
    }
}
