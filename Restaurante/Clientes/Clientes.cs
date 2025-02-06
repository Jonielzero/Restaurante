using Restaurante.Clases;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using Restaurante.Ventas;

namespace Restaurante.Clientes
{
    public partial class Clientes : Form
    {
        private Form3 formpadre;

        public Clientes(Form3 padre)
        {
            InitializeComponent();
            this.formpadre = padre;
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
        private void cargardatos()
        {
            string query = "SELECT * FROM clientes";
            using (SqlConnection conexion = new SqlConnection(Program.connectionString))
            {
                conexion.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conexion))
                {
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);
                    dataGridView1.DataSource = tabla;
                    //datagridview responsivo
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
        }
        private void limpiar()
        {
            txtnombre.Clear();
            txtapellido.Clear();
            txtdireccion.Clear();
            txttelefono.Clear();
            txtrtn.Clear();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text == "" || txtapellido.Text == "" || txttelefono.Text == "")
            {
                MessageBox.Show("Por favor llene todos los campos.");
                return;
            }
            //programa el boton para que ingrese los registros de los textbox a la tabla Clientes
            string nombre = txtnombre.Text;
            string apellido = txtapellido.Text;
            string direccion = txtdireccion.Text;
            int telefono = int.Parse(txttelefono.Text);
            string rtn = txtrtn.Text;
            // ingresa estos datos en la tabla clientes
            string query = "INSERT INTO clientes (nombre, apellido, direccion, telefono, rtn)" +
                            "VALUES (@nombre, @apellido, @direccion, @telefono, @rtn)";
            //haz la coneccion pra ingresar estos datos
            using (SqlConnection conexion = new SqlConnection(Program.connectionString))
            {
                conexion.Open();
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@apellido", apellido);
                    cmd.Parameters.AddWithValue("@direccion", direccion);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@rtn", rtn);
                    //ejecuta la coneccion
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Nuevo Cliente agregado con éxito.");
                }
            }
            cargardatos();
            limpiar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            registro_clientes childForm = new registro_clientes();
            //registro.Show();
            Form3 form3 = new Form3();

            if (form3.activeForm != null)
            {
                form3.activeForm.Close();
            }
            Panel paneldelpadre = formpadre.obtrenerpanel();
            form3.activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            paneldelpadre.Controls.Add(childForm);
            paneldelpadre.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            cargardatos();
            LoadTheme();
        }

        private void txttelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            //valida que solo se ingresen numeros en el textbox de telefono
            if (e.KeyChar == Convert.ToChar(Keys.Tab) || e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtdireccion.Focus();
            }
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {

                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            //valida que no se ingresen mas de 8 numeros en el textbox de telefono
            if (txttelefono.Text.Length == 8)
            {
                e.Handled = true;
            }
        }

        private void txtrtn_KeyPress(object sender, KeyPressEventArgs e)
        {
            // valida que solo se ingresen numeros en el textbox de rtn
            if (e.KeyChar == Convert.ToChar(Keys.Tab) || e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                button1_Click(sender, e);
            }
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {

                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }

        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Tab) || e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtapellido.Focus();
            }
        }

        private void txtapellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Tab) || e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txttelefono.Focus();
            }
        }

        private void txtdireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Tab) || e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtrtn.Focus();
            }
        }
    }
}
