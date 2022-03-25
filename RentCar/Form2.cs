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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string uname = txtUsername.Text;
            string pass = txtPass.Text;

            if (uname.Equals("Admin") && pass.Equals("123"))
            {
                
                Main fm3 = new Main();
                fm3.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("fail");
                txtUsername.Clear();
                txtPass.Clear();
                txtUsername.Focus();
            }
                    

            
                


           


        }
    }
}
