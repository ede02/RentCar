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
    public partial class Impection : Form
    {
        public Impection()
        {
            InitializeComponent();
            load();
            ImpectionOn();
        }
        SqlConnection con = new SqlConnection(@"server=LAPTOP-K0014UM0;database=Carrental;integrated security = true");
        SqlCommand cmd;
        SqlDataReader dr;
        String proid;
        String sql;
        bool Mode = true;
        String id;

        public void ImpectionOn()
        {
            sql = "select IdentificadorT from Inspeccion order by IdentificadorT desc";
            cmd = new SqlCommand(sql, con);
            con.Open();
             dr = cmd.ExecuteReader();


            if (dr.Read())
            {
                int id = int.Parse(dr[0].ToString()) + 1;
                proid = id.ToString("000");


            }
            else if (Convert.IsDBNull(dr))
            {
                proid = ("000");
            }
            else
            {
                proid = ("000");
            }
            textTransaction.Text = proid.ToString();
            con.Close();

        }

        public void load()
        {
            sql = "select * from Inspeccion";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();
            dataGridView1.Rows.Clear();

            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7], dr[8], dr[9], dr[10]);
            }
            con.Close();
        }

        public void getid(String id)
        {
            sql = "Select * from Inpeccion where IdentificadorT = '" + id + "' ";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                textTransaction.Text = dr[0].ToString();
                textCarId.Text = dr[1].ToString();
                textCustomerId.Text = dr[2].ToString();
                comboScratch.Text = dr[3].ToString();
                comboGasQ.Text = dr[4].ToString();
                comboTools.Text = dr[5].ToString();
                comboWindows.Text = dr[6].ToString();
                comboEmergency.Text = dr[7].ToString();
                dateTimePicker2.Text = dr[8].ToString();
                textEmployedId.Text = dr[9].ToString();
                comboStatus.Text = dr[10].ToString();

            }
            con.Close();
        }
            private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            Main back = new Main();
            back.Show();
        }

        private void Impection_Load(object sender, EventArgs e)
        {

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            String IdentificadorT = textTransaction.Text;
            String IdentificadorV = textCarId.Text;
            String IdentificadorC = textCustomerId.Text;
            String Tiene_Ralladuras = comboScratch.SelectedItem.ToString();
            String Cantidad_Combustible = comboGasQ.SelectedItem.ToString();
            String Tiene_gato = comboTools.SelectedItem.ToString();
            String Tiene_Roturas_Cristal = comboWindows.SelectedItem.ToString();
            String Estados_Gomas = comboEmergency.SelectedItem.ToString();
            String Fecha = dateTimePicker2.Value.Date.ToString("yyy-MM-dd");
            String IdentificadoE = textEmployedId.Text;
            String Estado = comboStatus.SelectedItem.ToString();

            if (Mode == true)
            {
                sql = "Insert into Inspeccion (IdentificadorT, IdentificadorV, IdentificadorC, Tiene_Ralladuras, Cantidad_Combustible, Tiene_gato, Tiene_Roturas_Cristal, Estados_Gomas, Fecha, IdentificadoE, Estado) values (@IdentificadorT, @IdentificadorV, @IdentificadorC, @Tiene_Ralladuras, @Cantidad_Combustible, @Tiene_gato, @Tiene_Roturas_Cristal, @Estados_Gomas, @Fecha, @IdentificadoE, @Estado)";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdentificadorT", IdentificadorT);
                cmd.Parameters.AddWithValue("@IdentificadorV", IdentificadorV);
                cmd.Parameters.AddWithValue("@IdentificadorC", IdentificadorC);
                cmd.Parameters.AddWithValue("@Tiene_Ralladuras", Tiene_Ralladuras);
                cmd.Parameters.AddWithValue("@Cantidad_Combustible", Cantidad_Combustible);
                cmd.Parameters.AddWithValue("@Tiene_gato", Tiene_gato);
                cmd.Parameters.AddWithValue("@Tiene_Roturas_Cristal", Tiene_Roturas_Cristal);
                cmd.Parameters.AddWithValue("@Estados_Gomas", Estados_Gomas);
                cmd.Parameters.AddWithValue("@Fecha", Fecha);
                cmd.Parameters.AddWithValue("@IdentificadoE", IdentificadoE);
                cmd.Parameters.AddWithValue("@Estado", Estado);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Agregado Carrectamente");

                textCarId.Clear();
                textCustomerId.Clear();
                textEmployedId.Clear();
                textTransaction.Clear();
                comboStatus.Items.Clear();
                comboScratch.Items.Clear();
                comboWindows.Items.Clear();
                comboTools.Items.Clear();
                comboGasQ.Items.Clear();
                comboEmergency.Items.Clear();
                textCarId.Focus();
                ImpectionOn();
                con.Close();
            }
            else
            {
                sql = "Update Inspeccion set  IdentificadorV=@IdentificadorV, IdentificadorC=@IdentificadorC, Tiene_Ralladuras=@Tiene_Ralladuras, Cantidad_Combustible=@Cantidad_Combustible, Tiene_gato=@Tiene_gato, Tiene_Roturas_Cristal=@Tiene_Roturas_Cristal, Estados_Gomas =@Estados_Gomas, Fecha=@Fecha, IdentificadoE = @IdentificadoE, Estado = @Estado  where IdentificadorT=@IdentificadorT";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdentificadorT", IdentificadorT);
                cmd.Parameters.AddWithValue("@IdentificadorV", IdentificadorV);
                cmd.Parameters.AddWithValue("@IdentificadorC", IdentificadorC);
                cmd.Parameters.AddWithValue("@Tiene_Ralladuras", Tiene_Ralladuras);
                cmd.Parameters.AddWithValue("@Cantidad_Combustible", Cantidad_Combustible);
                cmd.Parameters.AddWithValue("@Tiene_gato", Tiene_gato);
                cmd.Parameters.AddWithValue("@Tiene_Roturas_Cristal", Tiene_Roturas_Cristal);
                cmd.Parameters.AddWithValue("@Estados_Gomas", Estados_Gomas);
                cmd.Parameters.AddWithValue("@Fecha", Fecha);
                cmd.Parameters.AddWithValue("@IdentificadoE", IdentificadoE);
                cmd.Parameters.AddWithValue("@Estado", Estado);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Agregado Carrectamente");

                cmd.ExecuteNonQuery();
                MessageBox.Show("Actualizado Carrectamente");
                textTransaction.Enabled = true;
                Mode = true;

                textCarId.Clear();
                textCustomerId.Clear();
                textEmployedId.Clear();
                textTransaction.Clear();
                comboStatus.Items.Clear();
                comboScratch.Items.Clear();
                comboWindows.Items.Clear();
                comboTools.Items.Clear();
                comboGasQ.Items.Clear();
                comboEmergency.Items.Clear();
                textCarId.Focus();
                ImpectionOn();
                con.Close();
            }
           
        

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                Mode = false;
                textTransaction.Enabled = false;
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                getid(id);
            }
            else if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                Mode = false;
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                sql = "delete from Inspeccion Where IdentificadorT = @id";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Delete");
                con.Close();
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            load();
            ImpectionOn();
            textCarId.Clear();
            textCustomerId.Clear();
            textEmployedId.Clear();
            textTransaction.Clear();
            textCarId.Focus();

        }
    }
}

