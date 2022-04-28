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
    public partial class MenuProductos : Form
    {
        private Boolean ban = true;
        public MenuProductos()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ban = false;
            Program.menuPrincipal.Show();
            Dispose();
        }

        private void MenuProductos_Load(object sender, EventArgs e)
        {
            Program.menuPrincipal.Hide();
        }

        private void pos_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto("insertar");
            producto.Show();
            Dispose();
        }

        private void productos_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto("eliminar");
            producto.Show();
            Dispose();
        }

        private void MenuProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ban)
                Program.menuPrincipal.Show();
        }

        private void ventas_Click(object sender, EventArgs e)
        {
            ban = false;
            ConsultaProductos consultaProductos = new ConsultaProductos();
            consultaProductos.Show();
            Close();
        }

        private void proveedores_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto("modificar");
            producto.Show();
            Dispose();
        }
    }
}
