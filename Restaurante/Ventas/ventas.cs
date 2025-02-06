﻿using Restaurante.Clases;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using Restaurante._Infrastructure;

namespace Restaurante.Ventas
{
    public partial class ventas : Form
    {
        private Form3 formpadre;
        public ventas(Form3 padre )
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
            foreach (Control cbs in panel3.Controls)
            {
                if (cbs.GetType() == typeof(ComboBox))
                {
                    ComboBox cb = (ComboBox)cbs;
                    cb.BackColor = ThemeColor.SecondaryColor;
                    cb.ForeColor = Color.White;
                }
            }
            foreach (Control tbs in panel3.Controls)
            {
                if (tbs.GetType() == typeof(TextBox))
                {
                    TextBox tb = (TextBox)tbs;
                    tb.BackColor = ThemeColor.SecondaryColor;
                    tb.ForeColor = Color.White;
                }
            }
            foreach (Control dgvs in panel5.Controls)
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
            foreach (Control dgvs in panel1.Controls)
            {
                if (dgvs.GetType() == typeof(DataGridView))
                {
                    DataGridView dgv = (DataGridView)dgvs;
                    dgv.BackgroundColor = ThemeColor.SecondaryColor;
                    dgv.GridColor = ThemeColor.PrimaryColor;
                    dgv.ForeColor = Color.White;
                   // System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
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
           /* foreach (Control lbs in panelc.Controls)
            {
                if (lbs.GetType() == typeof(Label))
                {
                    Label lbl = (Label)lbs;
                    lbl.ForeColor = ThemeColor.PrimaryColor;
                    lbl.Font = Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                }
            }*/
        }
        private DataTable dataTable;
        private void CargarDatos()
        {
            string query2 = "SELECT v.idventas, p.nombre_producto, c.nombre cliente, v.fechaventa, v.precio, " +
                "v.cantidad, v.descripcionventa, v.total FROM Ventas v " +
                "JOIN productos p on v.idproductos = p.id_producto " +
                "JOIN clientes c on v.id_clientes = c.idclientes  " +
                "WHERE v.fechaventa BETWEEN CONVERT(DATE, GETDATE()) AND GETDATE() ORDER BY idventas DESC";
            using (SqlConnection conexion = new SqlConnection(Program.connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query2, conexion);
                dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
                dataGridView1.Columns["fechaventa"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm:ss";
                dataGridView1.Columns["idventas"].HeaderText = "ID de la Venta";
                dataGridView1.Columns["cliente"].HeaderText = "Cliente";
                dataGridView1.Columns["fechaventa"].HeaderText = "Fecha de venta";
                dataGridView1.Columns["cantidad"].HeaderText = "Cantidad";
                dataGridView1.Columns["precio"].HeaderText = "Precio";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.Columns["descripcionventa"].HeaderText = "Descripción";
                dataGridView1.Columns["total"].HeaderText = "Total";
                dataGridView1.Columns["nombre_producto"].HeaderText = "Producto";
                dataGridView1.Columns["precio"].DefaultCellStyle.Format = "C";
                dataGridView1.Columns["idventas"].DefaultCellStyle.Format = "N0";
            }
            cbproducto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbproducto.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbcliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbcliente.AutoCompleteSource = AutoCompleteSource.ListItems;

        }
        public class Venta
        {
            public int Id { get; set; }
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
        private BindingList<Venta> ventasTemporales = new BindingList<Venta>();
        private void AgregarVenta(int idProducto, int idCliente, int cantidad, decimal precio, string descripcion, decimal total)
        {
            string nombreProducto = ObtenerNombreProducto(idProducto);
            Venta venta = new Venta
            {
                Id = ventasTemporales.Count + 1,
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
        private void Cargarprecio()
        {
            using (SqlConnection conexion = new SqlConnection(Program.connectionString))
            {
                string query = "SELECT precio FROM productos WHERE nombre_producto = @nombre ";
                conexion.Open();
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@nombre", cbproducto.Text);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtprecio.Text = "";
                    txtprecio.Text = reader["precio"].ToString();
                    txtprecio.Text = Convert.ToDecimal(txtprecio.Text).ToString("N2");
                }
            }
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

                using (SqlConnection conexion = new SqlConnection(Program.connectionString))
                {
                    conexion.Open();
                    using (SqlCommand command = new SqlCommand(query, conexion))
                    {
                        command.Parameters.AddWithValue("@IDProducto", venta.IDProducto);
                        command.Parameters.AddWithValue("@IDCliente", venta.IDCliente);
                        command.Parameters.AddWithValue("@Fecha", venta.Fecha);
                        command.Parameters.AddWithValue("@Cantidad", venta.Cantidad);
                        command.Parameters.AddWithValue("@Precio", venta.Precio);
                        command.Parameters.AddWithValue("@Descripcion", venta.Descripcion);
                        command.Parameters.AddWithValue("@Total", venta.Total);


                        command.ExecuteNonQuery();
                    }
                    string query2 = "UPDATE productos " +
                                "SET cantidad = cantidad - @agregar " +
                                "WHERE id_producto = @nombre";

                    using (SqlCommand cmd = new SqlCommand(query2, conexion))
                    {
                        cmd.Parameters.AddWithValue("@nombre", venta.IDProducto);
                        cmd.Parameters.AddWithValue("@agregar", venta.Cantidad);
                        cmd.ExecuteNonQuery();

                    }
                    //advierte que el producto esta por agotarse
                    string query3 = "select cantidad from productos where id_producto = @idProducto";
                    using (SqlCommand cmd = new SqlCommand(query3, conexion))
                    {
                        cmd.Parameters.AddWithValue("@idProducto", venta.IDProducto);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            int cantidad = (int)reader["cantidad"];
                            if (cantidad <= 0)
                            {
                                MessageBox.Show("El producto " + venta.Producto + " esta por agotarse, solo quedan " + cantidad + " unidades.");
                            }
                        }
                        reader.Close();
                    }
                }
            }

            MessageBox.Show("Venta efectuada correctamente.");
            LimpiarVenta();
            dataTable.Clear();
            CargarDatos();
            lvtotal.Text = "L0.00";
        }

        private void LimpiarVenta()
        {
            ventasTemporales.Clear();
            MostrarVentasEnGridView();
            txtCodigo.Focus();
        }
        private void ventas_Load(object sender, EventArgs e)
        {
            CargarDatos();
            txtCodigo.Focus();
            LoadTheme();
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
            cbcliente.SelectedIndex = 0;
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidarCampos()
        {
            if (cbproducto.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un producto.");
                return false;
            }
            if (cbcliente.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un cliente.");
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

        private void AgregarProducto()
        {
            if (!ValidarCampos())
            {
                return;
            }
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
            dataGridViewVentas.ReadOnly = true;
            limpiarcampos();
        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            AgregarProducto();
            
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
            else if (e.KeyChar == (char)Keys.Enter)
            {
                AgregarProducto();
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

        private void EliminarLinea()
        {

            if (dataGridViewVentas.SelectedRows.Count > 0)
            {
                int index = dataGridViewVentas.SelectedRows[0].Index;

                dataGridViewVentas.Rows.RemoveAt(index);
                decimal totalVenta = 0;
                if (!ventasTemporales.Any())
                {
                    lvtotal.Text = "0";
                }
                foreach (Venta venta in ventasTemporales)
                {
                    totalVenta += venta.Total;
                    lvtotal.Text = totalVenta.ToString("C");

                }

            }

        }
        private void cbcliente_Click(object sender, EventArgs e)
        {
            cbcliente.DroppedDown = true;
        }

        private void BuscarProductoNuevo()
        {
            using (var context = new RestauranteContext())
            {
                var producto = context.Productos.FirstOrDefault(f => f.CodigoBarra == txtCodigo.Text.Trim());
                if (producto == null) return;
                txtprecio.Text = "";
                txtprecio.Text = producto.Precio.ToString();
                txtprecio.Text = Convert.ToDecimal(txtprecio.Text).ToString("N2");
                cbproducto.Items.Clear();
                string nombreProducto = producto.Nombre;
                int idProducto = producto.Id;
                cbproducto.Items.Add(new getProductos { ID = idProducto, Nombre = nombreProducto });
                cbproducto.SelectedIndex = 0;
                txtCodigo.Focus();
                txtCodigo.SelectAll();
                int cantidad = int.Parse(txtcantidad.Text);
                cantidad++;
                txtcantidad.Text = cantidad.ToString();
            }
        }

        private void cargarcodigo()
        {
            using (SqlConnection conexion = new SqlConnection(Program.connectionString))
            {
                string query = $"SELECT id_producto, nombre_producto, precio FROM productos WHERE codigo_barras = '{txtCodigo.Text.Trim()}' ";
                conexion.Open();
                SqlCommand cmd = new SqlCommand(query, conexion);
               // cmd.Parameters.AddWithValue("@Codigo", txtCodigo.Text);  

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtprecio.Text = "";
                    txtprecio.Text = reader["precio"].ToString();
                    txtprecio.Text = Convert.ToDecimal(txtprecio.Text).ToString("N2");
                    cbproducto.Items.Clear();
                    string nombreProducto = reader["nombre_producto"].ToString();
                    int idProducto = int.Parse(reader["id_producto"].ToString());
                    cbproducto.Items.Add(new getProductos { ID = idProducto, Nombre = nombreProducto });
                    cbproducto.SelectedIndex = 0;
                    
                }
                conexion.Close();
            }
            txtCodigo.Focus();
            txtCodigo.SelectAll();
            int cantidad = int.Parse(txtcantidad.Text);
            cantidad++;
            txtcantidad.Text = cantidad.ToString();
        }
        private void limpiarcampos()
        {
            txtCodigo.Clear();
            txtprecio.Clear();
            txtcantidad.Text = $"{0}";
            cbcliente.SelectedIndex = 0;
            cbproducto.SelectedIndex = -1;
            txtCodigo.Focus() ;
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Desea eliminar el producto de la lista?", "ELIMINAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                EliminarLinea();
                MessageBox.Show("Producto eliminado de la lista.");

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            EfectuarVenta();
            LimpiarVenta();
        }


        private void dataGridViewVentas_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cbcliente_TextChanged(object sender, EventArgs e)
        {


        }

        private void cbproducto_TextChanged(object sender, EventArgs e)
        {


        }

        private void btnregistro_Click(object sender, EventArgs e)
        {
            registro_ventas childForm = new registro_ventas();
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

        private void cbproducto_DropDownClosed(object sender, EventArgs e)
        {



        }

        private void cbproducto_SelectedValueChanged(object sender, EventArgs e)
        {
            Cargarprecio();
        }

        private void txtprecio_Click(object sender, EventArgs e)
        {
            txtprecio.Select(0, txtprecio.Text.Length);
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == (char)Keys.Enter)
            {
                cargarcodigo();
                //BuscarProductoNuevo();

            }
            if (e.KeyChar == (char)Keys.Space)
            {
                AgregarProducto();
                limpiarcampos();
            }
        }

        private void btnaceptar_Enter(object sender, EventArgs e)
        {
            
        }
    }
}
