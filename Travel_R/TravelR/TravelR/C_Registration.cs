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
    public partial class C_Registration : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["cu"].ConnectionString;


        public C_Registration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customer f3 = new Customer();
            f3.Show();
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
            OpenFileDialog ofd= new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "JPG File (*.jpg)| *.jpg";
            //ofd.ShowDialog();
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }

       

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox4.Text != "" && textBox1.Text != "")
            {
                button3.BackColor = Color.Green;
            }
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Red;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            SqlConnection sc = new SqlConnection(cs);
            string query = "insert into customer values (@username, @pass, @fname, @dob, @PHN, @img)";
            SqlCommand cmd = new SqlCommand(query, sc);
            cmd.Parameters.AddWithValue("@username", textBox2.Text);
            cmd.Parameters.AddWithValue("@pass",textBox4.Text);
            cmd.Parameters.AddWithValue("@fname",textBox1.Text);
            cmd.Parameters.AddWithValue("@PHN",textBox3.Text);
            cmd.Parameters.AddWithValue("@dob",dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@img",SaveImage());
            sc.Open();
            var A = cmd.ExecuteNonQuery();
            if(A>0)
            {
                groupBox1.Visible = true;
                pictureBox3.Image = pictureBox1.Image;
                label8.Text = textBox2.Text;
                label5.Text = textBox1.Text;
                label7.Text = textBox3.Text;
                label9.Text = dateTimePicker1.Text;
                pictureBox3.Visible = true;
                label8.Visible = true;
                label5.Visible = true;
                label7.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                button4.Visible = true;
            }
            else 
            {
                MessageBox.Show("Data not inserted......");
            }
            sc.Close();
        }

        private byte[] SaveImage()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
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

        private void button4_Click(object sender, EventArgs e)
        {
            Customer f3 = new Customer();
            f3.Show();
            this.Hide();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if(textBox5.Text!=textBox4.Text)
            {
                textBox5.Focus();
                errorProvider3.Icon = Properties.Resources.Error;
                errorProvider3.SetError(this.textBox5, "Doesn't Match");
                
            }
            else
            {
                errorProvider3.Icon = Properties.Resources.Tick;
                errorProvider3.SetError(this.textBox5, "Matched");
            }
        }

        
    }
}
