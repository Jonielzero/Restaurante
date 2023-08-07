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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlTypes;

namespace Restaurante
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void FormSecundario_Resize(object sender, EventArgs e)
        {
            // Código para ajustar tamaños y posiciones de controles en respuesta al cambio de tamaño
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = txtnombre.Text;
            decimal precio = decimal.Parse(txtprecio.Text);
            int cantidad = int.Parse(txtcantidad.Text);
            DateTime fechaelaboracion = dtpelaboracion.Value;
            DateTime fechavencimiento = dtpvencimiento.Value;
            string proveedor = txtproveedor.Text;

            // Crea el comando SQL para la inserción
            string insertQuery = "INSERT INTO Productos (nombre_producto, precio, cantidad, f_elaboracion, f_vencimiento, proveedor) " +
                                 "VALUES (@nombre_producto, @precio, @cantidad, @f_elaboracion, @f_vencimiento, @proveedor)";

            using (SqlConnection conexion = new SqlConnection(Program.connectionString))
            {
                

                using (SqlCommand command = new SqlCommand(insertQuery, conexion))
                {
                    //try
                    //{
                        conexion.Open();

                        Console.WriteLine("Conexión establecida con éxito.");
                        // Agrega parámetros a la consulta para prevenir SQL injection
                        command.Parameters.AddWithValue("@nombre_producto", nombre);
                        command.Parameters.AddWithValue("@precio", precio);
                        command.Parameters.AddWithValue("@cantidad", cantidad);
                        command.Parameters.AddWithValue("@f_elaboracion", fechaelaboracion);
                        command.Parameters.AddWithValue("@f_vencimiento", fechavencimiento);
                        command.Parameters.AddWithValue("@proveedor", proveedor);

                         // Ejecuta la consulta
                        command.ExecuteNonQuery();

                        MessageBox.Show("Producto insertado con éxito.");

                   // }
                   // catch (Exception ex)
                   // {
                     //   Console.WriteLine("Error al conectarse a la base de datos: " + ex.Message);
                    //}
                    
                }
            }
        }
       





        }
}

