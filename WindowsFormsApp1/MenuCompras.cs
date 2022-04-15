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
    public partial class MenuCompras : Form
    {

        private Boolean ban = true;

        public MenuCompras()
        {
            InitializeComponent();
        }

        private void MenuCompras_Load(object sender, EventArgs e)
        {
            Program.menuPrincipal.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ban = false;
            Close();
            Program.menuPrincipal.Show();
        }

        private void proveedores_Click(object sender, EventArgs e)
        {
            ban = false;
            RegistrarCompras registrarCompras = new RegistrarCompras();
            registrarCompras.Show();
            Close();
        }

        private void MenuCompras_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ban)
                Program.menuPrincipal.Show();
        }

        private void ventas_Click(object sender, EventArgs e)
        {
            ban = false;
            ConsultaCompras consultaCompras = new ConsultaCompras();
            consultaCompras.Show();
            Close();
        }
    }
}
