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

        public Producto()
        {
            InitializeComponent();
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
    }
}
