using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentCar
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Carregistration fm4 = new Carregistration();
            fm4.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Custumer fm5 = new Custumer();
            fm5.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            User fm6 = new User();
            fm6.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Rental fm7 = new Rental();
            fm7.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Impection fm8 = new Impection();
            fm8.Show();
            this.Hide();
        }
    }
}
