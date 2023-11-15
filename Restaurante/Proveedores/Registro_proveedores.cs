using System;
using System.Data;
using System.Data.SqlClient; // Librería para conectarse a SQL Server
using System.Windows.Forms;

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

                dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
        }

        private void btnbus_Click(object sender, EventArgs e)
        {
            //hace una busqueda por id, nombre de contacto o nombre de proveedor
            string query = "select * from proveedores where id_proveedor like '%" + txtbus.Text + "%' OR nombre_proveedor like '%" +
                txtbus.Text + "%' OR nombre_contacto like '%" + txtbus.Text + "%'";
            using (SqlConnection conexion = new SqlConnection(Program.connectionString))
            {
                conexion.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dgv1.DataSource = dataTable;
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
            Program.permiso = "proveedores";
            Usuarios.usuarios us = new Usuarios.usuarios();
            us.Show();
        }

        private void btnactu_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            cargardatos();
        }

        private void txtbus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnbus_Click(sender, e);
            }
        }
    }
}
