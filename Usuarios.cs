﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace miapp_2
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            string cadenConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenConexion);

            try
            {

                // conectar con la base de datos
                SqlCommand cmd = new SqlCommand();

                string consulta = "SELECT * FROM usuarios";

                cmd.Parameters.Clear(); // limpiar todos los parametros del objeto cmd
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;
                DataTable tabla = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);

                grillaUsuarios.DataSource = tabla;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                // cierre de conexion de la bd
                cn.Close();
            }

        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtNombreDeUsuario.Text = "";
            txtContraseña.Text = "";
            txtRepetirContraseña.Text = "";
        }

        // validar los inputs
        private void btnAltaUsuario_Click(object sender, EventArgs e)
        {
            if (txtNombreDeUsuario.Text.Equals("")) // si txtNombreDeUsuario está vacio... ejecute el bloque
            {
                MessageBox.Show("Ingrese nombre de usurio");
            }
            else // si txtNombreDeUsuario no está vacio... ejecute el bloque
            {
                if (txtContraseña.Text.Equals(txtRepetirContraseña.Text))  // si txtContraseña es igual a txtRepetirContraseña... ejecute el bloque
                {
                    try
                    {
                        bool resultado = InsertarUsuario(txtNombreDeUsuario.Text, txtContraseña.Text);
                        if (resultado)
                        {
                            MessageBox.Show("Usuario dado de alta con exito");
                            LimpiarCampos();
                            CargarGrilla();
                            txtNombreDeUsuario.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Error al insertar nuevo usuario");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        txtNombreDeUsuario.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Las contraseñas no coinciden");
                }
            }
        }


        private bool InsertarUsuario(string nombreDeUsuario, string password)
        {
            string cadenConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenConexion);
            bool resultado = false;
            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "INSERT INTO usuarios (NombreDeUsuario, Password) VALUES(@nombreUsu, @pass)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nombreUsu", nombreDeUsuario);
                cmd.Parameters.AddWithValue("@pass", password);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                resultado = true;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cn.Close();
            }

            return resultado;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}