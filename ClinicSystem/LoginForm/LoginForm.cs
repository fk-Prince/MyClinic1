using System;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace ClinicSystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            LoginButton.FlatAppearance.BorderSize = 0;
            LoginButton.FlatStyle = FlatStyle.Flat;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = Username.Text.Trim();
            string password = Password.Text.Trim();
           
            try
            {
               
                string driver = "server=localhost;username=root;password=root;database=clinicdatabase"; 
                MySqlConnection conn = new MySqlConnection(driver);
                conn.Open();

                string query = "SELECT Username, Password, FrontDeskID FROM FRONTDESK_TBL WHERE USERNAME = @USERNAME AND PASSWORD = @PASSWORD";
                MySqlCommand command = new MySqlCommand(query, conn);

                command.Parameters.AddWithValue("@USERNAME", username); 
                command.Parameters.AddWithValue("@PASSWORD", password);

                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows == false)
                {
                    MessageBox.Show("Wrong Username or Password", "Incorrect Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                while (reader.Read())
                {
                    FrontDesk frontDesk = new FrontDesk(reader["Username"].ToString(), reader["Password"].ToString(), int.Parse(reader["FrontDeskID"].ToString()));
                    MessageBox.Show("Login Successful");
                    this.Hide();
                    ClinicSystem clinicSystem = new ClinicSystem(frontDesk);
                    clinicSystem.Show();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }

}
