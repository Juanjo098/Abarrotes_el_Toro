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
    public partial class ConsultaCompras : Form
    {

        private Boolean ban = true;

        public ConsultaCompras()
        {
            InitializeComponent();
        }

        private void cOMPRASBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.cOMPRASBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.aBARROTESTORODataSet);

        }

        private void ConsultaCompras_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'aBARROTESTORODataSet.COMPRAS' Puede moverla o quitarla según sea necesario.
            //this.cOMPRASTableAdapter.Fill(this.aBARROTESTORODataSet.COMPRAS);
            button1.Enabled = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ban = false;
            MenuCompras menuCompras = new MenuCompras();
            menuCompras.Show();
            Close();
        }

        private void ConsultaCompras_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ban)
            {
                MenuCompras menuCompras = new MenuCompras();
                menuCompras.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String consulta = "SELECT * FROM COMPRAS WHERE CLVCOM=" + this.consulta.Text;
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
            String consulta = "SELECT * FROM COMPRAS";
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
