using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class Conexion
    {
        public static SqlConnection Connection()
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection("SERVER=DESKTOP-MDS9EJ7;DATABASE=ABARROTESTORO; Integrated security=true");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return conn;
        }
    }
}
