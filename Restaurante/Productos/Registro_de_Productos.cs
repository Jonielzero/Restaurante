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
                cbbus.SelectedIndex = 0; // Opción predeterminada
                //hace que la columna precio se muestre con formato de moneda   
                dgv1.Columns["precio"].DefaultCellStyle.Format = "c";
                // hace que el datagridview sea responsivo
                dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void btnbus_Click(object sender, EventArgs e)
        {
            // Buscar proveedores utilizando el campo seleccionado en el combobox y el texto ingresado en el textbox
            // compara los resultados del combobox con los campos de la tabla proveedores
            string selectedOption = cbbus.SelectedItem.ToString();
            string aaaa = "";

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
            string query = "select * from productos where " + aaaa + " like '%" + txtbus.Text + "%'";
            using (SqlConnection conexion = new SqlConnection(Program.connectionString))
            {
                conexion.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conexion);
                DataTable dataTable = new DataTable();
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
