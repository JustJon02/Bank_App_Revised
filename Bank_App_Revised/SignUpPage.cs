using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Bank_App_Revised
{
    public partial class SignUpPage : Form
    {
        bool Pass = true;
        string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Year 2\Other\Bank_App_Revised\Bank_App_Revised\bin\Debug\BankDB.mdf;Integrated Security=True;Connect Timeout=30";
        public SignUpPage()
        {
            InitializeComponent();
        }

        private void SignUpPage_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            
            if (txtUsername.Text == "" || txtPassword.Text == "" || txtPIN.Text == "")
            {
                MessageBox.Show("Please fill all fields");
            }
            else
            {
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("Users", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@PIN", txtPIN.Text.Trim());
                    sqlCmd.ExecuteNonQuery();
                    MessageBox.Show("You are now registered!");
                    Clear();
                    this.Close();
                }
            }
        }

        private void btnPass_Click(object sender, EventArgs e)
        {
            if (Pass == false)
            {
                btnPass.Text = "Show Password";
                txtPassword.UseSystemPasswordChar = true;
                
                Pass = true;
            }
            else if (Pass == true)
            {
                btnPass.Text = "Hide Password";
                txtPassword.UseSystemPasswordChar = false;
                
                Pass = false;
            }
        }
        void Clear()
        {
            txtFirstName.Text = txtLastName.Text = txtUsername.Text = txtPassword.Text = txtPIN.Text = "";
        }
    }
}
