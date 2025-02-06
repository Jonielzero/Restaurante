using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using Restaurante.Clases;

namespace Restaurante.Proveedores
{
    public partial class editar_proveedores : Form
    {
        public editar_proveedores()
        {
            InitializeComponent();
        }
        private void LoadTheme()
        {
            foreach (Control btns in panel1.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }

            foreach (Control cbs in panel1.Controls)
            {
                if (cbs.GetType() == typeof(ComboBox))
                {
                    ComboBox cb = (ComboBox)cbs;
                    cb.BackColor = ThemeColor.SecondaryColor;
                    cb.ForeColor = Color.White;
                }
            }
            foreach (Control lbs in panel1.Controls)
            {
                if (lbs.GetType() == typeof(Label))
                {
                    Label lbl = (Label)lbs;
                    lbl.ForeColor = Color.White;
                    lbl.Font = Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                }


            }

            foreach (Control tbs in panel1.Controls)
            {
                if (tbs.GetType() == typeof(TextBox))
                {
                    TextBox tb = (TextBox)tbs;
                    tb.BackColor = ThemeColor.SecondaryColor;
                    tb.ForeColor = Color.White;

                }
            }


        }
        private void limpiar()
        {
            txtDireccion.Clear();
            txtemail.Clear();
            txtnombrec.Clear();
            txtnombrep.Clear();
            txttelefono.Clear();
            txtid.Clear();
        }
        private void CargarDatos()
        {
            using (SqlConnection conexion = new SqlConnection(Program.connectionString))
            {
                string query = "SELECT nombre_proveedor, nombre_contacto, telefono, email, direccion FROM proveedores WHERE id_proveedor = @nombre ";
                conexion.Open();
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@nombre", txtid.Text);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtnombrep.Text = reader["nombre_proveedor"].ToString();
                    txtnombrec.Text = reader["nombre_contacto"].ToString();
                    txttelefono.Text = reader["telefono"].ToString();
                    txtemail.Text = reader["email"].ToString();
                    txtDireccion.Text = reader["direccion"].ToString();
                }
            }
        }
        private bool validarcampos()
        {
            if (txtnombrep.Text == "")
            {
                MessageBox.Show("Escriba un nombre.");
                return false;
            }
            if (txtnombrec.Text == "")
            {
                MessageBox.Show("Escriba un nombre de contacto.");
                return false;
            }
            if (txttelefono.Text == "")
            {
                MessageBox.Show("Escriba un telefono.");
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!validarcampos())
            {
                return;
            }
            int id = int.Parse(txtid.Text);
            string nombreproveedor = txtnombrep.Text;
            string nombrecontacto = txtnombrec.Text;
            int telefono = int.Parse(txttelefono.Text);
            string email = txtemail.Text;
            string direccion = txtDireccion.Text;

            if (string.IsNullOrWhiteSpace(txtnombrep.Text))
            {
                MessageBox.Show("el campo nombre no puede estar en blanco");
            }
            else
            {
                // actuali mediante sql

                string query = "UPDATE proveedores SET nombre_proveedor = @NuevoNombreP, nombre_contacto = @NuevoNombreC, telefono = @NuevoTelefono, email = @NuevoEmail, direccion =@NuevaDirecion WHERE id_proveedor= @ID";
                using (SqlConnection conexion = new SqlConnection(Program.connectionString))
                {


                    using (SqlCommand command = new SqlCommand(query, conexion))
                    {
                        conexion.Open();
                        // Agrega parámetros a la consulta para prevenir SQL injection
                        command.Parameters.AddWithValue("@NuevonombreP", nombreproveedor);
                        command.Parameters.AddWithValue("@NuevoNombreC", nombrecontacto);
                        command.Parameters.AddWithValue("@NuevoTelefono", telefono);
                        command.Parameters.AddWithValue("@NuevoEmail", email);
                        command.Parameters.AddWithValue("@NuevaDirecion", direccion);
                        command.Parameters.AddWithValue("@ID", id);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Registro actualizado correctamente.");
                        }
                        else
                        {
                            MessageBox.Show("No se pudo encontrar el registro con el ID proporcionado.");
                        }

                    }
                }
            }
            limpiar();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {


                int id = int.Parse(txtid.Text);

                string query = "DELETE FROM Proveedores WHERE id_proveedor = @ID";

                using (SqlConnection conexion = new SqlConnection(Program.connectionString))
                {
                    conexion.Open();

                    using (SqlCommand command = new SqlCommand(query, conexion))
                    {
                        command.Parameters.AddWithValue("@ID", id);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Registro eliminado correctamente.");
                        }
                        else
                        {
                            MessageBox.Show("No se pudo encontrar el registro con el ID proporcionado.");
                        }
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("no se puede eliminar un proveedor que tenga productos");
            }
            limpiar();
        }

        private void txttelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validar que solo se puedan ingresar numeros y que se pueda borrar
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                CargarDatos();
            }
        }

        private void editar_proveedores_Load(object sender, EventArgs e)
        {

        }
    }
}
