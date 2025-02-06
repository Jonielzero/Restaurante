using Restaurante.Clases;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace Restaurante
{
    public partial class editarproducto : Form
    {
        public editarproducto()
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

            foreach (Control tbs in panel1.Controls)
            {
                if (tbs.GetType() == typeof(TextBox))
                {
                    TextBox tb = (TextBox)tbs;
                    tb.BackColor = ThemeColor.SecondaryColor;
                    tb.ForeColor = Color.White;

                }
            }


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
        private void limpiar()
        {
            txtid.Text = "";
            txtprecio.Text = "";
            txtcantidad.Text = "";
            txtnombre.Text = "";
            dtpelaboracion.Value = DateTime.Now;
            dtpvencimiento.Value = DateTime.Now;
            cbproveedores.SelectedIndex = -1;
        }
        private void CargarDatos()
        {
            using (SqlConnection conexion = new SqlConnection(Program.connectionString))
            {
                string query = "SELECT i.nombre_producto, i.precio, i.cantidad, i.f_elaboracion, i.f_vencimiento, p.nombre_proveedor FROM productos i JOIN proveedores p ON i.proveedor = p.id_proveedor WHERE id_producto = @id ";
                conexion.Open();
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@id", txtid.Text);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtprecio.Text = "";
                    txtcantidad.Text = "";
                    txtnombre.Text = "";
                    dtpelaboracion.Value = DateTime.Now;
                    dtpvencimiento.Value = DateTime.Now;
                    cbproveedores.SelectedIndex = -1;
                    txtnombre.Text = reader["nombre_producto"].ToString();
                    txtcantidad.Text = reader["cantidad"].ToString();
                    dtpelaboracion.Value = Convert.ToDateTime(reader["f_elaboracion"].ToString());
                    dtpvencimiento.Value = Convert.ToDateTime(reader["f_vencimiento"].ToString());
                    cbproveedores.Text = reader["nombre_proveedor"].ToString();
                    txtprecio.Text = reader["precio"].ToString();
                    txtprecio.Text = Convert.ToDecimal(txtprecio.Text).ToString("N2");
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtid.Text);
            Proveedores proveedorid = (Proveedores)cbproveedores.SelectedItem;
            string nombre = txtnombre.Text;
            if (string.IsNullOrEmpty(txtprecio.Text))
            {
                MessageBox.Show("el campo nombre no puede estar en blanco");
                return;
            }
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
                // actuali mediante sql

                string query = "UPDATE Productos SET nombre_producto = @NuevoNombre, precio = @NuevoPrecio, cantidad = @NuevaCantidad, f_elaboracion = @NuevaF_Elab, f_vencimiento = @NuevaF_venc, proveedor =@NuevoProveedor WHERE id_producto = @ID";
                using (SqlConnection conexion = new SqlConnection(Program.connectionString))
                {


                    using (SqlCommand command = new SqlCommand(query, conexion))
                    {
                        conexion.Open();
                        // Agrega parámetros a la consulta para prevenir SQL injection
                        command.Parameters.AddWithValue("@Nuevonombre", nombre);
                        command.Parameters.AddWithValue("@NuevoPrecio", precio);
                        command.Parameters.AddWithValue("@NuevaCantidad", cantidad);
                        command.Parameters.AddWithValue("@Nuevaf_elab", fechaelaboracion);
                        command.Parameters.AddWithValue("@Nuevaf_venc", fechavencimiento);
                        command.Parameters.AddWithValue("@Nuevoproveedor", proveedor);
                        command.Parameters.AddWithValue("@ID", id);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Registro actualizado correctamente.");
                        }
                        else
                        {
                            MessageBox.Show("No se pudo encontrar el registro con el ID proporcionado.");
                        }

                    }
                }
            }
            limpiar();
        }

        private void editarproducto_Load(object sender, EventArgs e)
        {
            LoadTheme();
            limpiar();
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
        }

        private void cbproveedores_Click(object sender, EventArgs e)
        {
            cbproveedores.DropDownStyle = ComboBoxStyle.DropDownList; // Cambia el estilo para desplegar la lista
            cbproveedores.Focus(); // Establece el foco en el ComboBox
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtid.Text);

                string query = "DELETE FROM Productos WHERE id_producto = @ID";

                using (SqlConnection conexion = new SqlConnection(Program.connectionString))
                {
                    conexion.Open();

                    using (SqlCommand command = new SqlCommand(query, conexion))
                    {
                        command.Parameters.AddWithValue("@ID", id);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Registro eliminado correctamente.");
                        }
                        else
                        {
                            MessageBox.Show("No se pudo encontrar el registro con el ID proporcionado.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede eliminar un productoque ha sido vendido " + ex.Message);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbproveedores_KeyPress(object sender, KeyPressEventArgs e)
        {
            cbproveedores.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void txtprecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '.')
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

        private void txtid_Enter(object sender, EventArgs e)
        {

        }

        private void txtid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                CargarDatos();
            }
        }
    }
}
