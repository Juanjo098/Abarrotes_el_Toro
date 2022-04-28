using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Proveedor : Form
    {
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
                    break;
                case "modificar":
                    insertar.Enabled = false;
                    eliminar.Enabled = false;
                    modificar.Enabled = true;
                    consultar.Enabled = true;
                    clave.Enabled = true;
                    nom.Enabled = false;
                    dis.Enabled = false;
                    tel.Enabled = false;
                    dir.Enabled = false;
                    codigo.Enabled = false;
                    ciudad.Enabled = false;
                    clave.Enabled = true;
                    break;
                case "eliminar":
                    insertar.Enabled = false;
                    eliminar.Enabled = true;
                    modificar.Enabled = false;
                    consultar.Enabled = true;
                    nom.Enabled = false;
                    dis.Enabled = false;
                    tel.Enabled = false;
                    dir.Enabled = false;
                    codigo.Enabled = false;
                    ciudad.Enabled = false;
                    clave.Enabled = true;
                    break;
            }
        }
    }
}
