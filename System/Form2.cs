
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace System
{
    public partial class Form2 : Form
    {
        private const string connection = "server=localhost;port=3306;database=managementsystem;user=root;password=";
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            string role = null;
            if(rdoAdmin.Checked)
            {
                role = "admin";
            }
            if(rdoUser.Checked)
            {
                role = "staff";
            }

            if (string.IsNullOrEmpty(txtFirstName.Text) || string.IsNullOrEmpty(txtLastName.Text) || string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtConfirmPass.Text) || string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Kindly complete the blank.", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Text = txtConfirmPass.Text = txtFirstName.Text = txtLastName.Text = txtUsername.Text = txtPassword.Text = "";
            }
            else
            {
                string FirstName = txtFirstName.Text;
                string LastNmae = txtLastName.Text;
                string Email = txtEmail.Text;
                string Username = txtUsername.Text;
                string Password = txtConfirmPass.Text;

                string insertQuery = "INSERT INTO accounts(firstname,lastname,email,username,password,role) VALUES  (@firstname,@lastname,@email,@username,@password,@role)";

                using (MySqlConnection con = new MySqlConnection(connection))
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@firstname", FirstName);
                        cmd.Parameters.AddWithValue("@lastname", LastNmae);
                        cmd.Parameters.AddWithValue("@email", Email);
                        cmd.Parameters.AddWithValue("@username", Username);
                        cmd.Parameters.AddWithValue("@password", Password);
                        cmd.Parameters.AddWithValue("@role", role);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Data inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           txtEmail.Text = txtConfirmPass.Text = txtFirstName.Text = txtLastName.Text = txtUsername.Text = txtPassword.Text = "";

                            Form1 form1 = new Form1();
                            form1.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Failed to insert data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
