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
            fecha.Format = DateTimePickerFormat.Short;
            fecha.Value = DateTime.Now;
        }

        private void ConsultaVentas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'aBARROTESTORODataSet.VENTAS' Puede moverla o quitarla según sea necesario.
            //this.vENTASTableAdapter.Fill(this.aBARROTESTORODataSet.VENTAS);
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
            consultaTablaTexto();
        }

        private void consultaTablaTexto()
        {
            if (this.consulta.Text != "")
            {
                SqlConnection connection = Conexion.Connection();
                SqlCommand command;
                connection.Open();
                try
                {
                    command = new SqlCommand("EXISTEVENTA", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@CVEVEN", Convert.ToInt16(consulta.Text));
                    command.Parameters.Add("@BAN", SqlDbType.Int).Direction = ParameterDirection.Output;
                    command.ExecuteNonQuery();
                    if (int.Parse(command.Parameters["@BAN"].Value.ToString()) != 0)
                        new DetalleVentas(Convert.ToInt16(consulta.Text)).ShowDialog();
                    else
                        new Mensaje("No se encontró ninguna venta con la clave que busca", "Venta no encontrada").ShowDialog();
                }
                catch (FormatException ex)
                {
                    new Mensaje("Solo puede introducti números", "Error de formato").ShowDialog();
                }
                consulta.Text = "";
                connection.Close();
            }
            else
            {
                if (dataGridView1.Rows.Count > 0)
                    new DetalleVentas(Convert.ToInt16(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString())).ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String query = "SELECT CVEVEN, FECHAVEN, SUBTOTAL, IVA, (SUBTOTAL + IVA) AS TOTAL FROM VENTAS WHERE FECHAVEN = '" + fecha.Value.ToString("yyyy-MM-dd") + "'";
            SqlConnection connection = Conexion.Connection();
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            dataGridView1.Rows.Clear();

            while (reader.Read())
            {
                dataGridView1.Rows.Add();
                dataGridView1[0, dataGridView1.RowCount - 1].Value = reader[0].ToString();
                dataGridView1[1, dataGridView1.RowCount - 1].Value = Convert.ToDateTime(reader[1].ToString()).ToString("dd/MM/yyyy");
                dataGridView1[2, dataGridView1.RowCount - 1].Value = "$" + decimal.Round(Convert.ToDecimal(reader[2].ToString()), 2);
                dataGridView1[3, dataGridView1.RowCount - 1].Value = "$" + decimal.Round(Convert.ToDecimal(reader[3].ToString()), 2);
                dataGridView1[4, dataGridView1.RowCount - 1].Value = "$" + decimal.Round(Convert.ToDecimal(reader[4].ToString()), 2);
            }

            if (dataGridView1.Rows.Count == 0)
                new Mensaje("No se encontraron ventas en la fecha " + fecha.Value.ToString("dd/MM/yyyy"), "Venta no encontrada").ShowDialog();
        }

        private void consulta_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
