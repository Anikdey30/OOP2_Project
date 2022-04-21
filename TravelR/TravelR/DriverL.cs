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
    
    public partial class DriverL : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["cu"].ConnectionString;
        public static string lname;
        public static string pname;

        public DriverL()
        {
            InitializeComponent();
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            DriverR d = new DriverR();
            d.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" || textBox1.Text != "")
            {
                SqlConnection sql = new SqlConnection(cs);
                string q = "SELECT * FROM DRIVE WHERE USERNAME=@USERNAME AND PASS=@PASS";
                SqlCommand s = new SqlCommand(q, sql);
                s.Parameters.AddWithValue("@USERNAME", textBox1.Text);
                s.Parameters.AddWithValue("@PASS", textBox2.Text);
                sql.Open();
                SqlDataReader d = s.ExecuteReader();
                if (d.HasRows == true)
                {
                    pname = textBox2.Text;
                    lname = textBox1.Text;
                    Driver f = new Driver();
                    f.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login Failed!!!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                sql.Close();
                textBox2.Clear();
                textBox1.Clear();
                errorProvider1.Clear();
                errorProvider2.Clear();
            }
            else
            {
                MessageBox.Show("Please Fill Both Fields!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 p = new Form2();
            p.Show();
            this.Hide();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool status = checkBox1.Checked;
            switch (status)
            {
                case true:
                    textBox2.UseSystemPasswordChar = false;
                    break;
                default:
                    textBox2.UseSystemPasswordChar = true;
                    break;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider1.Icon = Properties.Resources.Error;
                errorProvider1.SetError(this.textBox1, "Please fill the field!");
            }
            else
            {
                errorProvider1.Icon = Properties.Resources.Tick;
                errorProvider1.SetError(this.textBox1, "Filled");
                textBox2.Focus();
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) == true)
            {
                textBox2.Focus();
                errorProvider2.Icon = Properties.Resources.Error;
                errorProvider2.SetError(this.textBox2, "Please fill the field!");
            }
            else
            {
                errorProvider2.Icon = Properties.Resources.Tick;
                errorProvider2.SetError(this.textBox2, "Filled");
                
            }
        }
    }
}
