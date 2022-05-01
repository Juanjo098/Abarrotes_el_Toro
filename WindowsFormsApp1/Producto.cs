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
                    MessageBox.Show("Debe ingresar el nombre del producto");
                    break;
                case 2:
                    MessageBox.Show("Ya existe un producto con ese nombre");
                    break;
                default:
                    ban = true;
                    break;
            }
            connection.Close();
            if (ban)
            {
                MessageBox.Show("Producto registrado correctamente");
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
                MessageBox.Show("No se encontró ningún producto con esa clave");
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
                    MessageBox.Show("No se encontró ningún producto con la clave que busca");
                    break;
                default:
                    ban = true;
                    break;
            }
            connection.Close();
            if (ban)
            {
                MessageBox.Show("Producto eliminado correctamente");
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
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CLVPROD", clave.Text);
            command.Parameters.AddWithValue("@NOMPRODUCT", clave.Text.ToUpper());
            command.Parameters.AddWithValue("@PRECIOCOMP", Convert.ToDecimal(prccomp.Text));
            command.Parameters.AddWithValue("@GANAN", Convert.ToDecimal(gan.Text));
            command.Parameters.Add("@BAN", SqlDbType.Int).Direction = ParameterDirection.Output;
            command.ExecuteNonQuery();
            switch (Convert.ToInt32(command.Parameters["@BAN"].Value.ToString()))
            {
                case 1:
                    MessageBox.Show("La ganancia debe ser mayor a 0");
                    break;
                case 2:
                    MessageBox.Show("El precio de compra debe ser mayoy a 0");
                    break;
                case 3:
                    MessageBox.Show("El nombre no puede quedar vacío");
                    break;
                case 4:
                    MessageBox.Show("No se encontró ningún producto con la clave que busca");
                    break;
                default:
                    ban = true;
                    break;
            }
            connection.Close();
            if (ban)
            {
                MessageBox.Show("Producto modificado correctamente");
                modificar.Enabled = false;
                consultar.Enabled = true;
                nom.Enabled = false;
                prccomp.Enabled = false;
                gan.Enabled = false;
                clave.Enabled = true;
            }
        }
    }
}
