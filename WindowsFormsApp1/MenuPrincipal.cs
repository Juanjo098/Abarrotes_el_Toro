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
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {

        }

        private void pos_Click(object sender, EventArgs e)
        {
            Pos venta = new Pos();
            venta.Show();
        }

        private void proveedores_Click(object sender, EventArgs e)
        {
            MenuProveedores proveedores = new MenuProveedores();
            proveedores.Show();
        }

        private void compras_Click(object sender, EventArgs e)
        {
            MenuCompras compras = new MenuCompras();
            compras.Show();
        }

        private void productos_Click(object sender, EventArgs e)
        {
            MenuProductos productos = new MenuProductos();
            productos.Show();
        }

        private void ventas_Click(object sender, EventArgs e)
        {
            ConsultaVentas consultaVentas = new ConsultaVentas();
            consultaVentas.Show();
        }

        private void salir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
