using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Restaurante
{
    public partial class Registro_de_Productos : Form
    {
        private DataTable dataTable;

        public Registro_de_Productos()
        {
            InitializeComponent();
        }
        private void cargar()
        {

            string query2 = "SELECT i.id_producto, i.nombre_producto, i.precio, i.cantidad, i.f_elaboracion, " +
                "i.f_vencimiento, p.nombre_proveedor FROM productos i " +
                "JOIN proveedores p on i.proveedor = p.id_proveedor " +
                "ORDER BY id_producto DESC";
            using (SqlConnection conexion = new SqlConnection(Program.connectionString))
            {
                conexion.Open();



                SqlDataAdapter dataAdapter = new SqlDataAdapter(query2, conexion);
                dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                dgv1.DataSource = dataTable;

                //hace que la columna precio se muestre con formato de moneda   
                dgv1.Columns["precio"].DefaultCellStyle.Format = "c";
                // hace que el datagridview sea responsivo
                dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }
        private void Registro_de_Productos_Load(object sender, EventArgs e)
        {

            cargar();
        }

        private void btnbus_Click(object sender, EventArgs e)
        {

            string query = "SELECT i.id_producto, i.nombre_producto, i.precio, i.cantidad, i.f_elaboracion, " +
                "i.f_vencimiento, p.nombre_proveedor FROM productos i " +
                "JOIN proveedores p on i.proveedor = p.id_proveedor " +
                "WHERE i.id_producto like '%" + txtbus.Text + "%' OR i.nombre_producto like '%" + txtbus.Text +
                "%' OR p.nombre_proveedor like '%" + txtbus.Text + "%' " +
                "ORDER BY id_producto DESC";
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
            Program.permiso = "producto";
            Usuarios.usuarios us = new Usuarios.usuarios();
            us.Show();
        }

        private void btnactu_Click(object sender, EventArgs e)
        {

        }

        private void txtbus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnbus_Click(sender, e);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            cargar();
        }
    }
}
