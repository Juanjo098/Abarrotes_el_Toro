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
    public partial class DetallesCompras : Form
    {
        public DetallesCompras(int clvcom)
        {
            InitializeComponent();
            llenarEncabezado(clvcom);
            llenarTabla(clvcom);
        }

        private void DetallesCompras_Load(object sender, EventArgs e)
        {

        }

        private void llenarEncabezado(int clvcom)
        {
            String query = "INFOCOMPRA";
            SqlConnection connection = Conexion.Connection();
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CLAVE", clvcom);
            command.Parameters.Add("@FECHACOM", SqlDbType.Date).Direction = ParameterDirection.Output;
            command.Parameters.Add("@TOTALCOM", SqlDbType.Money).Direction = ParameterDirection.Output;
            command.ExecuteNonQuery();
            lClave.Text = "Clave: " + clvcom;
            lFecha.Text = "Fecha: " + Convert.ToDateTime(command.Parameters["@FECHACOM"].Value.ToString()).ToString("dd/MM/yyyy");
            lTotal.Text = "Total: $ " + decimal.Round(Convert.ToDecimal(command.Parameters["@TOTALCOM"].Value.ToString()), 2);
            connection.Close();
        }

        private void llenarTabla(int clvcom)
        {
            String query = "PRODUCTOSCOMP";
            SqlConnection connection = Conexion.Connection();
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CLVCOM", clvcom);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                tabla.Rows.Add();
                tabla[0, tabla.RowCount - 1].Value = reader["CLVPROD"].ToString();
                tabla[1, tabla.RowCount - 1].Value = reader["NOMPRODUCT"].ToString();
                tabla[2, tabla.RowCount - 1].Value = reader["CANTCOM"].ToString();
                tabla[3, tabla.RowCount - 1].Value = decimal.Round(decimal.Parse(reader["TOTAL"].ToString()), 2).ToString();
            }
            connection.Close();
        }

    }
}
