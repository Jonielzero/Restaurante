using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurante.Ventas
{
    public partial class ventas : Form
    {
        public ventas()
        {
            InitializeComponent();
        }
        private DataTable dataTable;
        private void CargarDatos()
        {
            string query2 = "select * from ventas ORDER BY idventas DESC";
            using (SqlConnection conexion = new SqlConnection(Program.connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query2, conexion);
                dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
                dataGridView1.Columns["precio"].DefaultCellStyle.Format = "c";
                dataGridView1.Columns["total"].DefaultCellStyle.Format = "c";
                dataGridView1.Columns["fechaventa"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm:ss";
                dataGridView1.Columns["idventas"].HeaderText = "ID de la Venta";
                dataGridView1.Columns["id_clientes"].HeaderText = "ID del Cliente";
                dataGridView1.Columns["fechaventa"].HeaderText = "Fecha de venta";
                dataGridView1.Columns["cantidad"].HeaderText = "Cantidad";
                dataGridView1.Columns["precio"].HeaderText = "Precio";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.Columns["descripcionventa"].HeaderText = "Descripción";
                dataGridView1.Columns["total"].HeaderText = "Total";

            }
        }
        public class Venta
        {
            public string Producto { get; set; }
            public int IDProducto { get; set; }
            public int IDCliente { get; set; }
            public DateTime Fecha { get; set; }
            public int Cantidad { get; set; }
            public decimal Precio { get; set; }
            public string Descripcion { get; set; }
            public decimal Total { get; set; }
        }
        private class getProductos
        {
            public int ID { get; set; }
            public string Nombre { get; set; }
        }

        private class getClientes
        {
            public int ID { get; set; }
            public string Nombre { get; set; }
        }
        private List<Venta> ventasTemporales = new List<Venta>();
        private void AgregarVenta(int idProducto, int idCliente, int cantidad, decimal precio, string descripcion, decimal total)
        {
            string nombreProducto = ObtenerNombreProducto(idProducto);
            Venta venta = new Venta
            {
                Producto = nombreProducto,
                IDProducto = idProducto,
                IDCliente = idCliente,
                Fecha = DateTime.Now,
                Cantidad = cantidad,
                Precio = precio,
                Descripcion = descripcion,
                Total = total
            };

            ventasTemporales.Add(venta);
            MostrarVentasEnGridView();
        }

        private string ObtenerNombreProducto(int idProducto)
        {
            string nombreProducto = "";
            using (SqlConnection conexion = new SqlConnection(Program.connectionString))
            {
                string query = "select nombre_producto from productos where id_producto = @idProducto";
                conexion.Open();
                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                    command.Parameters.AddWithValue("@idProducto", idProducto);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        nombreProducto = reader["nombre_producto"].ToString();
                    }

                    reader.Close();
                }
            }

            return nombreProducto;
            
        }

        private void MostrarVentasEnGridView()
        {
            dataGridViewVentas.DataSource = null;
            dataGridViewVentas.DataSource = ventasTemporales;
            dataGridViewVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Haz que en la columna idproducto se muestre el nombre del producto mostrado en el combobox
            dataGridViewVentas.Columns["IDProducto"].Visible = false;
            dataGridViewVentas.Columns["IDCliente"].Visible = false;
            dataGridViewVentas.Columns["Fecha"].Visible = false;
            dataGridViewVentas.Columns["Precio"].DefaultCellStyle.Format = "c";
            dataGridViewVentas.Columns["Total"].DefaultCellStyle.Format = "c";
        }
        private void EfectuarVenta()
        {
            
            foreach (Venta venta in ventasTemporales)
            {
                string query = "INSERT INTO Ventas (idproductos, id_clientes, Fechaventa, cantidad, precio, descripcionventa, total) " +
                               "VALUES (@IDProducto, @IDCliente, @Fecha, @Cantidad, @Precio, @Descripcion, @Total)";

                using (SqlConnection connection = new SqlConnection(Program.connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IDProducto", venta.IDProducto);
                    command.Parameters.AddWithValue("@IDCliente", venta.IDCliente);
                    command.Parameters.AddWithValue("@Fecha", venta.Fecha);
                    command.Parameters.AddWithValue("@Cantidad", venta.Cantidad);
                    command.Parameters.AddWithValue("@Precio", venta.Precio);
                    command.Parameters.AddWithValue("@Descripcion", venta.Descripcion);
                    command.Parameters.AddWithValue("@Total", venta.Total);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Venta efectuada correctamente.");
            LimpiarVenta();
        }

        private void LimpiarVenta()
        {
            ventasTemporales.Clear();
            MostrarVentasEnGridView();
        }
        private void ventas_Load(object sender, EventArgs e)
        {
            CargarDatos();
            using (SqlConnection conexion = new SqlConnection(Program.connectionString))
            {
                string query1 = "select id_producto, nombre_producto from productos";
                string query2 = "select idclientes, nombre from clientes";

                conexion.Open();
                using (SqlCommand command = new SqlCommand(query1, conexion))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int idProducto = (int)reader["id_producto"];
                        string nombreProducto = reader["nombre_producto"].ToString();

                        cbproducto.Items.Add(new getProductos { ID = idProducto, Nombre = nombreProducto });
                        
                    }

                    reader.Close();
                }
                using (SqlCommand command = new SqlCommand(query2, conexion))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int idCliente = (int)reader["idclientes"];
                        string nombreCliente = reader["nombre"].ToString();

                        cbcliente.Items.Add(new getClientes { ID = idCliente, Nombre = nombreCliente });
                        
                    }

                    reader.Close();
                }   

            }
            
            cbproducto.DisplayMember = "Nombre";
            cbproducto.ValueMember = "ID";
            cbcliente.DisplayMember = "Nombre";
            cbcliente.ValueMember = "ID";
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            int idProducto = ((getProductos)cbproducto.SelectedItem).ID;
            int idCliente = ((getClientes)cbcliente.SelectedItem).ID;
            int cantidad = Convert.ToInt32(txtcantidad.Text);
            decimal precio = Convert.ToDecimal(txtprecio.Text);
            string descripcion = txtdescripcion.Text;
            decimal total = cantidad * precio;
            AgregarVenta(idProducto, idCliente, cantidad, precio, descripcion, total);
            decimal totalVenta = 0;
            foreach (Venta venta in ventasTemporales)
            {
                totalVenta += venta.Total;
                lvtotal.Text = totalVenta.ToString("C");

            }
        }

        private void txtprecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            //solo permite numeros y un punto decimal
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
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            
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

        private void cbproducto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbproducto_Click(object sender, EventArgs e)
        {
            //desplegar combo box
            cbproducto.DroppedDown = true;
            
        }

        private void cbproducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            //buscar a medida se escribe en el combo box
            if (e.KeyChar == (char)13)
            {
                cbproducto.DroppedDown = true;
                string s = "";
                for (int i = 0; i < cbproducto.Items.Count; i++)
                {
                    s = cbproducto.GetItemText(cbproducto.Items[i]).ToLower();
                    if (s.StartsWith(cbproducto.Text.ToLower()))
                    {
                        cbproducto.SelectedIndex = i;
                        cbproducto.SelectionStart = cbproducto.Text.Length;
                        cbproducto.SelectionLength = cbproducto.Text.Length - cbproducto.SelectionStart;
                        break;
                    }
                }
            }
            

        }

        private void cbcliente_Click(object sender, EventArgs e)
        {
            cbcliente.DroppedDown = true;
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            cbproducto.SelectedIndex = -1;
            cbcliente.SelectedIndex = -1;
            txtcantidad.Clear();
            txtprecio.Clear();
            txtdescripcion.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EfectuarVenta();
            LimpiarVenta();
        }
    }
}
