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
    public partial class Carregistration : Form
    {
        public Carregistration()
        {
            InitializeComponent();
            CarR();
            load();
        
        }

        SqlConnection con = new SqlConnection(@"server=LAPTOP-K0014UM0;database=Carrental;integrated security=true");
        SqlCommand cmd;
        SqlDataReader dr;
        String proid;
        String sql;
        bool Mode = true;
        String id;

        public void CarR()
        {
            sql = "select IdentificadorV from Vehiculo order by IdentificadorV desc";
            cmd = new SqlCommand(sql,con);
            con.Open();
            dr = cmd.ExecuteReader();

            
            if(dr.Read())
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
            textCar.Text = proid.ToString();
            con.Close();

        }

        public void load()
        {
            sql = "select * from Vehiculo";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();
            dataGridView1.Rows.Clear();

            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7], dr[8], dr[9]);
            }
            con.Close();
        }

        public void getid(String id)
        {
            sql = "Select * from Vehiculo where IdentificadorV = '" + id + "' ";
            cmd = new SqlCommand(sql, con);
            
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textCar.Text = dr[0].ToString();
                textDescrip.Text = dr[1].ToString();
                textNChasis.Text = dr[2].ToString();
                textNMotor.Text = dr[3].ToString();
                textLP.Text = dr[4].ToString();
                comboCarT.Text = dr[5].ToString();
                comboBrand.Text = dr[6].ToString();
                comboModel.Text = dr[7].ToString();
                comboTG.Text = dr[8].ToString();
                comboAva.Text = dr[9].ToString();

            }
            con.Close();
        }
       





        private void btn_delete_Click(object sender, EventArgs e)
        {

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            Main back = new Main();
            back.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Carregistration_Load(object sender, EventArgs e)
        {

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            String IdentificadorV = textCar.Text;
            String Descripcion = textDescrip.Text;
            String No_Chasis = textNChasis.Text;
            String No_Motor = textNMotor.Text;
            String No_Placa = textLP.Text;
            String IdentificadorTV = comboCarT.SelectedItem.ToString();
            String IdentificadorM = comboBrand.SelectedItem.ToString();
            String IdentificadorMo = comboModel.SelectedItem.ToString();
            String IdentificadorTC = comboTG.SelectedItem.ToString();
            String Estado = comboAva.SelectedItem.ToString();

            if (Mode == true)
            {
                sql = "Insert into Vehiculo (IdentificadorV, Descripcion, No_Chasis, No_Motor, No_Placa, IdentificadorTV, IdentificadorM, IdentificadorMo, IdentificadorTC, Estado) values (@IdentificadorV, @Descripcion, @No_Chasis, @No_Motor, @No_Placa, @IdentificadorTV, @IdentificadorM, @IdentificadorMo, @IdentificadorTC, @Estado)";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdentificadorV", IdentificadorV);
                cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                cmd.Parameters.AddWithValue("@No_Chasis", No_Chasis);
                cmd.Parameters.AddWithValue("@No_Motor", No_Motor);
                cmd.Parameters.AddWithValue("@No_Placa", No_Placa);
                cmd.Parameters.AddWithValue("@IdentificadorTV", IdentificadorTV);
                cmd.Parameters.AddWithValue("@IdentificadorM", IdentificadorM);
                cmd.Parameters.AddWithValue("@IdentificadorMo", IdentificadorMo);
                cmd.Parameters.AddWithValue("@IdentificadorTC", IdentificadorTC);
                cmd.Parameters.AddWithValue("@Estado", Estado);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Agregado Carrectamente");

                textCar.Clear();
                textDescrip.Clear();
                textLP.Clear();
                textNChasis.Clear();
                textNMotor.Clear();
                comboAva.Items.Clear();
                comboBrand.Items.Clear();
                comboCarT.Items.Clear();
                comboModel.Items.Clear();
                comboTG.Items.Clear();
                textDescrip.Focus();
                CarR();
                
            }
            else
            {
                sql = "Update Vehiculo set Descripcion=@Descripcion, No_Chasis=@No_Chasis, No_Motor=@No_Motor, No_Placa=@No_Placa, IdentificadorTV=@IdentificadorTV, IdentificadorM=@IdentificadorM, IdentificadorMo=@IdentificadorMo, IdentificadorTC =@IdentificadorTC, Estado = @Estado  where IdentificadorV = @IdentificadorV";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdentificadorV", IdentificadorV);
                cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                cmd.Parameters.AddWithValue("@No_Chasis", No_Chasis);
                cmd.Parameters.AddWithValue("@No_Motor", No_Motor);
                cmd.Parameters.AddWithValue("@No_Placa", No_Placa);
                cmd.Parameters.AddWithValue("@IdentificadorTV", IdentificadorTV);
                cmd.Parameters.AddWithValue("@IdentificadorM", IdentificadorM);
                cmd.Parameters.AddWithValue("@IdentificadorMo", IdentificadorMo);
                cmd.Parameters.AddWithValue("@IdentificadorTC", IdentificadorTC);
                cmd.Parameters.AddWithValue("@Estado", Estado);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Actualizado Carrectamente");
                textCar.Enabled = true;
                Mode = true;

                textCar.Clear();
                textDescrip.Clear();
                textLP.Clear();
                textNChasis.Clear();
                textNMotor.Clear();
                comboAva.Items.Clear();
                comboBrand.Items.Clear();
                comboCarT.Items.Clear();
                comboModel.Items.Clear();
                comboTG.Items.Clear();
                textDescrip.Focus();
                CarR();

            }
            con.Close();

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==dataGridView1.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                Mode = false;
                textCar.Enabled = false;
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                getid(id);
            }
            else if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                Mode = false;
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                sql = "delete from Vehiculo Where IdentificadorV = @id";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Delete");
                con.Close();
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            load();
            CarR();
            textCar.Clear();
            textDescrip.Clear();
            textLP.Clear();
            textNChasis.Clear();
            textNMotor.Clear();
            textDescrip.Focus();
            
        }
    }
}
