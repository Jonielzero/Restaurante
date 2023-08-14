using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Restaurante.Clientes
{
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //programa el boton para que ingrese los registros de los textbox a la tabla Clientes
            string nombre = txtnombre.Text; 
            string apellido = txtapellido.Text;
            string direccion = txtdireccion.Text;
            int telefono = int.Parse(txttelefono.Text);
            int rtn = int.Parse(txtrtn.Text);
            // ingresa estos datos en la tabla clientes
            string query = "INSERT INTO clientes (nombre, apellido, direccion, telefono, rtn)" +
                            "VALUES (@nombre, @apellido, @direccion, @telefono, @rtn)";
            //haz la coneccion pra ingresar estos datos
            using (SqlConnection conexion = new SqlConnection(Program.connectionString))
            {
                conexion.Open();
                using(SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@apellido", apellido);
                    cmd.Parameters.AddWithValue("@direccion", direccion);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@rtn", rtn);
                    //ejecuta la coneccion
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Nuevo Cliente agregado con éxito.");
                }
            }

        }
    }
}
