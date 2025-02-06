using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using Restaurante.Clases;

namespace Restaurante.Productos
{
    public partial class agregarproducto : Form
    {
        private Form3 formpadre;
        public agregarproducto(Form3 padre )
        {
            InitializeComponent();
            this.formpadre = padre;
        }
        private void LoadTheme()
        {
            foreach (Control btns in panel3.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            foreach (Control btns in panel4.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            foreach (Control btns in panel5.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            foreach (Control cbs in panel2.Controls)
            {
                if (cbs.GetType() == typeof(ComboBox))
                {
                    ComboBox cb = (ComboBox)cbs;
                    cb.BackColor = ThemeColor.SecondaryColor;
                    cb.ForeColor = Color.White;
                }
            }
            foreach (Control lbs in panel2.Controls)
            {
                if (lbs.GetType() == typeof(Label))
                {
                    Label lbl = (Label)lbs;
                    lbl.ForeColor = ThemeColor.PrimaryColor;
                }
            }
            foreach (Control tbs in panel2.Controls)
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
        private DataTable dt = new DataTable();
        private void cargardatos()
        {
            string query = "SELECT id_producto, nombre_producto, codigo_barras, cantidad, precio FROM productos";
            using (SqlConnection conexion = new SqlConnection(Program.connectionString))
            {
                conexion.Open();
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.Columns["precio"].DefaultCellStyle.Format = "c";
                    cbnombre.DataSource = dt;
                    cbnombre.DisplayMember = "nombre_producto";
                    cbnombre.ValueMember = "nombre_producto";
                    cbnombre.SelectedIndex = -1;
                    cbnombre.Text = "Seleccione un producto";
                    cbnombre.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cbnombre.AutoCompleteSource = AutoCompleteSource.ListItems;
                }
            }
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtcantidad.Text == "")
                {
                    MessageBox.Show("Agrege una cantidad");
                    return;
                }
                //sumar productos
                string query = "UPDATE productos " +
                                "SET cantidad = cantidad + @agregar " +
                                "WHERE nombre_producto = @nombre";
                using (SqlConnection conexion = new SqlConnection(Program.connectionString))
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        string nombre = cbnombre.SelectedValue.ToString();
                        int cantidad = int.Parse(txtcantidad.Text);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@agregar", cantidad);
                        cmd.ExecuteNonQuery();
                        txtcantidad.Text = cantidad.ToString();

                        MessageBox.Show("se han agregado " + cantidad + " nuevos productos a " + nombre);
                    }
                }
                //limpia el datagridview
                dt.Clear();
                cargardatos();
                txtcantidad.Clear();
            }
            catch
            {
                MessageBox.Show("Seleccione un producto que agregar");
            }
        }


        private void agregarproducto_Load(object sender, EventArgs e)
        {
            cargardatos();

            LoadTheme();
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            Form2 childForm = new Form2();
            //form2.ShowDialog();
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

        private void txtcantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }

            //permite teclas de control como retroceso
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void cbnombre_Click(object sender, EventArgs e)
        {
            cbnombre.DroppedDown = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registro_de_Productos childForm = new Registro_de_Productos();
            //form2.ShowDialog();
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
    }
}
