using Restaurante.Clases;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace Restaurante.Clientes
{
    public partial class registro_clientes : Form
    {
        

        public registro_clientes()
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
                    lbl.ForeColor = ThemeColor.PrimaryColor;
                    lbl.Font = Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                }
            
       
            }
            foreach (Control pbs in panel2.Controls)
            {
                if (pbs.GetType() == typeof(PictureBox))
                {
                    PictureBox pb = (PictureBox)pbs;
                    pb.BackColor = ThemeColor.PrimaryColor;

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
        private void cargardatos()
        {
            LoadTheme();
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
            //Usuarios.usuarios usuarios = new Usuarios.usuarios();
            //usuarios.Show();
            Editar_clientes editar_Clientes = new Editar_clientes();
            editar_Clientes.Show();
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
