using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; // Librería para conectarse a SQL Server
using System.Data.SqlTypes;  // Librería para usar tipos de datos de SQL Server

namespace Restaurante.Proveedores
{
    public partial class Registro_proveedores : Form
    {
        public Registro_proveedores()
        {
            InitializeComponent();
        }

        private void cargardatos()
        {
            string query2 = "select * from proveedores";
            using (SqlConnection conexion = new SqlConnection(Program.connectionString))
            {
                conexion.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query2, conexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dgv1.DataSource = dataTable;

                cbbus.Items.Add("ID");
                cbbus.Items.Add("Nombre de contacto");
                cbbus.Items.Add("Proveedor");
                cbbus.SelectedIndex = 0;
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
                aaaa = "id_proveedor";
            }
            else if (selectedOption == "Nombre de contacto")
            {
                aaaa = "nombre_contacto";
            }
            else if (selectedOption == "Proveedor")
            {
                aaaa = "nombre_proveedor";
            }
            string query = "select * from proveedores where " + aaaa + " like '%" + txtbus.Text + "%'";
            using (SqlConnection conexion = new SqlConnection(Program.connectionString))
            {
                conexion.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dgv1.DataSource = dataTable;
                dgv1.Columns.Remove("disponible");
            }

            

        }

        private void Registro_proveedores_Load(object sender, EventArgs e)
        {
            cargardatos();
        }

        private void dgv1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
           editar_proveedores editar = new editar_proveedores();
            editar.Show();
        }

        private void btnactu_Click(object sender, EventArgs e)
        {
            cargardatos();
        }
    }
}
