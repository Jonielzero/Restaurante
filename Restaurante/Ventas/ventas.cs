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
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //hace que la columna precio se muestre con formato de moneda
                dataGridView1.Columns["precio"].DefaultCellStyle.Format = "c";
                dataGridView1.Columns["total"].DefaultCellStyle.Format = "c";
                //dale formato fecha y hora a la columna fechaventa
                dataGridView1.Columns["fechaventa"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm:ss";
                dataGridView1.Columns["idventas"].HeaderText = "ID";
                dataGridView1.Columns["idproductos"].HeaderText = "Producto";
                dataGridView1.Columns["id_clientes"].HeaderText = "ID Cliente";
                dataGridView1.Columns["fechaventa"].HeaderText = "Fecha de venta";
                dataGridView1.Columns["cantidad"].HeaderText = "Cantidad";
                dataGridView1.Columns["precio"].HeaderText = "Precio";
                dataGridView1.Columns["descripcionventa"].HeaderText = "Descripción";
                dataGridView1.Columns["total"].HeaderText = "Total";

            }
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
            DateTime fechaVenta = DateTime.Now;
            int cantidad = Convert.ToInt32(txtcantidad.Text);
            decimal precio = Convert.ToDecimal(txtprecio.Text);
            string descripcion = txtdescripcion.Text;
            decimal total = cantidad * precio;
            string query = "insert into ventas (idproductos, id_clientes, fechaventa, cantidad, precio, descripcionventa, total) values (@idProducto, @idCliente, @fechaVenta, @cantidad, @precio, @descripcion, @total)";

            using (SqlConnection conexion = new SqlConnection(Program.connectionString))
            {
                conexion.Open();
                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                    command.Parameters.AddWithValue("@idProducto", idProducto);
                    command.Parameters.AddWithValue("@idCliente", idCliente);
                    command.Parameters.AddWithValue("@fechaVenta", fechaVenta);
                    command.Parameters.AddWithValue("@cantidad", cantidad);
                    command.Parameters.AddWithValue("@precio", precio);
                    command.Parameters.AddWithValue("@descripcion", descripcion);
                    command.Parameters.AddWithValue("@total", total);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Venta registrada con éxito", "Venta registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    cbproducto.SelectedIndex = -1;
                    cbcliente.SelectedIndex = -1;
                    txtcantidad.Clear();
                    txtprecio.Clear();
                    txtdescripcion.Clear();
                }
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
    }
}
