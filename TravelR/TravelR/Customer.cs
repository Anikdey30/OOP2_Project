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
    
    public partial class Customer : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["cu"].ConnectionString;
        public static string loginuser;
        public static string passuser;
        public Customer()
        {
            InitializeComponent();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox4.Text != "")
            {
                button1.BackColor = Color.Lime;
            }
            else
            {
                button1.BackColor = Color.Red;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool status = checkBox1.Checked;
            switch (status)
            {
                case true:
                    textBox4.UseSystemPasswordChar = false;
                    break;
                default:
                    textBox4.UseSystemPasswordChar = true;
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            C_Registration c = new C_Registration();
            c.Show();
            this.Hide();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text) == true)
            {
                textBox2.Focus();
                errorProvider1.Icon = Properties.Resources.Error;
                errorProvider1.SetError(this.textBox2, "Please fill the field!");
            }
            else
            {
                errorProvider1.Icon = Properties.Resources.Tick;
                errorProvider1.SetError(this.textBox2, "Filled");
                textBox4.Focus();
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text) == true)
            {
                textBox4.Focus();
                errorProvider2.Icon = Properties.Resources.Error;
                errorProvider2.SetError(this.textBox4, "Please fill the field!");
            }
            else
            {
                errorProvider2.Icon = Properties.Resources.Tick;
                errorProvider2.SetError(this.textBox4, "Filled");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" || textBox4.Text != "")
            {
                SqlConnection sql = new SqlConnection(cs);
                string q = "SELECT * FROM CUSTOMER WHERE USERNAME=@USERNAME AND PASS=@PASS";
                SqlCommand s = new SqlCommand(q, sql);
                s.Parameters.AddWithValue("@USERNAME", textBox2.Text);
                s.Parameters.AddWithValue("@PASS", textBox4.Text);
                sql.Open();
                SqlDataReader d = s.ExecuteReader();
                if (d.HasRows == true)
                {
                    loginuser = textBox2.Text;
                    passuser = textBox4.Text;
                    CS_MAIN c = new CS_MAIN();
                    c.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login Failed!!!", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                sql.Close();
                textBox2.Clear();
                textBox4.Clear();
            }
            else
            {
                MessageBox.Show("Please Fill Both Fields!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
