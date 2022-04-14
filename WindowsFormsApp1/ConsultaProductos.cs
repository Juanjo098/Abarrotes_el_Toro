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
    public partial class ConsultaProductos : Form
    {
        private Boolean ban = true;

        public ConsultaProductos()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ban = false;
            MenuProductos menuProductos = new MenuProductos();
            menuProductos.Show();
            Close();
        }

        private void ConsultaProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ban)
            {
                MenuProductos menuProductos = new MenuProductos();
                menuProductos.Show();
            }
        }

        private void pRODUCTOSBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.pRODUCTOSBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.aBARROTESTORODataSet);

        }

        private void ConsultaProductos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'aBARROTESTORODataSet.PRODUCTOS' Puede moverla o quitarla según sea necesario.
            //this.pRODUCTOSTableAdapter.Fill(this.aBARROTESTORODataSet.PRODUCTOS);
            button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String consulta = "SELECT * FROM PRODUCTOS WHERE CLVPROD=" + this.consulta.Text;
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
            String consulta = "SELECT * FROM PRODUCTOS";
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
