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
    public partial class Pos : Form
    {
        public Pos()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Close();
            Program.menuPrincipal.Show();
        }

        private void Pos_Load(object sender, EventArgs e)
        {
            Program.menuPrincipal.Hide();
        }

        private void Pos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.menuPrincipal.Show();
        }
    }
}
