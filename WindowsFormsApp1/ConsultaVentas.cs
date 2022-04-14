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
    public partial class ConsultaVentas : Form
    {
        public ConsultaVentas()
        {
            InitializeComponent();
        }

        private void ConsultaVentas_Load(object sender, EventArgs e)
        {
            Program.menuPrincipal.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Program.menuPrincipal.Show();
            Close();
        }

        private void ConsultaVentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.menuPrincipal.Show();
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
    }
}
