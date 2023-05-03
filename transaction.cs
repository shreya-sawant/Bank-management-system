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
    public partial class transaction : Form
    {
        int temp;
        public transaction()
        {
            InitializeComponent();
        }

        private void transaction_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text=="")
            {
                MessageBox.Show("Enter all credentials");
            }
            else
            {
                temp = 0;
                string oradb = "Data Source=localhost;User Id=bank;Password=bank";
                string query = "update account set balance=balance -" + textBox1.Text.Trim() + " where account_no=" + textBox2.Text.Trim();

                OracleConnection conn = new OracleConnection(oradb);  // C#
                conn.Open();

                string query7 = "select balance from account where account_no= " + textBox2.Text.Trim();
                    OracleCommand cmd7 = new OracleCommand(query7, conn);
                    OracleDataReader rr = cmd7.ExecuteReader();
                    rr.Read();
                int value;
                int.TryParse(textBox1.Text, out value);
                    if (rr.GetInt32(0)<value )
                    {
                    MessageBox.Show("BALANCE IS INSUFFICIENT");
                    }
                    

                else{

                    OracleCommand cmd = new OracleCommand(query, conn);
                    temp = cmd.ExecuteNonQuery();
                    
                    if (temp > 0 )
                    {
                        string query1 = "insert into transaction values(trunc(DBMS_RANDOM.VALUE(100, 1000)), sysdate," + textBox2.Text.Trim() + "," + textBox1.Text.Trim() + ",'withdraw')";
                        OracleCommand cmd1 = new OracleCommand(query1, conn);
                        cmd1.ExecuteNonQuery();
                        string query3 = "select balance from account where account_no= " + textBox2.Text.Trim();
                        OracleCommand cmd3 = new OracleCommand(query3, conn);
                        OracleDataReader dr = cmd3.ExecuteReader();
                        dr.Read();
                        MessageBox.Show("Balance= " + dr.GetInt32(0));
                    }
                    else
                        MessageBox.Show("OPERATION FAILED");
                }
                conn.Dispose();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Enter account_no.");
            }
            else
            {
                string oradb = "Data Source=localhost;User Id=bank;Password=bank";
                string query = "select * from transaction where account_no=" + textBox2.Text.Trim();
                OracleConnection conn = new OracleConnection(oradb);  // C#
                conn.Open();
                
                OracleDataAdapter sda = new OracleDataAdapter(query, conn);
                DataTable ds = new DataTable();
                sda.Fill(ds);
                dataGridView1.DataSource = ds;
            }
                
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frm6 = new home();
            frm6.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Enter all credentials");
            }
            else
            {
                temp= 0;
                string oradb = "Data Source=localhost;User Id=bank;Password=bank";
                string query = "update account set balance=balance +" + textBox1.Text.Trim()+ " where account_no=" + textBox2.Text.Trim();

                OracleConnection conn = new OracleConnection(oradb);  // C#
                conn.Open();
                OracleCommand cmd = new OracleCommand(query, conn);
                temp = cmd.ExecuteNonQuery();

                

                if (temp > 0 )
                {
                    string query1 = "insert into transaction values(trunc(DBMS_RANDOM.VALUE(100, 1000)), sysdate," + textBox2.Text.Trim() + "," + textBox1.Text.Trim() + ",'deposit')";
                    OracleCommand cmd1 = new OracleCommand(query1, conn);
                    cmd1.ExecuteNonQuery();
                    string query3 = "select balance from account where account_no= " + textBox2.Text.Trim();
                    OracleCommand cmd3 = new OracleCommand(query3, conn);
                    OracleDataReader dr = cmd3.ExecuteReader();
                    dr.Read();
                    MessageBox.Show("Balance= " + dr.GetInt32(0));
                }
                    
                else
                    MessageBox.Show("OPERATION FAILED");
                conn.Dispose();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
