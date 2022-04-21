using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace TravelR
{
    public partial class C_book : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["cu"].ConnectionString;

        public C_book()
        {
            InitializeComponent();
            BindGridView();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CS_MAIN h = new CS_MAIN();
            h.Show();
            this.Hide();
        }
        void BindGridView()
        {
            //Connection
            SqlConnection sql = new SqlConnection(cs);
            string q = "select * from book where username='"+Customer.loginuser+"'";
            SqlDataAdapter sda = new SqlDataAdapter(q, sql);

            //data Grid view display
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

           

            //Table layout fit
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //TAble Height
            dataGridView1.RowTemplate.Height = 50;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("They will Contact you soon!!! Mr."+Customer.loginuser);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sc = new SqlConnection(cs);
            string query = "delete from book where sname=@sname";
            SqlCommand cmd = new SqlCommand(query, sc);
            cmd.Parameters.AddWithValue("@sname", dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
            sc.Open();
            int A = cmd.ExecuteNonQuery();
            if (A > 0)
            {
                MessageBox.Show("Data deleted successfully......", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGridView();
            }
            else
            {
                MessageBox.Show("Data not deleted......", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            sc.Close();
        }
    }
}
