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

namespace Restaurante.Proveedores
{
    public partial class editar_proveedores : Form
    {
        public editar_proveedores()
        {
            InitializeComponent();
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
        private bool validarcampos()
        {
            if(txtnombrep.Text == "")
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
    }
}
