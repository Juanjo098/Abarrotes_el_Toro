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
    public partial class MenuProveedores : Form
    {

        private Boolean ban = true;
        public MenuProveedores()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ban = false;
            Program.menuPrincipal.Show();
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void MenuProveedores_Load(object sender, EventArgs e)
        {
            Program.menuPrincipal.Hide();
        }

        private void pos_Click(object sender, EventArgs e)
        {
            Proveedor prov = new Proveedor();
            prov.Show();
            Dispose();
        }

        private void MenuProveedores_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ban)
                Program.menuPrincipal.Show();
        }

        private void ventas_Click(object sender, EventArgs e)
        {
            ban = false;
            ConsultaProveedores consultaProveedores = new ConsultaProveedores();
            consultaProveedores.Show();
            Close();
        }
    }
}
