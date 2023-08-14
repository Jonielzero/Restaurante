using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Restaurante
{
    public partial class Registro_de_Productos : Form
    {
        private DataTable dataTable; // Almacena los datos originales
        private DataView dataView;   // Almacena los datos filtrados
        public string aaaa;
        public Registro_de_Productos()
        {
            InitializeComponent();
        }

        private void Registro_de_Productos_Load(object sender, EventArgs e)
        {
            string query2 = "select * from productos";
            using (SqlConnection conexion = new SqlConnection(Program.connectionString))
            {
                conexion.Open();



                SqlDataAdapter dataAdapter = new SqlDataAdapter(query2, conexion);
                dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                dgv1.DataSource = dataTable;
                // Configurar el ComboBox de opciones de búsqueda
                cbbus.Items.Add("ID");
                cbbus.Items.Add("Nombre");
                cbbus.Items.Add("Proveedor");
                cbbus.Items.Add("Proveedor");
                cbbus.Items.Add("Proveedor");
                cbbus.Items.Add("Proveedor");
                cbbus.SelectedIndex = 0; // Opción predeterminada
            }
        }

        private void btnbus_Click(object sender, EventArgs e)
        {
            dgv1.ClearSelection();
            string searchTerm = txtbus.Text;
            string selectedOption = cbbus.SelectedItem.ToString();
            

                if (selectedOption == "ID")
                {
                    aaaa = "id_producto";
                }
                else if (selectedOption == "Nombre")
                {
                    aaaa = "nombre_producto";
                }
                else if (selectedOption == "Proveedor")
                {
                    aaaa = "proveedor";
                }
            
            string aaa = aaaa.ToString();
            string busqueda = txtbus.Text.ToString();
            string query2 = "select * from productos WHERE " + aaa + " = " + busqueda;
            using (SqlConnection conexion = new SqlConnection(Program.connectionString))
            {

                SqlDataAdapter dataAdapter = new SqlDataAdapter(query2, conexion);
                dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                dgv1.DataSource = dataTable;

            }
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            editarproducto editp = new editarproducto();
            editp.Show();
        }
    }
}
