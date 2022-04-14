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
    public partial class Pos : Form
    {
        public Pos()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Close();
            Program.menuPrincipal.Show();
        }

        private void Pos_Load(object sender, EventArgs e)
        {
            Program.menuPrincipal.Hide();
        }

        private void Pos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.menuPrincipal.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = Conexion.Connection();
            SqlCommand command = new SqlCommand("SELECT CLVPROD, NOMPRODUCT, PRECIOVEN FROM PRODUCTOS WHERE CLVPROD =" + claveProd.Text, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                MessageBox.Show(reader["NOMPRODUCT"].ToString());
            }
        }
    }
}
