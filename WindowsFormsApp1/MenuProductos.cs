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
        public MenuProductos()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Program.menuPrincipal.Show();
            Dispose();
        }

        private void MenuProductos_Load(object sender, EventArgs e)
        {
            Program.menuPrincipal.Hide();
        }

        private void pos_Click(object sender, EventArgs e)
        {
            Producto producto = new Producto();
            producto.Show();
            Dispose();
        }

        private void productos_Click(object sender, EventArgs e)
        {

        }

        private void MenuProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.menuPrincipal.Show();
        }
    }
}
