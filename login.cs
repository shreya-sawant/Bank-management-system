using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client; // ODP.NET Oracle managed provider
using Oracle.DataAccess.Types;


namespace DBMS
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (userID.Text == "")
            {
                MessageBox.Show("Enter User name");
            }
            else if (password.Text == "")
            {
                MessageBox.Show("Enter Password!!!");
            }
            else if (userID.Text == "Abhishek" && password.Text == "123456")
            {
                this.Hide();
                Form frm6 = new home();
                frm6.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid Credential");
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
