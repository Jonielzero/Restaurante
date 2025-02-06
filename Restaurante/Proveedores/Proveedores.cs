using Restaurante.Clases;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace Restaurante.Proveedores
{
    public partial class Proveedores : Form
    {
        public Proveedores()
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
                    lbl.Font = Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

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
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private bool validarcampos()
        {
            if (txtproveedores.Text == "")
            {
                MessageBox.Show("Debe ingresar el nombre del proveedor");
                return false;
            }
            if (txtcontacto.Text == "")
            {
                MessageBox.Show("Debe ingresar el nombre del contacto");
                return false;
            }
            if (txttelefono.Text == "")
            {
                MessageBox.Show("Debe ingresar el número de teléfono");
                return false;
            }
            return true;

        }
        private void limpiarcampos()
        {
            txtcontacto.Text = "";
            txtdireccion.Text = "";
            txtemail.Text = "";
            txtproveedores.Text = "";
            txttelefono.Text = "";

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!validarcampos())
            {
                return;
            }
            else
            {
                string proveedores = txtproveedores.Text;
                string contacto = txtcontacto.Text;
                int telefono = int.Parse(txttelefono.Text);
                string email = txtemail.Text;
                string direccion = txtdireccion.Text;

                string query = "INSERT INTO proveedores (nombre_proveedor, nombre_contacto, telefono, email, direccion)" +
                                "VALUES (@nombre, @contacto, @telefono, @email, @direccion)";

                using (SqlConnection conexion = new SqlConnection(Program.connectionString))
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@nombre", proveedores);
                        cmd.Parameters.AddWithValue("@contacto", contacto);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@telefono", telefono);
                        cmd.Parameters.AddWithValue("@direccion", direccion);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Nuevo Proveedor agregado con éxito.");
                    }
                }
                limpiarcampos();
            }
            CargarDatos();
        }
        public DataTable dataTable;
        public static void clo()
        {
            Proveedores pro = new Proveedores();
            pro.Close();
        }
        private void CargarDatos()
        {
            string query2 = "select id_proveedor, nombre_proveedor, nombre_contacto, telefono, email, direccion from proveedores ORDER BY id_proveedor DESC";
            using (SqlConnection conexion = new SqlConnection(Program.connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query2, conexion);
                dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }
        private void Proveedores_Load(object sender, EventArgs e)
        {
            CargarDatos();
            LoadTheme();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "disponible" && e.RowIndex >= 0)
                {
                    if (e.Value != null && e.Value != DBNull.Value)
                    {
                        if ((int)e.Value != 1)
                        {
                            e.Value = "Sí";
                        }
                        else
                        {
                            e.Value = "No";
                        }
                        e.FormattingApplied = true;
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registro_proveedores reg = new Registro_proveedores();
            reg.Show();
        }

        private void txttelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("Solo se permiten números");
            }

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtemail.Focus();
            }
        }

        private void txtproveedores_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtcontacto.Focus();
            }
        }

        private void txtcontacto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txttelefono.Focus();
            }
        }

        private void txtemail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtdireccion.Focus();
            }
        }

        private void txtdireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                button1_Click(sender, e);
            }
        }
    }
}
