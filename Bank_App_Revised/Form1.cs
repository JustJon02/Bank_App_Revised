﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_App_Revised
{
    public partial class Main_Menu : Form
    {
        public Main_Menu()
        {
            InitializeComponent();
        }

        private void Main_Menu_Load(object sender, EventArgs e)
        {

        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            LoginPage Login = new LoginPage();
            Login.ShowDialog();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUpPage SignUp = new SignUpPage();
            SignUp.ShowDialog();
        }
    }
}
