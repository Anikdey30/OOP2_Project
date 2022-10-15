using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelR
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
        private void label1_MouseHover(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Red;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Fuchsia;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            TAL t = new TAL();
            t.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Customer f3 = new Customer();
            f3.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            GuideL g = new GuideL();
            g.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            DriverL c = new DriverL();
            c.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            HRL l = new HRL();
            l.Show();
            this.Hide();
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Red;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Fuchsia;

        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Red;

        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Fuchsia;


        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Red;

        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Fuchsia;

        }

        private void label5_MouseHover(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Red;

        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Fuchsia;

        }
    }
}
