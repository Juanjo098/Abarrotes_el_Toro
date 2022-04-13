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

        public Proveedor()
        {
            InitializeComponent();
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
    }
}
