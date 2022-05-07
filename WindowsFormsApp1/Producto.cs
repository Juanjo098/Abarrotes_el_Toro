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
    public partial class Producto : Form
    {
        private Boolean ban = true;
        private String funcion;
        private SqlConnection connection = Conexion.Connection();

        public Producto(String funcion)
        {
            this.funcion = funcion;
            InitializeComponent();
            setearBotones();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MenuProductos menuProductos = new MenuProductos();
            menuProductos.Show();
            ban = false;
            Close();
        }

        private void Producto_Load(object sender, EventArgs e)
        {

        }

        private void Producto_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ban)
            {
                MenuProductos menuProductos = new MenuProductos();
                menuProductos.Show();
            }
        }

        private void setearBotones()
        {
            switch (funcion)
            {
                case "insertar":
                    insertar.Enabled = true;
                    eliminar.Enabled = false;
                    modificar.Enabled = false;
                    consultar.Enabled = true;
                    clave.Enabled = false;
                    prccomp.Enabled = false;
                    prcvent.Enabled = false;
                    gan.Enabled = false;
                    exi.Enabled = false;
                    ultimoProducto();
                    break;
                case "modificar":
                    insertar.Enabled = false;
                    eliminar.Enabled = false;
                    modificar.Enabled = false;
                    consultar.Enabled = true;
                    nom.Enabled = false;
                    prccomp.Enabled = false;
                    prcvent.Enabled = false;
                    exi.Enabled = false;
                    gan.Enabled = false;
                    break;
                case "eliminar":
                    insertar.Enabled = false;
                    eliminar.Enabled = false;
                    modificar.Enabled = false;
                    consultar.Enabled = true;
                    nom.Enabled = false;
                    prccomp.Enabled = false;
                    prcvent.Enabled = false;
                    exi.Enabled = false;
                    gan.Enabled = false;
                    break;
            }
        }

        private void ultimoProducto()
        {
            SqlCommand command;
            connection.Open();
            command = new SqlCommand("ULTIMACLVPROD", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CLVPROD", SqlDbType.Int).Direction = ParameterDirection.Output;
            command.ExecuteNonQuery();
            clave.Text = command.Parameters["@CLVPROD"].Value.ToString();
            connection.Close();
        }

        private void insertar_Click(object sender, EventArgs e)
        {
            Boolean ban = false;
            SqlCommand command;
            connection.Open();
            command = new SqlCommand("INSERTAPRODUCTOS", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@NOMPRODUCT", nom.Text.ToUpper());
            command.Parameters.AddWithValue("@CLVPROD", clave.Text.ToUpper());
            command.Parameters.Add("@BAN", SqlDbType.Int).Direction = ParameterDirection.Output;
            command.ExecuteNonQuery();
            switch (Convert.ToInt32(command.Parameters["@BAN"].Value.ToString()))
            {
                case 1:
                    new Mensaje("Debe ingresar el nombre del producto", "Error").ShowDialog();
                    break;
                case 2:
                    new Mensaje("Ya existe un producto con ese nombre", "Error").ShowDialog();
                    break;
                default:
                    ban = true;
                    break;
            }
            connection.Close();
            if (ban)
            {
                new MensajeCorrecto("Producto registrado correctamente", "Insersión correcta").ShowDialog();
                nom.Text = "";
                ultimoProducto();
            }

        }

        private void consultar_Click(object sender, EventArgs e)
        {
            SqlCommand command;
            SqlDataReader reader;
            connection.Open();
            command = new SqlCommand("SELECT * FROM PRODUCTOS WHERE CLVPROD =" + clave.Text, connection);
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                nom.Text = reader["NOMPRODUCT"].ToString();
                prcvent.Text = reader["PRECIOVEN"].ToString();
                prccomp.Text = reader["PRECIOCOM"].ToString();
                exi.Text = reader["EXIST"].ToString();
                gan.Text = reader["GANAN"].ToString();
                if (funcion == "modificar")
                {
                    modificar.Enabled = true;
                    nom.Enabled = true;
                    prccomp.Enabled = true;
                    gan.Enabled = true;
                    clave.Enabled = false;
                    consultar.Enabled = false;
                }
            }
            else
                new Mensaje("No se encontró ningún producto con esa clave", "Error").ShowDialog();
            connection.Close();
        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            Boolean ban = false;
            SqlCommand command;
            connection.Open();
            command = new SqlCommand("ELIMINARPROD", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CLVPROD", clave.Text.ToUpper());
            command.Parameters.Add("@BAN", SqlDbType.Int).Direction = ParameterDirection.Output;
            command.ExecuteNonQuery();
            switch (Convert.ToInt32(command.Parameters["@BAN"].Value.ToString()))
            {
                case 1:
                    new Mensaje("No se encontró ningún producto con la clave que busca", "Error").ShowDialog();
                    break;
                default:
                    ban = true;
                    break;
            }
            connection.Close();
            if (ban)
            {
                new MensajeCorrecto("Producto eliminado correctamente", "Eliminación correcta").ShowDialog();
                clave.Text = "";
                nom.Text = "";
                prccomp.Text = "";
                prcvent.Text = "";
                exi.Text = "";
                gan.Text = "";
            }
        }

        private void modificar_Click(object sender, EventArgs e)
        {
            Boolean ban = false;
            SqlCommand command;
            connection.Open();
            command = new SqlCommand("ACTUALIZARPORD", connection);
            try
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CLVPROD", clave.Text);
                command.Parameters.AddWithValue("@NOMPRODUCT", nom.Text.ToUpper());
                command.Parameters.AddWithValue("@PRECIOCOMP", Convert.ToDecimal(prccomp.Text));
                command.Parameters.AddWithValue("@GANAN", Convert.ToDecimal(gan.Text));
                command.Parameters.Add("@BAN", SqlDbType.Int).Direction = ParameterDirection.Output;
                command.ExecuteNonQuery();
                switch (Convert.ToInt32(command.Parameters["@BAN"].Value.ToString()))
                {
                    case 1:
                        new Mensaje("La ganancia debe ser mayor a 0", "Error").ShowDialog();
                        break;
                    case 2:
                        new Mensaje("El precio de compra debe ser mayoy a 0", "Error").ShowDialog();
                        break;
                    case 3:
                        new Mensaje("El nombre no puede quedar vacío", "Error").ShowDialog();
                        break;
                    case 4:
                        new Mensaje("No se encontró ningún producto con la clave que busca", "Error").ShowDialog();
                        break;
                    default:
                        ban = true;
                        break;
                }
                connection.Close();
                if (ban)
                {
                    new MensajeCorrecto("Producto modificado correctamente", "Modificación realizada").ShowDialog();
                    modificar.Enabled = false;
                    consultar.Enabled = true;
                    nom.Enabled = false;
                    prccomp.Enabled = false;
                    gan.Enabled = false;
                    clave.Enabled = true;
                }
            }
            catch (FormatException ex)
            {
                connection.Close();
                new Mensaje("El precio y la ganancia deben ser valores númericos mayores a  0", "").ShowDialog();
            }


            
        }
    }
}
