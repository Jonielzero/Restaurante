using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Restaurante
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
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
            string query2 = "select * from productos ORDER BY id_producto DESC";
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

        private void button1_Click(object sender, EventArgs e)
        {

            Proveedores proveedorid = (Proveedores)cbproveedores.SelectedItem;
            string nombre = txtnombre.Text;
            decimal precio = decimal.Parse(txtprecio.Text);
            int cantidad = int.Parse(txtcantidad.Text);
            DateTime fechaelaboracion = dtpelaboracion.Value;
            DateTime fechavencimiento = dtpvencimiento.Value;
            int proveedor = proveedorid.ID;

            if (string.IsNullOrWhiteSpace(txtnombre.Text) || cantidad == 0 || precio == 0)
            {
                MessageBox.Show("el campo nombre no puede estar en blanco");
            }
            else
            {
                // insercion mediante sql
                string insertQuery = "INSERT INTO Productos (nombre_producto, precio, cantidad, f_elaboracion, f_vencimiento, proveedor) " +
                                     "VALUES (@nombre_producto, @precio, @cantidad, @f_elaboracion, @f_vencimiento, @proveedor)";

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
            cbproveedores.DropDownStyle = ComboBoxStyle.DropDownList; // Cambia el estilo para desplegar la lista
            cbproveedores.Focus(); // Establece el foco en el ComboBox
        }
    }
}

