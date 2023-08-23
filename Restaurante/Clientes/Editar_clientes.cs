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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Restaurante.Clientes
{
    public partial class Editar_clientes : Form
    {
        public Editar_clientes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text == "" || txtapellido.Text == "" || txttelefono.Text == "")
            {
                MessageBox.Show("Por favor llene los campos de nombre, apellido y telefono.");
                return;
            }
            int id = int.Parse(txtid.Text);
            string nombre = txtnombre.Text;
            string apellido = txtapellido.Text;
            int telefono = int.Parse(txttelefono.Text);
            string direccion = txtdireccion.Text;
            int rtn = int.Parse(txtrtn.Text);

            if (string.IsNullOrWhiteSpace(txtnombre.Text))
            {
                MessageBox.Show("el campo nombre no puede estar en blanco");
            }
            else
            {
                // actuali mediante sql

                string query = "UPDATE clientes SET nombre = @NuevoNombre, apellido = @NuevoApellido, telefono = @NuevoTelefono, direccion = @NuevaDirecion, RTN =@NuevoRTN WHERE idclientes= @ID";
                using (SqlConnection conexion = new SqlConnection(Program.connectionString))
                {


                    using (SqlCommand command = new SqlCommand(query, conexion))
                    {
                        conexion.Open();
                        // Agrega parámetros a la consulta para prevenir SQL injection
                        command.Parameters.AddWithValue("@Nuevonombre", nombre);
                        command.Parameters.AddWithValue("@NuevoApellido", apellido);
                        command.Parameters.AddWithValue("@NuevoTelefono", telefono);
                        command.Parameters.AddWithValue("@NuevoRTN", rtn);
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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtid.Text);
            string query = "DELETE FROM clientes WHERE idclientes = @ID";
            using (SqlConnection conexion = new SqlConnection(Program.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                    conexion.Open();
                    // Agrega parámetros a la consulta para prevenir SQL injection
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

        private void txttelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // valida que solo se ingresen numeros
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            // valida que se pueda borrar
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void txtrtn_KeyPress(object sender, KeyPressEventArgs e)
        {
            // valida que solo se ingresen numeros
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            // valida que se pueda borrar
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
        }
    }
}
