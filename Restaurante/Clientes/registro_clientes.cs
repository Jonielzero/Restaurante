using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Restaurante.Clientes
{
    public partial class registro_clientes : Form
    {
        public registro_clientes()
        {
            InitializeComponent();
        }
        private void cargardatos()
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

                }
            }
        }
        private void registro_clientes_Load(object sender, EventArgs e)
        {
            cargardatos();
        }

        private void btneditar_Click(object sender, EventArgs e)
        {

            Program.permiso = "cliente";
            Usuarios.usuarios usuarios = new Usuarios.usuarios();
            usuarios.Show();
        }

        private void btnbus_Click(object sender, EventArgs e)
        {

            string query = "select * from clientes where idclientes like '%" + txtbus.Text + "%' OR nombre like '%" +
                            txtbus.Text + "%' OR apellido like '%" + txtbus.Text + "%' OR direccion like '%" + txtbus.Text + "%'";
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

        private void btnactu_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            cargardatos();
        }
    }
}
