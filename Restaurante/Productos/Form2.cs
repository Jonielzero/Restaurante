using Restaurante.Clases;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Restaurante
{
    public partial class Form2 : Form
    {
        public Form2()
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
                    lbl.Font = Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

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

            foreach (Control tbs in panel1.Controls)
            {
                if (tbs.GetType() == typeof(TextBox))
                {
                    TextBox tb = (TextBox)tbs;
                    tb.BackColor = ThemeColor.SecondaryColor;
                    tb.ForeColor = Color.White;

                }
            }
            foreach (Control dtps in panel1.Controls)
            {
                if (dtps.GetType() == typeof(DateTimePicker))
                {
                    DateTimePicker dtp = (DateTimePicker)dtps;
                    dtp.CalendarMonthBackground = ThemeColor.SecondaryColor;
                    dtp.CalendarForeColor = Color.White;

                }
            }


        }
        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void FormSecundario_Resize(object sender, EventArgs e)
        {

        }
        private DataTable dataTable;
        private void CargarDatos()
        {
            string query2 = "SELECT i.id_producto, i.nombre_producto, i.codigo_barras, i.precio, i.cantidad, i.f_elaboracion, " +
                "i.f_vencimiento, p.nombre_proveedor FROM productos i " +
                "JOIN proveedores p on i.proveedor = p.id_proveedor " +
                "ORDER BY id_producto DESC";
            using (SqlConnection conexion = new SqlConnection(Program.connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query2, conexion);
                dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //hace que la columna precio se muestre con formato de moneda
                dataGridView1.Columns["precio"].DefaultCellStyle.Format = "c";

            }
        }
        private bool ValidarCampos()
        {
            if (txtnombre.Text == "")
            {
                MessageBox.Show("ingrese un nombre.");
                return false;
            }
            if (cbproveedores.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un proveedor.");
                return false;
            }
            if (txtprecio.Text == "")
            {
                MessageBox.Show("Ingrese un precio.");
                return false;
            }
            if (txtcantidad.Text == "")
            {
                MessageBox.Show("Ingrese una cantidad.");
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
            {
                return;
            }
            Proveedores proveedorid = (Proveedores)cbproveedores.SelectedItem;
            string nombre = txtnombre.Text;
            decimal precio = decimal.Parse(txtprecio.Text);
            int cantidad = int.Parse(txtcantidad.Text);
            DateTime fechaelaboracion = dtpelaboracion.Value;
            DateTime fechavencimiento = dtpvencimiento.Value;
            int proveedor = proveedorid.ID;
            string codigo = txtcodigo.Text;

            if (string.IsNullOrWhiteSpace(txtnombre.Text) || cantidad == 0 || precio == 0)
            {
                MessageBox.Show("el campo nombre no puede estar en blanco y la cantidad o precio no pueden ser 0");
            }
            else
            {
                // insercion mediante sql
                string insertQuery = "INSERT INTO Productos (nombre_producto, precio, cantidad, f_elaboracion, f_vencimiento, proveedor, codigo_barras) " +
                                     "VALUES (@nombre_producto, @precio, @cantidad, @f_elaboracion, @f_vencimiento, @proveedor, @codigo)";

                using (SqlConnection conexion = new SqlConnection(Program.connectionString))
                {


                    using (SqlCommand command = new SqlCommand(insertQuery, conexion))
                    {
                        try
                        {
                            conexion.Open();

                            Console.WriteLine("Conexión establecida con éxito.");
                            // Agrega parámetros a la consulta para prevenir SQL injection
                            command.Parameters.AddWithValue("@nombre_producto", nombre);
                            command.Parameters.AddWithValue("@precio", precio);
                            command.Parameters.AddWithValue("@cantidad", cantidad);
                            command.Parameters.AddWithValue("@f_elaboracion", fechaelaboracion);
                            command.Parameters.AddWithValue("@f_vencimiento", fechavencimiento);
                            command.Parameters.AddWithValue("@proveedor", proveedor);
                            command.Parameters.AddWithValue("@codigo", codigo);



                            // Ejecuta la consulta
                            command.ExecuteNonQuery();

                            MessageBox.Show("Producto insertado con éxito.");
                            //SqlDataReader reader = command.ExecuteReader();


                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error al conectarse a la base de datos: " + ex.Message);
                        }

                    }
                }
            }
            CargarDatos();

        }
        public class Proveedores
        {
            public int ID { get; set; }
            public string Nombre { get; set; }

            public override string ToString()
            {
                return Nombre;
            }
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            LoadTheme();
            CargarDatos();
            string query1 = "select id_proveedor, nombre_proveedor from proveedores";

            using (SqlConnection conexion = new SqlConnection(Program.connectionString))
            {
                conexion.Open();

                using (SqlCommand command = new SqlCommand(query1, conexion))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int idProveedor = (int)reader["id_proveedor"];
                        string nombreProveedor = reader["nombre_proveedor"].ToString();

                        cbproveedores.Items.Add(new Proveedores { ID = idProveedor, Nombre = nombreProveedor });
                        cbproveedores.SelectedIndex = 0;
                    }

                    reader.Close();
                }
            }

            cbproveedores.DisplayMember = "Nombre";
            cbproveedores.ValueMember = "ID";

            cbproveedores.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbproveedores.AutoCompleteSource = AutoCompleteSource.ListItems;
            //cbproveedores.DropDownStyle = ComboBoxStyle.Simple;
        }

        private void dataGridView1_Load(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registro_de_Productos formreg = new Registro_de_Productos();
            formreg.Show();
        }

        private void cbproveedores_Click(object sender, EventArgs e)
        {

        }

        private void cbproveedores_Click_1(object sender, EventArgs e)
        {
            cbproveedores.DroppedDown = true;
        }

        private void txtprecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '.')
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

        private void txtcantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '.')
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
    }
}

