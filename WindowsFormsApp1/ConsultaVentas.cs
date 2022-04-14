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

namespace WindowsFormsApp1
{
    public partial class ConsultaVentas : Form
    {
        public ConsultaVentas()
        {
            InitializeComponent();
        }

        private void ConsultaVentas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'aBARROTESTORODataSet.VENTAS' Puede moverla o quitarla según sea necesario.
            //this.vENTASTableAdapter.Fill(this.aBARROTESTORODataSet.VENTAS);
            button1.Enabled = false;
            Program.menuPrincipal.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Program.menuPrincipal.Show();
            Close();
        }

        private void ConsultaVentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.menuPrincipal.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pRODUCTOSBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.pRODUCTOSBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.aBARROTESTORODataSet);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String consulta = "SELECT * FROM VENTAS WHERE CVEVEN=" + this.consulta.Text;
            SqlConnection connection = Conexion.Connection();
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            tabla.DataSource = dt;
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String consulta = "SELECT * FROM VENTAS";
            SqlConnection connection = Conexion.Connection();
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            tabla.DataSource = dt;
            connection.Close();
        }

        private void consulta_TextChanged(object sender, EventArgs e)
        {
            if (consulta.Text.ToString() != "")
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }
    }
}
