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
    public partial class DetalleVentas : Form
    {
        private SqlConnection connection;
        private SqlDataReader reader;
        private SqlCommand command;

        public DetalleVentas(int cveven)
        {
            connection = Conexion.Connection();
            connection.Open();
            InitializeComponent();
            llenarEncabezado(cveven);
            llenarTabla(cveven);
            connection.Close();
        }

        private void DetalleVentas_Load(object sender, EventArgs e)
        {

        }

        private void llenarEncabezado(int cveven)
        {
            DateTime date;
            command = new SqlCommand("INFOVENTA", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@SUBTOTAL", SqlDbType.Money).Direction = ParameterDirection.Output;
            command.Parameters.Add("@IVA", SqlDbType.Money).Direction = ParameterDirection.Output;
            command.Parameters.Add("@FECHAVEN", SqlDbType.Date).Direction = ParameterDirection.Output;
            command.Parameters.AddWithValue("@CVEVEN", cveven);
            command.ExecuteNonQuery();
            lClave.Text = "Clave: " + cveven;

            date = Convert.ToDateTime(command.Parameters["@FECHAVEN"].Value.ToString());
            lFecha.Text = "Fecha: " + date.ToString("dd-MM-yyyy");
            lSubtotal.Text = "Subtotal: $" + decimal.Round(Convert.ToDecimal(command.Parameters["@SUBTOTAL"].Value.ToString()), 2);
            lIva.Text = "IVA: $" + decimal.Round(Convert.ToDecimal(command.Parameters["@IVA"].Value.ToString()), 2);
            lTotal.Text = "Total: $" + decimal.Round(Convert.ToDecimal(command.Parameters["@SUBTOTAL"].Value.ToString()) +
                Convert.ToDecimal(command.Parameters["@IVA"].Value.ToString()), 2);
        }

        private void llenarTabla(int cveven)
        {
            command = new SqlCommand("PRODUCTOSVEND", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CVEVEN", cveven);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                tabla.Rows.Add();
                tabla[0, tabla.RowCount - 1].Value = reader["CLVPROD"].ToString();
                tabla[1, tabla.RowCount - 1].Value = reader["NOMPRODUCT"].ToString();
                tabla[2, tabla.RowCount - 1].Value = reader["CANTIDADVEN"].ToString();
                tabla[3, tabla.RowCount - 1].Value = "$" + decimal.Round(decimal.Parse(reader["TOTAL"].ToString()), 2).ToString();
            }
        }
    }
}
