using Restaurante.Clases;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
namespace Restaurante
{
    public partial class Registro_de_Productos : Form
    {
        private DataTable dataTable;

        public Registro_de_Productos()
        {
            InitializeComponent();
        }
        private void LoadTheme()
        {
            foreach (Control btns in panel1.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            
            foreach (Control cbs in panel1.Controls)
            {
                if (cbs.GetType() == typeof(ComboBox))
                {
                    ComboBox cb = (ComboBox)cbs;
                    cb.BackColor = ThemeColor.SecondaryColor;
                    cb.ForeColor = Color.White;
                }
            }
            foreach (Control lbs in panel1.Controls)
            {
                if (lbs.GetType() == typeof(Label))
                {
                    Label lbl = (Label)lbs;
                    lbl.ForeColor = Color.White;
                }
            }
            foreach (Control tbs in panel1.Controls)
            {
                if (tbs.GetType() == typeof(TextBox))
                {
                    TextBox tb = (TextBox)tbs;
                    tb.BackColor = ThemeColor.SecondaryColor;
                    tb.ForeColor = Color.White;

                }
            }
            foreach (Control dgvs in panel1.Controls)
            {
                if (dgvs.GetType() == typeof(DataGridView))
                {
                    DataGridView dgv = (DataGridView)dgvs;
                    dgv.BackgroundColor = ThemeColor.SecondaryColor;
                    dgv.GridColor = ThemeColor.PrimaryColor;
                    dgv.ForeColor = Color.White;
                    //System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
                    dgv.AlternatingRowsDefaultCellStyle.BackColor = ThemeColor.PrimaryColor;
                    dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.White;
                    dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = ThemeColor.SecondaryColor;
                    dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.White;
                    dgv.DefaultCellStyle.BackColor = ThemeColor.PrimaryColor;
                    dgv.DefaultCellStyle.ForeColor = Color.White;
                    dgv.DefaultCellStyle.SelectionBackColor = ThemeColor.SecondaryColor;
                    dgv.DefaultCellStyle.SelectionForeColor = Color.White;
                }
            }
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
            LoadTheme();
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
            /*Program.permiso = "producto";
            Usuarios.usuarios us = new Usuarios.usuarios();
            us.Show();*/
            editarproducto editarproducto = new editarproducto();
            editarproducto.Show();
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
