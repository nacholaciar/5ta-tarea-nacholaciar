using miapp_2.entidades;
using System;
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
    public partial class AltaPersona : Form
    {
        public AltaPersona()
        {
            InitializeComponent();
        }

        private void AltaPersona_Load(object sender, EventArgs e)
        {
            LimpiarCmapos();
            txtCantidadH.Enabled = false;
            btnActualizarPersona.Enabled = false;
            CargarCombosTiposDocumentos();
            CargarCombosCarreras();
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

                string consulta = "SELECT Nombre, Apellido, IdTipoDocumento, NroDocumento FROM personas";

                cmd.Parameters.Clear(); // limpiar todos los parametros del objeto cmd
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;
                DataTable tabla = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);

                dgPersona.DataSource = tabla;
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

        private void CargarCombosTiposDocumentos()
        {
            string cadenConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenConexion);

            try
            {

                // conectar con la base de datos
                SqlCommand cmd = new SqlCommand();

                string consulta = "SELECT * FROM tipo_documento ";

                cmd.Parameters.Clear(); // limpiar todos los parametros del objeto cmd
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;

                DataTable tabla = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);

                cbTDocumento.DataSource = tabla;
                cbTDocumento.DisplayMember = "Nombre";
                cbTDocumento.ValueMember = "Id";
                cbTDocumento.SelectedIndex = -1; // automaticamente se posiciona en la casilla vacia

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                // cierre de conexion de la bd
                cn.Close();
            }
        }

        private void CargarCombosCarreras()
        {
            string cadenConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenConexion);

            try
            {

                // conectar con la base de datos
                SqlCommand cmd = new SqlCommand();
                string consulta = "SELECT * FROM carreras";
                cmd.Parameters.Clear(); // limpiar todos los parametros del objeto cmd
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;

                DataTable tabla = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(tabla);

                cbCarrera.DataSource = tabla;
                cbCarrera.DisplayMember = "Nombre";
                cbCarrera.ValueMember = "Id";
                cbCarrera.SelectedIndex = -1; 

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                // cierre de conexion de la bd
                cn.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtNacimiento_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void lblDocumento_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void ckHijo_CheckedChanged(object sender, EventArgs e)
        {
            if (ckHijo.Checked)
            {
                txtCantidadH.Enabled = true;
            }
            else
            {
                txtCantidadH.Enabled = false;
            }
        }

        private void lblCantidadH_Click(object sender, EventArgs e)
        {

        }

        private persona ObtenerDatosPersona()
        {
            persona p = new persona(); // nueva instancia del nuevo objeto persona
            p.Nombre = txtNombre.Text.Trim(); // Trim() utilizado elimina espacios
            p.Apellido = txtApellido.Text.Trim();
            p.fechaNacimientoPersona = DateTime.Parse(mskNacimiento.Text); // DateTime.Parce convierte texto a DateTime

            if (rdMasculino.Checked) // x.Cheked significa que está seleccionado 
            {
                p.IdSexoPersona = 1;
            }
            else if (rdFemenino.Checked)
            {
                p.IdSexoPersona = 2;

            }
            else
            {
                p.IdSexoPersona = 3;
            }

            p.IdTipoDocumentoPersona = (int)cbTDocumento.SelectedValue;
            p.Documento = txtDNI.Text.Trim();
            p.CallePersona = txtCalle.Text.Trim();
            p.NroCasaPersona = txtNroCasa.Text.Trim();

            // verificar 
            if (ckSoltero.Checked)
            {
                p.SolteroPersona = true;
            }
            else
            {
                // p.ckCasado = true;
                p.SolteroPersona = true;
            }

            if (ckCasado.Checked)
            {
                p.CasadoPersona = true;
            }
            else
            {
                p.CasadoPersona = false;
            }

            if (ckHijo.Checked)
            {
                p.HijosPersona = true;
            }
            else
            {
                p.HijosPersona = false;
            }

            if (txtCantidadH.Text.Equals(""))
            {
                p.CantidadHijosPersona = 0;
            }
            else
            {
                p.CantidadHijosPersona = int.Parse(txtCantidadH.Text); // parciamos para convertir texto a entero
            }

            p.IdCarreraPersona = (int)cbCarrera.SelectedValue;

            return p;
        }

        private void btnGuardarPersona_Click(object sender, EventArgs e)
        {

            persona p = ObtenerDatosPersona();
            bool resultado = AgregarPersonaADB(p);
            if (resultado)
            {
                MessageBox.Show("Persona agregada con exito");
                LimpiarCmapos();
                CargarCombosCarreras();
                CargarCombosTiposDocumentos();
                CargarGrilla();
            }
            else
            {
                MessageBox.Show("Error al agregar la persona");
            }

        }

        private bool AgregarPersonaADB(persona per)
        {
            string cadenConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenConexion);
            bool resultado = false;
            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "INSERT INTO personas (Nombre, Apellido, FechaNacimiento, IdSexo, IdTipoDocumento, NroDocumento, Calle, NroCasa, Soltero, Casado, Hijos, CantidadHijos, IdCarrera) VALUES(@nombre, @apellido, @fechaNacimiento, @idSexo, @idTipoDocumento, @nroDocumento, @calle, @nroCasa, @soltero, @casado, @hijos, @cantidadHijos, @idCarrera)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nombre", per.Nombre);
                cmd.Parameters.AddWithValue("@apellido", per.Apellido);
                cmd.Parameters.AddWithValue("@fechaNacimiento", per.fechaNacimientoPersona);
                cmd.Parameters.AddWithValue("@idSexo", per.IdSexoPersona);
                cmd.Parameters.AddWithValue("@idTipoDocumento", per.IdTipoDocumentoPersona);
                cmd.Parameters.AddWithValue("@nroDocumento", per.Documento);
                cmd.Parameters.AddWithValue("@calle", per.CallePersona);
                cmd.Parameters.AddWithValue("@nroCasa", per.NroCasaPersona);
                cmd.Parameters.AddWithValue("@soltero", per.SolteroPersona);
                cmd.Parameters.AddWithValue("@casado", per.CasadoPersona);
                cmd.Parameters.AddWithValue("@hijos", per.HijosPersona);
                cmd.Parameters.AddWithValue("@cantidadHijos", per.CantidadHijosPersona); 
                cmd.Parameters.AddWithValue("@idCarrera", per.IdCarreraPersona);

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

        private void AddPersona(persona per)
        {
            DataGridViewRow fila = new DataGridViewRow();

            DataGridViewTextBoxCell celdaDocumento = new DataGridViewTextBoxCell();
            celdaDocumento.Value = per.Documento;
            fila.Cells.Add(celdaDocumento);

            DataGridViewTextBoxCell celdaNombre = new DataGridViewTextBoxCell();
            celdaNombre.Value = per.Nombre;
            fila.Cells.Add(celdaNombre);

            DataGridViewTextBoxCell celdaApellido = new DataGridViewTextBoxCell();
            celdaApellido.Value = per.Apellido;
            fila.Cells.Add(celdaApellido);

            dgPersona.Rows.Add(fila);
            MessageBox.Show("Persona agregada con exito");
            LimpiarCmapos();
            txtNombre.Focus(); //el cursor comienza en el nombre
        }

        private void btnLimpiarDatos_Click(object sender, EventArgs e)
        {
            LimpiarCmapos();
        }

        private void LimpiarCmapos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            mskNacimiento.Text = "";
            rdMasculino.Checked = true;
            txtDNI.Text = "";
            txtCalle.Text = "";
            txtNroCasa.Text = "";
            ckSoltero.Checked = false;
            ckCasado.Checked = false;
            ckHijo.Checked = false;

        }


        private bool existeGrilla (string criterioABuscar)
        {
            bool resultado = false;

            for (int i = 0; i < dgPersona.Rows.Count; i++)
            {
                if (dgPersona.Rows[i].Cells["Documento"].Value.Equals(criterioABuscar))
                {
                    return true;
                    break;
                }

            }

            return resultado;
        }

        private void dgPersona_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgPersona_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indice = e.RowIndex; // saber en que fila estoy actualmente
            btnActualizarPersona.Enabled = true;
            DataGridViewRow filaSeleccionada = dgPersona.Rows[indice]; // obtener fila completa 
            string documento = filaSeleccionada.Cells["Documento"].Value.ToString();
            persona p = ObtenerPersona(documento);
            LimpiarCmapos();
            CargarCampos(p);

        }

       private void CargarCampos (persona p)
        {
            txtNombre.Text = p.Nombre;
            txtApellido.Text = p.Apellido;

            DateTime fecha = p.fechaNacimientoPersona;
            string dia = "";
            string mes = "";
            string año = "";
            dia = fecha.Date.Day.ToString();
            if(dia.Length == 1)
            {
                dia = "0" + dia;
            }
            mes = fecha.Date.Month.ToString();
            if(mes.Length == 1)
            {
                mes = "0" + mes;
            }
            año = fecha.Date.Year.ToString();

            mskNacimiento.Text = dia + mes + año;
            if(p.IdSexoPersona == 1)
            {
                rdMasculino.Checked = true;
            }
            else if (p.IdSexoPersona == 2)
            {
                rdFemenino.Checked = true;
            }
            else
            {
                rdOtro.Checked = true;
            }
        
            cbTDocumento.SelectedValue = p.IdTipoDocumentoPersona;
            txtDNI.Text = p.Documento;
            txtCalle.Text = p.CallePersona.ToString();
            txtNroCasa.Text = p.NroCasaPersona.ToString();
            if(p.CasadoPersona)
            {
                ckCasado.Checked = true;
            }
            else if (p.SolteroPersona)
            {
                ckSoltero.Checked = true;
            }
            else
            {
                ckHijo.Checked = true;
            }

            if (p.CantidadHijosPersona > 0)
            {
                txtCantidadH.Text = p.CantidadHijosPersona.ToString();
            }
            else
            {
                ckHijo.Checked = false;
            }

            cbCarrera.SelectedValue = p.IdCarreraPersona;
        }
        
        private persona ObtenerPersona(string documento)
        {
            string cadenConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenConexion);
            persona p = new persona();
            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "SELECT * FROM personas where NroDocumento like @documento"; // devolveme todas las personas donde el parametro @documento sea igual a NroDocumento
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@documento", documento);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;
                SqlDataReader dr = cmd.ExecuteReader(); // obtener resultado y poder leerlo
                if (dr != null && dr.Read()) 
                {

                    p.Nombre = dr["Nombre"].ToString();
                    p.Apellido = dr["Apellido"].ToString();
                    p.fechaNacimientoPersona = DateTime.Parse(dr["FechaNacimiento"].ToString());
                    p.IdSexoPersona = int.Parse(dr["IdSexo"].ToString());
                    p.IdTipoDocumentoPersona = int.Parse(dr["IdTipoDocumento"].ToString());
                    p.Documento = dr["NroDocumento"].ToString();
                    p.CallePersona = dr["Calle"].ToString();
                    p.NroCasaPersona = dr["NroCasa"].ToString();
                    p.SolteroPersona = bool.Parse(dr["Soltero"].ToString());
                    p.CasadoPersona = bool.Parse(dr["Casado"].ToString());
                    p.HijosPersona = bool.Parse(dr["Hijos"].ToString());
                    p.CantidadHijosPersona = int.Parse(dr["CantidadHijos"].ToString());
                    p.IdCarreraPersona = int.Parse(dr["IdCarrera"].ToString());

                }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cn.Close();
            }

            return p;
        }

        private void btnActualizarPersona_Click(object sender, EventArgs e)
        {
            persona p = ObtenerDatosPersona();
            bool resultado = ActualizarPersona(p);
            if (resultado)
            {
                MessageBox.Show("Persona agregada con exito");
                LimpiarCmapos();
                CargarGrilla();
                CargarCombosCarreras();
                CargarCombosTiposDocumentos();

            }
            else
            {
                MessageBox.Show("Error al actualizar la persona");
            }
        }

        private bool ActualizarPersona(persona per)
        {
            string cadenConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"];
            SqlConnection cn = new SqlConnection(cadenConexion);
            bool resultado = false;
            try
            {
                //Update table-name
                //SET column1 = value1, value2 = value2, ...
                //WHERE condition;
                SqlCommand cmd = new SqlCommand();
                string consulta = "UPDATE personas SET Nombre = @nombre, Apellido = @apellido, FechaNacimiento = @fechaNacimiento, IdSexo = @idSexo, IdTipoDocumento = @idTipoDocumento, NroDocumento = @nroDocumento, Calle = @calle, NroCasa = @nroCasa, Soltero = @soltero, Casado = @casado, Hijos = @hijos, CantidadHijos = @cantidadHijos, IdCarrera = @idCarrera WHERE NroDocumento like @nroDocumento"; // nunca olvidar en un update la condicion WHERE
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nombre", per.Nombre);
                cmd.Parameters.AddWithValue("@apellido", per.Apellido);
                cmd.Parameters.AddWithValue("@fechaNacimiento", per.fechaNacimientoPersona);
                cmd.Parameters.AddWithValue("@idSexo", per.IdSexoPersona);
                cmd.Parameters.AddWithValue("@idTipoDocumento", per.IdTipoDocumentoPersona);
                cmd.Parameters.AddWithValue("@nroDocumento", per.Documento);
                cmd.Parameters.AddWithValue("@calle", per.CallePersona);
                cmd.Parameters.AddWithValue("@nroCasa", per.NroCasaPersona);
                cmd.Parameters.AddWithValue("@soltero", per.SolteroPersona);
                cmd.Parameters.AddWithValue("@casado", per.CasadoPersona);
                cmd.Parameters.AddWithValue("@hijos", per.HijosPersona);
                cmd.Parameters.AddWithValue("@cantidadHijos", per.CantidadHijosPersona);
                cmd.Parameters.AddWithValue("@idCarrera", per.IdCarreraPersona);

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
    }
}
