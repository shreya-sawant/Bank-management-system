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
    public partial class loan : Form
    {
        int temp;
        public loan()
        {
            InitializeComponent();
        }

        private void loan_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Enter all credentials");
            }
            else
            {
                temp = 0;
                string oradb = "Data Source=localhost;User Id=bank;Password=bank";
                string query = "insert into loan values(" + textBox1.Text.Trim() + "," + textBox2.Text.Trim() + ",'" + textBox3.Text.Trim() + "'," + textBox4.Text.Trim() +",'"+ textBox5.Text.Trim() + "') ";
                OracleConnection conn = new OracleConnection(oradb);  // C#
                conn.Open();
                OracleCommand cmd = new OracleCommand(query, conn);
                temp = cmd.ExecuteNonQuery();

                if (temp > 0 )
                    MessageBox.Show("RECORD ADDED SUCCESSFULLY");
                else
                    MessageBox.Show("INSERT OPERATION FAILED");
                conn.Dispose();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox5.Text=="")
            {
                MessageBox.Show("Enter loan id.,account no. & status");
            }
            else
            {
                temp = 0;
                string oradb = "Data Source=localhost;User Id=bank;Password=bank";
                string query = "update loan set status='" + textBox5.Text.Trim() + "'where loan_id=" + textBox1.Text.Trim() + " AND account_no=" + textBox2.Text.Trim() ;
                OracleConnection conn = new OracleConnection(oradb);  // C#
                conn.Open();
                OracleCommand cmd = new OracleCommand(query, conn);
                temp = cmd.ExecuteNonQuery();

                if (temp > 0)
                    MessageBox.Show("UPDATE SUCCESSFULL");
                else
                    MessageBox.Show("OPERATION FAILED");
                conn.Dispose();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frm6 = new home();
            frm6.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Enter loan id.,account no.");
            }
            else
            {
                temp = 0;
                string oradb = "Data Source=localhost;User Id=bank;Password=bank";
                string query = "select status from loan where loan_id= " + textBox1.Text.Trim()+ " AND account_no=" + textBox2.Text.Trim();
                OracleConnection conn = new OracleConnection(oradb);  // C#
                conn.Open();
                OracleCommand cmd = new OracleCommand(query, conn);
                OracleDataReader dr = cmd.ExecuteReader();
                dr.Read();
                try
                {
                    MessageBox.Show("status= " + dr.GetString(0));
                }
                catch
                {
                    MessageBox.Show("loan id or account no. does not exist ");

                }
                conn.Dispose();
            }
        }
    }
}
