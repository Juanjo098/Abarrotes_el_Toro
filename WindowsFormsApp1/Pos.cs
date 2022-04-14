﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

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
            total.Text = "0";
        }

        private void Pos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.menuPrincipal.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            capturarCompra();
        }

        private void capturarCompra()
        {
            if (tabla.Rows.Count != 0)
            {
                SqlConnection connection = Conexion.Connection();
                String erros = "";
                SqlCommand command, command1;
                SqlDataReader reader = null;
                connection.Open();

                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    command = new SqlCommand("SELECT EXIST FROM PRODUCTOS WHERE CLVPROD =" + tabla[0, i].Value.ToString(), connection);
                    reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        if (int.Parse(reader["EXIST"].ToString()) < int.Parse(tabla[1, i].Value.ToString()))
                        {
                            erros += "Hay " + reader["EXIST"].ToString() + " " + tabla[2, i].Value.ToString() + "\n";
                        }
                    }
                    reader.Close();
                }
                if (erros == "")
                {
                    command1 = new SqlCommand("INSERTAVENTAS", connection);
                    command1.CommandType = CommandType.StoredProcedure;
                    command1.Parameters.Add("@CVEVEN", SqlDbType.Int).Direction = ParameterDirection.Output;
                    command1.ExecuteNonQuery();
                    MessageBox.Show("Venta con clave " + command1.Parameters["@CVEVEN"].Value.ToString() + " registrada,");
                    tabla.Rows.Clear();
                    acualizarTotal();
                }
                else
                {
                    MessageBox.Show("Está tratando de vender más productos de los que hay en existencia\n" + erros);
                }
                connection.Close();
            }
            else
                MessageBox.Show("No ha ingresado ningún producto");
        }

        private Boolean existe(String clv)
        {
            for (int i = 0; i < tabla.Rows.Count; i++)
                if (clv.Equals(tabla[0, i].Value.ToString()))
                    return true;
            return false;
        }

        private void acualizarTotal()
        {
            decimal total = 0;
            for (int i = 0; i < tabla.Rows.Count; i++)
                total += decimal.Parse(tabla[3, i].Value.ToString()) * int.Parse(tabla[1, i].Value.ToString());
            this.total.Text = total.ToString();
        }

        private void tabla_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int cantidad;
            try
            {
                cantidad = int.Parse(tabla.CurrentCell.Value.ToString());
                if (cantidad < 1)
                {
                    MessageBox.Show("No se puede ingresar un número menor a 1");
                    tabla.CurrentCell.Value = 1;
                }
                acualizarTotal();
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.ToString());
                tabla.CurrentCell.Value = 1;
                acualizarTotal();
            }
        }

        private void claveProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (claveInsertada())
                {
                    SqlConnection connection = Conexion.Connection();
                    SqlCommand command = new SqlCommand("SELECT CLVPROD, NOMPRODUCT, PRECIOVEN FROM PRODUCTOS WHERE CLVPROD =" + claveProd.Text, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        if (!existe(reader["CLVPROD"].ToString()))
                        {
                            tabla.Rows.Add();
                            tabla[0, tabla.RowCount - 1].Value = reader["CLVPROD"].ToString();
                            tabla[1, tabla.RowCount - 1].Value = 1;
                            tabla[2, tabla.RowCount - 1].Value = reader["NOMPRODUCT"].ToString();
                            tabla[3, tabla.RowCount - 1].Value = decimal.Round(decimal.Parse(reader["PRECIOVEN"].ToString()), 2).ToString();
                            claveProd.Text = "";
                            acualizarTotal();
                        }
                    }
                    reader.Close();
                    connection.Close();
                }
            }
        }

        private Boolean claveInsertada()
        {
            return claveProd.Text != "";
        }

    }
}
