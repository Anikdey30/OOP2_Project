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
    
    public partial class GuideR : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["cu"].ConnectionString;
        public GuideR()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GuideL g = new GuideL();
            g.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sc = new SqlConnection(cs);
            string query = "insert into Guide values (@username, @pass, @addr, @mno, @loc, @age, @amnt, @img)";
            SqlCommand cmd = new SqlCommand(query, sc);
            cmd.Parameters.AddWithValue("@username", textBox1.Text);
            cmd.Parameters.AddWithValue("@pass", textBox2.Text);
            cmd.Parameters.AddWithValue("@addr", textBox3.Text);
            cmd.Parameters.AddWithValue("@mno", textBox4.Text);
            cmd.Parameters.AddWithValue("@loc", comboBox1.Text);
            cmd.Parameters.AddWithValue("@age", numericUpDown1.Text);
            cmd.Parameters.AddWithValue("@amnt", textBox7.Text);
            cmd.Parameters.AddWithValue("@img", SaveImage());
            sc.Open();
            var A = cmd.ExecuteNonQuery();
            if (A > 0)
            {
                GuideL g = new GuideL();
                g.Show();
                this.Hide();
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

        private void button1_Click(object sender, EventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
            GuideL g = new GuideL();
            g.Show();
            this.Hide();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == textBox2.Text)
            {
                textBox5.Focus();
                errorProvider1.Icon = Properties.Resources.Tick;
                errorProvider1.SetError(this.textBox5, "Donot match!!!!!");
            }
            else
            {
                errorProvider1.Icon = Properties.Resources.Error;
                errorProvider1.SetError(this.textBox5, "Matched!!!!");
            }
        }
    }
}
