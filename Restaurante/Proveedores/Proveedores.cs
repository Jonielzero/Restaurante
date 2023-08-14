using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurante.Proveedores
{
    public partial class Proveedores : Form
    {
        public Proveedores()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string proveedores = txtproveedores.Text;
            string contacto = txtcontacto.Text;
            int telefono = int.Parse(txttelefono.Text);
            string email    = txtemail.Text;
            string direccion = txtdireccion.Text;
            bool disponible = checkdisp.Checked;
            byte[] estado = BitConverter.GetBytes(disponible);

            string query = "INSERT INTO proveedores (nombre_proveedor, nombre_contacto, telefono, email, direccion, disponible)" +
                            "VALUES (@nombre, @contacto, @telefono, @email, @direccion, @disponible)";

            using (SqlConnection conexion = new SqlConnection(Program.connectionString))
            {
                conexion.Open();
                using(SqlCommand cmd = new SqlCommand(query, conexion)) 
                {
                    cmd.Parameters.AddWithValue("@nombre", proveedores);
                    cmd.Parameters.AddWithValue("@contacto", contacto);
                    cmd.Parameters.AddWithValue ("@email", email);
                    cmd.Parameters.AddWithValue("@telefono", telefono);
                    cmd.Parameters.AddWithValue("@direccion", direccion);
                    cmd.Parameters.AddWithValue("@disponible", estado);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Nuevo Proveedor agregado con éxito.");
                }
            }
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
    }
}
