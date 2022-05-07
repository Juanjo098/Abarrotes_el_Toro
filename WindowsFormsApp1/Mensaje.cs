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
    public partial class Mensaje : Form
    {
        public Mensaje(String msg, String title)
        {
            InitializeComponent();
            msgBox.Text = msg;
            this.Text = title;
        }

    }
}
