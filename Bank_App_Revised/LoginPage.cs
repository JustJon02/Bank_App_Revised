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
    public partial class LoginPage : Form
    {
        int sLength = 0;
        string sPIN;
        string Hex1 = "#008ECC";
        string Hex2 = "#CB5C0D";
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
            txtPIN.Text.ToString();
            txtPIN.MaxLength = 4;
            txtPIN.UseSystemPasswordChar = true;
            Color myColour = System.Drawing.ColorTranslator.FromHtml(Hex1);
            this.BackColor = myColour;
            pbBanner.BackColor = ColorTranslator.FromHtml(Hex2);
            pnlBottom.BackColor = ColorTranslator.FromHtml(Hex2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sPIN = txtPIN.Text.ToString();
            sLength = sPIN.Length;
            if (sLength <4)
            {
                MessageBox.Show("Your PIN must contain 4 numbers.");
            }
            else {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Year 2\Other\Bank_App_Revised\Bank_App_Revised\bin\Debug\BankDB.mdf;Integrated Security=True;Connect Timeout=30");
                SqlDataAdapter sqa = new SqlDataAdapter("Select count(*) From BankDBTable where Username ='" + txtUsername.Text + "' and Password ='" + txtPassword.Text + "' and PIN ='" + txtPIN.Text + "'", con);
                DataTable dt = new DataTable();
                sqa.Fill(dt);

                if (dt.Rows[0][0].ToString() == "1")
                {

                }
                else
                {
                    MessageBox.Show("Please check that your username and/or password is correct.");
                }
            } }
    }
}
