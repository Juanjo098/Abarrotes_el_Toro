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
    public partial class RegistrarCompras : Form
    {
        private Boolean ban = true;
        private SqlConnection connection = Conexion.Connection();
        public RegistrarCompras()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ban = false;
            MenuCompras menuCompras = new MenuCompras();
            menuCompras.Show();
            Close();
        }

        private void RegistrarCompras_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ban)
            {
                MenuCompras menuCompras = new MenuCompras();
                menuCompras.Show();
            }
        }

        private void obtenerClaveCompra()
        {
            int clvCompra;
            connection.Open();
            SqlCommand command = new SqlCommand("ULTIMACLVCOMPRA", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CLVCOM", SqlDbType.Int).Direction = ParameterDirection.Output;
            command.ExecuteNonQuery();
            clvCompra = int.Parse(command.Parameters["@CLVCOM"].Value.ToString());
            clave.Text = clvCompra.ToString();
            connection.Close();
        }

        private void llenarComboBox()
        {
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT NOMDIST FROM PROVEEDOR", connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                proveedores.Items.Add(reader["NOMDIST"].ToString());
            }
            reader.Close();
            connection.Close();
        }

        private void nombreProveedor()
        {
            connection.Open();
            SqlCommand command = new SqlCommand("NOMBREPROV", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@NOMDIST", proveedores.Text);
            command.Parameters.Add("@CLVPROV", SqlDbType.Int).Direction = ParameterDirection.Output;
            command.ExecuteNonQuery();
            nombreProv.Text = command.Parameters["@CLVPROV"].Value.ToString();
            connection.Close();
        }

        private void RegistrarCompras_Load(object sender, EventArgs e)
        {
            obtenerClaveCompra();
            llenarComboBox();
            proveedores.DropDownStyle = ComboBoxStyle.DropDownList;
            proveedores.SelectedIndex = 0;
        }

        private void proveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            nombreProveedor();
        }

        private Boolean claveInsertada()
        {
            return claveProd.Text != "";
        }

        private Boolean existe(String clv)
        {
            for (int i = 0; i < tabla.RowCount; i++)
                if (clv.Equals(tabla[0, i].Value.ToString()))
                    return true;
            return false;
        }

        private void acualizarTotal()
        {
            decimal total = 0;
            for (int i = 0; i < tabla.Rows.Count; i++)
                total += decimal.Parse(tabla[3, i].Value.ToString()) * int.Parse(tabla[1, i].Value.ToString());
            this.total.Text = total.ToString();
        }

        private void claveProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                addFila();
            }
        }

        private void tabla_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                int cantidad;
                try
                {
                    cantidad = int.Parse(tabla.CurrentCell.Value.ToString());
                    if (cantidad < 1)
                    {
                        new Mensaje("No se puede ingresar un número menor a 1", "Error").ShowDialog();
                        tabla.CurrentCell.Value = 1;
                    }
                    acualizarTotal();
                }
                catch (FormatException ex)
                {
                    new Mensaje("Sólo puede ingresar números en esta celda", "Error").ShowDialog();
                    tabla.CurrentCell.Value = 1;
                    acualizarTotal();
                }
            }
            else
            {
                float cantidad;
                try
                {
                    cantidad = float.Parse(tabla.CurrentCell.Value.ToString());
                    if (cantidad < 0)
                    {
                        new Mensaje("No se puede ingresar un número menor a 0", "Error").ShowDialog();
                        tabla.CurrentCell.Value = 1;
                    }
                    acualizarTotal();
                }
                catch (FormatException ex)
                {
                    new Mensaje("Sólo puede ingresar números en esta celda", "Error").ShowDialog();
                    tabla.CurrentCell.Value = 1;
                    acualizarTotal();
                }
            }
        }

        private String confirmarProveedor()
        {
            String errors = "";
            connection.Open();
            SqlCommand command;
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                int estado;
                command = new SqlCommand("PRODPROV", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CLVPROD", tabla[0, i].Value.ToString());
                command.Parameters.AddWithValue("@CLVPROV", nombreProv.Text.ToString());
                command.Parameters.Add("@BAN", SqlDbType.Int).Direction = ParameterDirection.Output;
                command.ExecuteNonQuery();
                estado = int.Parse(command.Parameters["@BAN"].Value.ToString());
                if (estado == 0)
                    errors += "-" + tabla[2, i].Value.ToString() + "\n";
            }
            connection.Close();
            return errors;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String errors = confirmarProveedor();
            if (tabla.Rows.Count > 0)
            {
                if (errors == "")
                {
                    SqlCommand command;
                    String prov = nombreProv.Text;
                    connection.Open();

                    command = new SqlCommand("INTERTACOMPRA", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PROV", prov);
                    command.Parameters.Add("@BAN", SqlDbType.Int).Direction = ParameterDirection.Output;
                    command.ExecuteNonQuery();

                    for (int i = 0; i < tabla.RowCount; i++)
                    {
                        command = new SqlCommand("INTERTAPRODCOM", connection);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CLVCOM", int.Parse(clave.Text));
                        command.Parameters.AddWithValue("@CLVPROD", int.Parse(tabla[0, i].Value.ToString()));
                        command.Parameters.AddWithValue("@CANTCOM", int.Parse(tabla[1, i].Value.ToString()));
                        command.Parameters.AddWithValue("@PRECIOCOM", decimal.Parse(tabla[3, i].Value.ToString()));
                        command.Parameters.AddWithValue("@GANAN", decimal.Parse(tabla[4, i].Value.ToString()));
                        command.Parameters.Add("@BAN", SqlDbType.Int).Direction = ParameterDirection.Output;
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                    obtenerClaveCompra();
                    acualizarTotal();
                    tabla.Rows.Clear();
                    new MensajeCorrecto("Compra registrada exitosamente", "Inserción realizada").ShowDialog();
                }
                else
                {
                    new Mensaje("Los siguientes productos no son venidos por el proveedor selecionado\n" + errors, "Error").ShowDialog();
                }
            }
            else
                new Mensaje("Debes añadir por lo menos un registro para hacer la compra", "Error").ShowDialog();
        }

        private void tabla_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                removeFila();
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            addFila();
        }

        private void addFila()
        {
            if (claveInsertada())
            {
                SqlCommand command = new SqlCommand("SELECT CLVPROD, NOMPRODUCT, PRECIOCOM, GANAN FROM PRODUCTOS WHERE CLVPROD =" + claveProd.Text, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    if (!existe(reader["CLVPROD"].ToString()))
                    {
                        decimal d = decimal.Round(Convert.ToDecimal(reader["PRECIOCOM"].ToString()), 2);
                        decimal g = decimal.Round(Convert.ToDecimal(reader["GANAN"].ToString()), 2);
                        if (d == 0) d = 1;
                        if (g == 0) g = 1;
                        tabla.Rows.Add();
                        tabla[0, tabla.RowCount - 1].Value = reader["CLVPROD"].ToString();
                        tabla[1, tabla.RowCount - 1].Value = 1;
                        tabla[2, tabla.RowCount - 1].Value = reader["NOMPRODUCT"].ToString();
                        tabla[3, tabla.RowCount - 1].Value = d.ToString();
                        tabla[4, tabla.RowCount - 1].Value = g.ToString();
                        claveProd.Text = "";
                        acualizarTotal();
                    }
                    reader.Close();
                }
                connection.Close();
            }

        }

        private void removeFila()
        {
            if (tabla.RowCount > 0)
            {
                tabla.Rows.RemoveAt(tabla.CurrentCell.RowIndex);
                acualizarTotal();
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            removeFila();
        }
    }
}
