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
    public partial class HRR : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["cu"].ConnectionString;
        public HRR()
        {
            InitializeComponent();
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

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "JPG File (*.jpg)| *.jpg";
            //ofd.ShowDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sc = new SqlConnection(cs);
            string query = "insert into HOTEL values (@username, @pass, @addr, @loc, @mob, @web, @hr, @img)";
            SqlCommand cmd = new SqlCommand(query, sc);
            cmd.Parameters.AddWithValue("@username", textBox1.Text);
            cmd.Parameters.AddWithValue("@pass", textBox4.Text);
            cmd.Parameters.AddWithValue("@addr", textBox5.Text);
            cmd.Parameters.AddWithValue("@loc", comboBox1.Text);
            cmd.Parameters.AddWithValue("@mob", textBox2.Text);
            cmd.Parameters.AddWithValue("@web", textBox7.Text);
            cmd.Parameters.AddWithValue("@hr", textBox10.Text);
            cmd.Parameters.AddWithValue("@img", SaveImage());
            sc.Open();
            var A = cmd.ExecuteNonQuery();
            if (A > 0)
            {
                MessageBox.Show("Data Registered...", "Sign Up", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                HRL K = new HRL();
                K.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Data not Registered......","Sign Up", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            sc.Close();
        }

        private byte[] SaveImage()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HRL R = new HRL();
            R.Show();
            this.Close();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if(textBox6.Text==textBox4.Text)
            {
                textBox6.Focus();
                errorProvider1.Icon = Properties.Resources.Tick;
                errorProvider1.SetError(this.textBox6, "Donot match!!!!!");
            }
            else
            {
                errorProvider1.Icon = Properties.Resources.Error;
                errorProvider1.SetError(this.textBox6, "Matched!!!!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            HRL R = new HRL();
            R.Show();
            this.Close();
        }
    }
}
