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
    public partial class Proveedor : Form
    {
        private SqlConnection connection = Conexion.Connection();
        private Boolean ban = true;
        private String funcion;

        public Proveedor(String funcion)
        {
            this.funcion = funcion;
            InitializeComponent();
            setearBotones();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MenuProveedores menuProveedores = new MenuProveedores();
            menuProveedores.Show();
            ban = false;
            Close();
        }

        private void Proveedor_Load(object sender, EventArgs e)
        {

        }

        private void Proveedor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ban)
            {
                MenuProveedores menuProveedores = new MenuProveedores();
                menuProveedores.Show();
            }
        }

        private void nom_TextChanged(object sender, EventArgs e)
        {

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
                    proximaClave();
                    break;
                case "modificar":
                    insertar.Enabled = false;
                    eliminar.Enabled = false;
                    modificar.Enabled = false;
                    consultar.Enabled = true;
                    clave.Enabled = true;
                    nom.Enabled = false;
                    dis.Enabled = false;
                    tel.Enabled = false;
                    dir.Enabled = false;
                    email.Enabled = false;
                    codigo.Enabled = false;
                    ciudad.Enabled = false;
                    clave.Enabled = true;
                    break;
                case "eliminar":
                    insertar.Enabled = false;
                    eliminar.Enabled = false;
                    modificar.Enabled = false;
                    consultar.Enabled = true;
                    nom.Enabled = false;
                    dis.Enabled = false;
                    tel.Enabled = false;
                    dir.Enabled = false;
                    email.Enabled = false;
                    codigo.Enabled = false;
                    ciudad.Enabled = false;
                    clave.Enabled = true;
                    break;
            }
        }

        private void proximaClave()
        {
            int clvProv;
            connection.Open();
            SqlCommand command = new SqlCommand("ULTIMACLVPROVEEDOR", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@CLVPROV", SqlDbType.Int).Direction = ParameterDirection.Output;
            command.ExecuteNonQuery();
            clvProv = Convert.ToInt32(command.Parameters["@CLVPROV"].Value.ToString());
            clave.Text = clvProv.ToString();
            connection.Close();
        }

        private void insertar_Click(object sender, EventArgs e)
        {
            Boolean ban = false;
            int error;
            connection.Open();
            SqlCommand command = new SqlCommand("INSERTAPROV", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@NOMPROV", nom.Text.ToUpper());
            command.Parameters.AddWithValue("@NOMDIST", dis.Text.ToUpper());
            command.Parameters.AddWithValue("@TEL", tel.Text.ToUpper());
            command.Parameters.AddWithValue("@DIREC", dir.Text.ToUpper());
            command.Parameters.AddWithValue("@EMAIL", email.Text);
            command.Parameters.AddWithValue("@CP", codigo.Text.ToUpper());
            command.Parameters.AddWithValue("@CIUDAD", ciudad.Text.ToUpper());
            command.Parameters.AddWithValue("@CLVPROV", clave.Text.ToUpper());
            command.Parameters.Add("@BAN", SqlDbType.Int).Direction = ParameterDirection.Output;
            command.ExecuteNonQuery();
            error = int.Parse(command.Parameters["@BAN"].Value.ToString());
            switch (error)
            {
                case 1:
                    MessageBox.Show("Ingrese el nombre del proveedor");
                    break;
                case 2:
                    MessageBox.Show("Ingrese el nombre del distribuidor");
                    break;
                case 3:
                    MessageBox.Show("Ingrese la dirección");
                    break;
                case 4:
                    MessageBox.Show("Ingrese el email");
                    break;
                case 5:
                    MessageBox.Show("Ingrese la ciudad");
                    break;
                default:
                    ban = true;
                    break;
            }
            connection.Close();
            if (ban)
            {
                MessageBox.Show("Proveedor correctamente insertado");
                nom.Text = "";
                dis.Text = "";
                tel.Text = "";
                dir.Text = "";
                email.Text = "";
                codigo.Text = "";
                ciudad.Text = "";
                proximaClave();
            }
        }

        private void consultar_Click(object sender, EventArgs e)
        {
            SqlCommand command;
            SqlDataReader reader;
            connection.Open();
            command = new SqlCommand("SELECT * FROM PROVEEDOR WHERE CLVPROV = " + clave.Text, connection);
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                nom.Text = reader["NOMPROV"].ToString();
                dis.Text = reader["NOMDIST"].ToString();
                tel.Text = reader["TEL"].ToString();
                dir.Text = reader["DIREC"].ToString();
                email.Text = reader["EMAIL"].ToString();
                codigo.Text = reader["CP"].ToString();
                ciudad.Text = reader["CIUDAD"].ToString();
                if (funcion.Equals("modificar"))
                {
                    clave.Enabled = false;
                    nom.Enabled = true;
                    dis.Enabled = true;
                    tel.Enabled = true;
                    dir.Enabled = true;
                    email.Enabled = true;
                    codigo.Enabled = true;
                    ciudad.Enabled = true;
                    modificar.Enabled = true;
                    consultar.Enabled = false;
                }
                if (funcion.Equals("eliminar"))
                {
                    clave.Enabled = false;
                    eliminar.Enabled = true;
                    consultar.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("No se encontró ningún proveedor con la clave que busca.");
            }
            connection.Close();
        }

        private void eliminar_Click(object sender, EventArgs e)
        {
            Boolean ban = false;
            SqlCommand command;
            connection.Open();
            command = new SqlCommand("ELIMINARPROV", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@CLVPROV", clave.Text);
            command.Parameters.Add("@BAN", SqlDbType.Int).Direction = ParameterDirection.Output;
            command.ExecuteNonQuery();
            switch (Convert.ToInt32(command.Parameters["@BAN"].Value.ToString()))
            {
                case 1:
                    MessageBox.Show("No se encontró ningún proveedor con la clave que busca para eliminar.");
                    break;
                default:
                    ban = true;
                    break;
            }
            if (ban)
            {
                MessageBox.Show("Proveedor eliminado correctamente.");
                nom.Text = "";
                dis.Text = "";
                tel.Text = "";
                dir.Text = "";
                email.Text = "";
                codigo.Text = "";
                ciudad.Text = "";
                clave.Text = "";
                clave.Enabled = true;
                eliminar.Enabled = false;
                consultar.Enabled = true;
            }
            connection.Close();
        }

        private void modificar_Click(object sender, EventArgs e)
        {
            Boolean ban = false;
            SqlCommand command;
            connection.Open();
            command = new SqlCommand("MODIFICAPROV", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@NOMPROV", nom.Text.ToUpper());
            command.Parameters.AddWithValue("@NOMDIST", dis.Text.ToUpper());
            command.Parameters.AddWithValue("@TEL", tel.Text.ToUpper());
            command.Parameters.AddWithValue("@DIREC", dir.Text.ToUpper());
            command.Parameters.AddWithValue("@EMAIL", email.Text);
            command.Parameters.AddWithValue("@CP", codigo.Text.ToUpper());
            command.Parameters.AddWithValue("@CIUDAD", ciudad.Text.ToUpper());
            command.Parameters.AddWithValue("@CLVPROV", clave.Text.ToUpper());
            command.Parameters.Add("@BAN", SqlDbType.Int).Direction = ParameterDirection.Output;
            command.ExecuteNonQuery();
            switch (Convert.ToInt32(command.Parameters["@BAN"].Value.ToString()))
            {
                case 1:
                    MessageBox.Show("Ingrese el nombre del proveedor");
                    break;
                case 2:
                    MessageBox.Show("Ingrese el nombre del distribuidor");
                    break;
                case 3:
                    MessageBox.Show("Ingrese la dirección");
                    break;
                case 4:
                    MessageBox.Show("Ingrese el email");
                    break;
                case 5:
                    MessageBox.Show("Ingrese la ciudad");
                    break;
                case 6:
                    MessageBox.Show("La clave del proveedor no puede quedar vacía");
                    break;
                case 7:
                    MessageBox.Show("La clave del provedor no existe");
                    break;
                default:
                    ban = true;
                    break;
            }
            if (ban)
            {
                MessageBox.Show("Datos del proveedor actualizados");
                nom.Text = "";
                dis.Text = "";
                tel.Text = "";
                dir.Text = "";
                email.Text = "";
                codigo.Text = "";
                ciudad.Text = "";
                nom.Enabled = false;
                dis.Enabled = false;
                tel.Enabled = false;
                dir.Enabled = false;
                email.Enabled = false;
                codigo.Enabled = false;
                ciudad.Enabled = false;
                clave.Enabled = true;
                consultar.Enabled = true;
                modificar.Enabled = false;
            }
            connection.Close();
        }
    }
}
