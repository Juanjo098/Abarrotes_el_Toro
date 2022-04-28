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
    public partial class Producto : Form
    {
        private Boolean ban = true;
        private String funcion;

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
                    break;
                case "modificar":
                    insertar.Enabled = false;
                    eliminar.Enabled = false;
                    modificar.Enabled = true;
                    consultar.Enabled = true;
                    nom.Enabled = false;
                    prccomp.Enabled = false;
                    prcvent.Enabled = false;
                    exi.Enabled = false;
                    gan.Enabled = false;
                    break;
                case "eliminar":
                    insertar.Enabled = false;
                    eliminar.Enabled = true;
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
    }
}
