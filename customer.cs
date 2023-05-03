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
    public partial class customer : Form
    {
        int temp,temp1;
        public customer()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter account_no.");
            }
            else
            {
                temp=temp1 = 0;
                string oradb = "Data Source=localhost;User Id=bank;Password=bank";
                string query = "delete from customer where account_no=" + textBox1.Text.Trim() ;
                string query2 = "delete from account where account_no=" + textBox1.Text.Trim();

                OracleConnection conn = new OracleConnection(oradb);  // C#
                conn.Open();
                OracleCommand cmd = new OracleCommand(query, conn);
                temp = cmd.ExecuteNonQuery();

                OracleCommand cmd2 = new OracleCommand(query2, conn);
                temp1 = cmd2.ExecuteNonQuery();

                if (temp > 0 && temp1>0)
                    MessageBox.Show("DELETE SUCCESSFULL");
                else
                    MessageBox.Show("OPERATION FAILED");
                conn.Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frm6 = new home();
            frm6.ShowDialog();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == ""|| textBox1.Text == ""|| textBox3.Text == ""|| textBox4.Text == "")
            {
                MessageBox.Show("Enter all credentials");
            }
            else
            {
                temp = 0;
                temp1 = 0;
                string oradb = "Data Source=localhost;User Id=bank;Password=bank";
                string query = "insert into customer values('"+ textBox2.Text.Trim()+"',"+textBox1.Text.Trim()+","+textBox3.Text.Trim()+",'"+ textBox4.Text.Trim()+ "') " ;
                string query1 = "insert into account values(" + textBox1.Text.Trim() + "," + 500 + ") ";
                OracleConnection conn = new OracleConnection(oradb);  // C#
                conn.Open();
                OracleCommand cmd = new OracleCommand(query, conn);
                OracleCommand cmd1 = new OracleCommand(query1, conn);
                temp = cmd.ExecuteNonQuery();
                temp1 = cmd1.ExecuteNonQuery();
              
                if (temp > 0 && temp1>0)
                    MessageBox.Show("RECORD ADDED SUCCESSFULLY");
                else
                    MessageBox.Show("INSERT OPERATION FAILED");
                conn.Dispose();
            }
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
