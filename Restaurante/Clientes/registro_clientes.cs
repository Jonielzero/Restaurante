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
    public partial class registro_clientes : Form
    {
        public registro_clientes()
        {
            InitializeComponent();
        }

        private void registro_clientes_Load(object sender, EventArgs e)
        {
            // aqui se llena el data grid view con los datos de la tabla clientes
            string query = "SELECT * FROM clientes";
            using (SqlConnection conexion = new SqlConnection(Program.connectionString))
            {
                conexion.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conexion))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgv1.DataSource = table;
                    //responsivo
                    dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    cbbus.Items.Add("ID");
                    cbbus.Items.Add("Nombre");
                    cbbus.Items.Add("Apellido");
                    cbbus.Items.Add("Direccion");

                    cbbus.SelectedIndex = 1;
                }
            }
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            Editar_clientes editar = new Editar_clientes();
            editar.Show();
        }

        private void btnbus_Click(object sender, EventArgs e)
        {
            string selectedOption = cbbus.SelectedItem.ToString();
            string aaaa = "";

            if (selectedOption == "ID")
            {
                aaaa = "idclientes";
            }
            else if (selectedOption == "Nombre")
            {
                aaaa = "nombre";
            }
            else if (selectedOption == "Apellido")
            {
                aaaa = "apellido";
            }
            else if (selectedOption == "Direccion")
            {
                aaaa = "direccion";
            }
            string query = "select * from clientes where " + aaaa + " like '%" + txtbus.Text + "%'";
            using (SqlConnection conexion = new SqlConnection(Program.connectionString))
            {
                conexion.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dgv1.DataSource = dataTable;
            }



        }

        private void txtbus_KeyPress(object sender, KeyPressEventArgs e)
        {
            //hace que el enter funcione como un click en el boton buscar
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnbus.PerformClick();
            }

        }
    }
}
