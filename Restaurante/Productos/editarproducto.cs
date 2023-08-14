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
using static Restaurante.Form2;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Restaurante
{
    public partial class editarproducto : Form
    {
        public editarproducto()
        {
            InitializeComponent();
        }
        public class Proveedores
        {
            public int ID { get; set; }
            public string Nombre { get; set; }

            public override string ToString()
            {
                return Nombre;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtid.Text);
            Proveedores proveedorid = (Proveedores)cbproveedores.SelectedItem;
            string nombre = txtnombre.Text;
            decimal precio = decimal.Parse(txtprecio.Text);
            int cantidad = int.Parse(txtcantidad.Text);
            DateTime fechaelaboracion = dtpelaboracion.Value;
            DateTime fechavencimiento = dtpvencimiento.Value;
            int proveedor = proveedorid.ID;

            if (string.IsNullOrWhiteSpace(txtnombre.Text) || cantidad == 0 || precio == 0)
            {
                MessageBox.Show("el campo nombre no puede estar en blanco");
            }
            else
            {
                // actuali mediante sql

                string query = "UPDATE Productos SET nombre_producto = @NuevoNombre, precio = @NuevoPrecio, cantidad = @NuevaCantidad, f_elaboracion = @NuevaF_Elab, f_vencimiento = @NuevaF_venc, proveedor =@NuevoProveedor WHERE id_producto = @ID";
                using (SqlConnection conexion = new SqlConnection(Program.connectionString))
                {


                    using (SqlCommand command = new SqlCommand(query, conexion))
                    {
                            conexion.Open();
                            // Agrega parámetros a la consulta para prevenir SQL injection
                            command.Parameters.AddWithValue("@Nuevonombre", nombre);
                            command.Parameters.AddWithValue("@NuevoPrecio", precio);
                            command.Parameters.AddWithValue("@NuevaCantidad", cantidad);
                            command.Parameters.AddWithValue("@Nuevaf_elab", fechaelaboracion);
                            command.Parameters.AddWithValue("@Nuevaf_venc", fechavencimiento);
                            command.Parameters.AddWithValue("@Nuevoproveedor", proveedor);
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

        private void editarproducto_Load(object sender, EventArgs e)
        {
             string query1 = "select id_proveedor, nombre_proveedor from proveedores";

            using (SqlConnection conexion = new SqlConnection(Program.connectionString))
            {
                conexion.Open();

                using (SqlCommand command = new SqlCommand(query1, conexion))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int idProveedor = (int)reader["id_proveedor"];
                        string nombreProveedor = reader["nombre_proveedor"].ToString();

                        cbproveedores.Items.Add(new Proveedores { ID = idProveedor, Nombre = nombreProveedor });
                        cbproveedores.SelectedIndex = 0;
                    }

                    reader.Close();
                }
            }

            cbproveedores.DisplayMember = "Nombre";
            cbproveedores.ValueMember = "ID";
            cbproveedores.DropDownStyle = ComboBoxStyle.Simple;
        }

        private void cbproveedores_Click(object sender, EventArgs e)
        {
            cbproveedores.DropDownStyle = ComboBoxStyle.DropDownList; // Cambia el estilo para desplegar la lista
            cbproveedores.Focus(); // Establece el foco en el ComboBox
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtid.Text); 
            
            string query = "DELETE FROM Productos WHERE id_producto = @ID";

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

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
