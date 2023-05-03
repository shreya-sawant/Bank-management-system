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
    public partial class account : Form
    {
        public account()
        {
            InitializeComponent();
           
        }

        
        private void account_Load(object sender, EventArgs e)
        {

        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            string oradb = "Data Source=localhost;User Id=bank;Password=bank";
            string query= "select balance from account where account_no= " + textBox2.Text.Trim();
            OracleConnection conn = new OracleConnection(oradb);  // C#
            conn.Open();
            OracleCommand cmd = new OracleCommand(query,conn);
            OracleDataReader dr = cmd.ExecuteReader();
            dr.Read();
            try
            {
                MessageBox.Show("Balance= " + dr.GetInt32(0));
            }
            catch
            {
                MessageBox.Show("Account does not exist");
            }
            conn.Dispose();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form frm6 = new home();
            frm6.ShowDialog();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
