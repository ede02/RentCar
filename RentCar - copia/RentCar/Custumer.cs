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
    public partial class Custumer : Form
    {
        public Custumer()
        {
            InitializeComponent();
            CustomerOn();
            load2();  
        }

        SqlConnection con = new SqlConnection(@"server=LAPTOP-K0014UM0;database=Carrental;integrated security=true");
        SqlCommand cmd;
        SqlDataReader dr;
        String proid;
        String sql;
        bool Mode = true;
        String id;


        public void CustomerOn()
        {
            sql = "select IdentificadorC from Cliente order by IdentificadorC desc";
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
            textIdentifier.Text = proid.ToString();
            con.Close();

        }
        
        public void load2()
        {
            sql = "select * from Cliente";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();
            dataGridView1.Rows.Clear();

            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6]);
            }
            con.Close();
        }

        public void getid2(String id)
        {
            sql = "Select * from Cliente where IdentificadorC = '" + id + "' ";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                textIdentifier.Text = dr[0].ToString();
                textname.Text = dr[1].ToString();
                textcedula.Text = dr[2].ToString();
                textCard.Text = dr[3].ToString();
                textCredit.Text = dr[4].ToString();
                comboPerson.Text = dr[5].ToString();
                comboStatus.Text = dr[6].ToString();
                

            }
            con.Close();
        }



        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            Main back = new Main();
            back.Show();
        }

        private void Custumer_Load(object sender, EventArgs e)
        {

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            String IdentificadorC = textIdentifier.Text;
            String Nombre = textname.Text;
            String Cedula = textcedula.Text;
            String No_Tarjeta_CR = textCard.Text;
            String Limite_CR = textCredit.Text;
            String Tipo_Persona = comboPerson.SelectedItem.ToString();
            String Estado = comboStatus.SelectedItem.ToString();

            if(Mode == true)
            {
                sql = "Insert into Cliente (IdentificadorC, Nombre, Cedula, No_Tarjeta_CR, Limite_CR, Tipo_Persona, Estado) values (@IdentificadorC, @Nombre, @Cedula, @No_Tarjeta_CR, @Limite_CR, @Tipo_Persona, @Estado)";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdentificadorC", IdentificadorC);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Cedula", Cedula);
                cmd.Parameters.AddWithValue("@No_Tarjeta_CR", No_Tarjeta_CR);
                cmd.Parameters.AddWithValue("@Limite_CR", Limite_CR);
                cmd.Parameters.AddWithValue("@Tipo_Persona", Tipo_Persona);
                cmd.Parameters.AddWithValue("@Estado", Estado);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Agregado Carrectamente");


                textIdentifier.Clear();
                textcedula.Clear();
                textname.Clear();
                textCard.Clear();
                textCredit.Clear();
                comboPerson.Items.Clear();
                comboStatus.Items.Clear();
                textname.Focus();
                CustomerOn();
            }
        
            else
            {
                sql = "update Cliente set  Nombre=@Nombre, Cedula=@Cedula, No_Tarjeta_CR=@No_Tarjeta_CR, Limite_CR=@Limite_CR, Tipo_Persona=@Tipo_Persona, Estado=@Estado where IdentificadorC=@IdentificadorC";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@IdentificadorC", IdentificadorC);
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                cmd.Parameters.AddWithValue("@Cedula", Cedula);
                cmd.Parameters.AddWithValue("@No_Tarjeta_CR", No_Tarjeta_CR);
                cmd.Parameters.AddWithValue("@Limite_CR", Limite_CR);
                cmd.Parameters.AddWithValue("@Tipo_Persona", Tipo_Persona);
                cmd.Parameters.AddWithValue("@Estado", Estado);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Actualizado Carrectamente");
                textIdentifier.Enabled = true;
                Mode = true;

                textIdentifier.Clear();
                textcedula.Clear();
                textname.Clear();
                textCard.Clear();
                textCredit.Clear();
                comboPerson.Items.Clear();
                comboStatus.Items.Clear();
                textname.Focus();
                CustomerOn();

            }
            con.Close();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            load2();
            CustomerOn();
            textIdentifier.Clear();
            textcedula.Clear();
            textname.Clear();
            textCard.Clear();
            textCredit.Clear();
            textname.Focus();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index && e.RowIndex >= 0)
            {
                Mode = false;
                textIdentifier.Enabled = false;
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                getid2(id);
            }
            else if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                Mode = false;
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                sql = "delete from Cliente Where IdentificadorC = @id";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Delete");
                con.Close();
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {

        }
    }
}
