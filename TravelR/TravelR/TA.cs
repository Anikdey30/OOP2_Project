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
    public partial class TA : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["cu"].ConnectionString;

        public TA()
        {
            InitializeComponent();
            BindGridView();
            BindGridView2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "JPG File (*.jpg) | *.jpg";
            
            //ofd.ShowDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            comboBox1.Text="";
            pictureBox1.Image = Properties.Resources._21104;
            
        }


        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sc = new SqlConnection(cs);
            string query = "update TA set addr=@addr, loc=@loc, mob=@mob, web=@web, place=@place, amnt=@amnt, img=@img where username=@username and pass=@pass";
            SqlCommand cmd = new SqlCommand(query, sc);
            cmd.Parameters.AddWithValue("@username", TAL.uname);
            cmd.Parameters.AddWithValue("@pass", TAL.passn);
            cmd.Parameters.AddWithValue("@addr", textBox3.Text);
            cmd.Parameters.AddWithValue("@loc", comboBox1.Text);
            cmd.Parameters.AddWithValue("@mob", textBox4.Text);
            cmd.Parameters.AddWithValue("@web", textBox6.Text);
            cmd.Parameters.AddWithValue("@place", textBox5.Text);
            cmd.Parameters.AddWithValue("@amnt", textBox7.Text);
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

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            pictureBox1.Image = GetPhoto((byte[])dataGridView1.SelectedRows[0].Cells[6].Value);
        }
        void BindGridView()
        {
            //Connection
            SqlConnection sql = new SqlConnection(cs);
            string q = "select addr, loc, mob, web, place, amnt, img from TA where username='" + TAL.uname + "'" + "and pass='" + TAL.passn + "'";
            SqlDataAdapter sda = new SqlDataAdapter(q, sql);

            //data Grid view display
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            //image layout fit
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[6];
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

        void BindGridView2()
        {
            //Connection
            SqlConnection sql = new SqlConnection(cs);
            string q = "select * from Book where sname='" + TAL.uname + "'";
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
            TAL i = new TAL();
            i.Show();
            this.Hide();
        }
    }
}
