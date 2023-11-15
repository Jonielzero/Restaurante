using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Restaurante.Productos
{
    public partial class agregarproducto : Form
    {
        public agregarproducto()
        {
            InitializeComponent();
        }
        private DataTable dt = new DataTable();
        private void cargardatos()
        {
            string query = "SELECT id_producto, nombre_producto, cantidad, precio FROM productos";
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
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();

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
    }
}
