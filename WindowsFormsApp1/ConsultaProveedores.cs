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
    public partial class ConsultaProveedores : Form
    {
        private Boolean ban = true;

        public ConsultaProveedores()
        {
            InitializeComponent();
        }

        private void pROVEEDORBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.pROVEEDORBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.aBARROTESTORODataSet);

        }

        private void ConsultaProveedores_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'aBARROTESTORODataSet.PROVEEDOR' Puede moverla o quitarla según sea necesario.
            //this.pROVEEDORTableAdapter.Fill(this.aBARROTESTORODataSet.PROVEEDOR);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.consulta.Text.ToString() != "")
            {
                String consulta = "SELECT * FROM PROVEEDOR WHERE CLVPROV=" + this.consulta.Text;
                SqlConnection connection = Conexion.Connection();
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(consulta, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                tabla.DataSource = dt;
                connection.Close();
            }
            else
                MessageBox.Show("No puede dejar el campo vacío si va a hacer una consulta");
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ban = false;
            MenuProveedores menuProveedores = new MenuProveedores();
            menuProveedores.Show();
            Close();
        }

        private void ConsultaProveedores_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ban)
            {
                MenuProveedores menuProveedores = new MenuProveedores();
                menuProveedores.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String consulta = "SELECT * FROM PROVEEDOR";
            SqlConnection connection = Conexion.Connection();
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            tabla.DataSource = dt;
            connection.Close();
        }
    }
}
