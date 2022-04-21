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

namespace TravelR
{
    public partial class CS_MAIN : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["cu"].ConnectionString;
        public CS_MAIN()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void CS_MAIN_Load(object sender, EventArgs e)
        {
            label2.Text=Customer.loginuser;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            CTR c = new CTR();
            c.Show();
            this.Hide();
           
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Customer g = new Customer();
            g.Show();
            this.Hide();
                
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CGuide g = new CGuide();
            g.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to delete this account?", "Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if(dialogResult== DialogResult.Yes)
            {
                SqlConnection sql = new SqlConnection(cs);
                string q = "Delete FROM REG WHERE USERNAME=@USERNAME AND PASS=@PASS";
                SqlCommand s = new SqlCommand(q, sql);
                s.Parameters.AddWithValue("@USERNAME", Customer.loginuser);
                s.Parameters.AddWithValue("@PASS", Customer.passuser);
                sql.Open();
                SqlDataReader d = s.ExecuteReader();
                if (d.HasRows == true)
                {
                    MessageBox.Show("Account Deleted..", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    Customer c = new Customer();
                    c.Show();
                    this.Hide();
                }
                else
                {

                    MessageBox.Show("Deleting Failed!!!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                sql.Close();
            }
            else if(dialogResult == DialogResult.No | dialogResult == DialogResult.Cancel)
            {
              
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cdriver o = new Cdriver();
            o.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CHR c = new CHR();
            c.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            C_EDIT m = new C_EDIT();
            m.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            C_book p = new C_book();
            p.Show();
            this.Hide();
        }
    }
}
