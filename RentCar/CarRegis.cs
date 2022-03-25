using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RentCar
{
    public partial class CarRegis : Form
    {
        public CarRegis()
        {
            InitializeComponent();
            Autono();
        }

        SqlConnection con = new SqlConnection("Data Source=.; Initial Catalog=carrental; User=sa; Password=admin123;");
        SqlCommand cmd;
        SqlDataReader dr;
        string proid;
        string sql;
        string Mode = true;

        public void Autono()
        {
            sql = "select id from regno order by id desc";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();

            if(dr.Read())
            {
                int id = int.Parse(dr[0].ToString()) + 1;
                proid = id.ToString("00000");
            }
            else if (Convert.IsDBNull(dr))
            {
                proid = ("00000");
            }
            else
            {
                proid = ("00000");
            }

            txtReg.Text = proid.ToString();
        }
        private void CarRegis_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string regn = txtReg.Text;
            string brand = txtBrand.Text;
            string model = txtModel.Text;
            string aval = txtAvailable.SelectedItem.ToString();
        }
    }
}
