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
    public partial class Guide : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["cu"].ConnectionString;

        public Guide()
        {
            InitializeComponent();
            label6.Text = GuideL.uname;
            BindGridView();
            BindGridView2();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sc = new SqlConnection(cs);
            string query = "update Guide set addr=@addr, mno=@mno, loc=@loc, age=@age, amnt=@amnt,img=@img where username=@username and pass=@pass";
            SqlCommand cmd = new SqlCommand(query, sc);
            cmd.Parameters.AddWithValue("@addr", textBox3.Text);
            cmd.Parameters.AddWithValue("@mno", textBox4.Text);
            cmd.Parameters.AddWithValue("@loc", comboBox1.Text);
            cmd.Parameters.AddWithValue("@age", numericUpDown1.Text);
            cmd.Parameters.AddWithValue("@amnt", textBox7.Text);
            cmd.Parameters.AddWithValue("@username", GuideL.uname);
            cmd.Parameters.AddWithValue("@pass", GuideL.pname);
            cmd.Parameters.AddWithValue("@img", SaveImage());
            sc.Open();
            var A = cmd.ExecuteNonQuery();
            if (A > 0)
            {
                MessageBox.Show("Data updated successfully......", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BindGridView();
            }
            else
            {
                MessageBox.Show("Data not updated......", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            sc.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox4.Clear();
            textBox7.Clear();
            numericUpDown1.Value = 0;
            comboBox1.Text = "";
            pictureBox1.Image = Properties.Resources._21104;
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

        void BindGridView()
        {
            //Connection
            SqlConnection sql = new SqlConnection(cs);
            string q = "select addr,mno,loc,age,amnt,img from Guide where username='" + GuideL.uname + "'" + "and pass='" + GuideL.pname + "'";
            SqlDataAdapter sda = new SqlDataAdapter(q, sql);

            //data Grid view display
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            //image layout fit
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[5];
            dgv.ImageLayout = DataGridViewImageCellLayout.Zoom;

            //Table layout fit
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //TAble Height
            dataGridView1.RowTemplate.Height = 50;
        }
        private byte[] SaveImage()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            numericUpDown1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            pictureBox1.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[5].Value);
        }

        

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection sc = new SqlConnection(cs);
            string query = "delete from Book where sname=@sname";
            SqlCommand cmd = new SqlCommand(query, sc);
            cmd.Parameters.AddWithValue("@username", dataGridView2.SelectedRows[0].Cells[1].Value.ToString());
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

        

        
        void BindGridView2()
        {
            //Connection
            SqlConnection sql = new SqlConnection(cs);
            string q = "select * from Book where sname='" + GuideL.uname + "'";
            SqlDataAdapter sda = new SqlDataAdapter(q, sql);

            //data Grid view display
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView2.DataSource = data;



            //Table layout fit
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //TAble Height
            dataGridView2.RowTemplate.Height = 50;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GuideL g = new GuideL();
            g.Show();
            this.Hide();
        }
    }
}
