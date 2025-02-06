using Restaurante.Clases;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace Restaurante.Ventas
{
    public partial class registro_ventas : Form
    {
        public registro_ventas()
        {
            InitializeComponent();
            LoadTheme();
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
            foreach (Control btns in panel2.Controls)
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
            foreach (Control lbs in panel3.Controls)
            {
                if (lbs.GetType() == typeof(Label))
                {
                    Label lbl = (Label)lbs;
                    lbl.ForeColor = ThemeColor.PrimaryColor;
                    lbl.Font = Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                }
            }
            foreach (Control lbs in panel1.Controls)
            {
                if (lbs.GetType() == typeof(Label))
                {
                    Label lbl = (Label)lbs;
                    lbl.ForeColor = ThemeColor.PrimaryColor;
                    lbl.Font = Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

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
        private DataTable dataTable;

        private void btnbus_Click(object sender, EventArgs e)
        {
            string txtbuscar = txtbus.Text;
            string query2 = "SELECT v.idventas, p.nombre_producto, c.nombre cliente, v.fechaventa, v.precio, " +
                "v.cantidad, v.descripcionventa, v.total FROM Ventas v " +
                "JOIN productos p on v.idproductos = p.id_producto " +
                "JOIN clientes c on v.id_clientes = c.idclientes  " +
                "WHERE p.nombre_producto LIKE '%" + txtbuscar + "%' OR c.nombre LIKE '%" + txtbuscar + "%' OR v.idventas LIKE '%" + txtbuscar + "%' " +
                "ORDER BY idventas DESC";
            using (SqlConnection conexion = new SqlConnection(Program.connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query2, conexion);
                dataTable = new DataTable();

                dataAdapter.Fill(dataTable);
                dgv1.DataSource = dataTable;
                dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
            decimal total = 0;
            for (int i = 0; i < dgv1.Rows.Count; i++)
            {
                total += Convert.ToDecimal(dgv1.Rows[i].Cells["total"].Value);
            }
            Lbtotal.Text = total.ToString("C");
        }
        private void cargardatos()
        {
            string query2 = "SELECT v.idventas, p.nombre_producto, c.nombre cliente, v.fechaventa, v.precio, " +
                "v.cantidad, v.descripcionventa, v.total FROM Ventas v " +
                "JOIN productos p on v.idproductos = p.id_producto " +
                "JOIN clientes c on v.id_clientes = c.idclientes  " +
                "ORDER BY idventas DESC";
            using (SqlConnection conexion = new SqlConnection(Program.connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query2, conexion);
                dataTable = new DataTable();

                dataAdapter.Fill(dataTable);
                dgv1.DataSource = dataTable;
                dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //hace que la columna precio se muestre con formato de moneda
                dgv1.Columns["precio"].DefaultCellStyle.Format = "c";
                dgv1.Columns["total"].DefaultCellStyle.Format = "c";
                dgv1.Columns["fechaventa"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm:ss";
                dgv1.Columns["idventas"].HeaderCell.Value = "ID";
                dgv1.Columns["nombre_producto"].HeaderCell.Value = "Producto";
                dgv1.Columns["cliente"].HeaderCell.Value = "Cliente";
                dgv1.Columns["fechaventa"].HeaderCell.Value = "Fecha";
                dgv1.Columns["precio"].HeaderCell.Value = "Precio";
                dgv1.Columns["cantidad"].HeaderCell.Value = "Cantidad";
                dgv1.Columns["descripcionventa"].HeaderCell.Value = "Descripcion";
                dgv1.Columns["total"].HeaderCell.Value = "Total";
                decimal total = 0;
                for (int i = 0; i < dgv1.Rows.Count; i++)
                {
                    total += Convert.ToDecimal(dgv1.Rows[i].Cells["total"].Value);
                }
                Lbtotal.Text = total.ToString("C");
            }

        }
        private void registro_ventas_Load(object sender, EventArgs e)
        {
            cargardatos();
            cbbus.Items.Add("Ultima Semana");
            cbbus.Items.Add("Ultimo Mes");
            cbbus.Items.Add("Ultimo Año");
            cbbus.Items.Add("Buscar por Mes");
            cbmes.Items.Add(" ... ");
            cbmes.Items.Add("Enero");
            cbmes.Items.Add("Febrero");
            cbmes.Items.Add("Marzo");
            cbmes.Items.Add("Abril");
            cbmes.Items.Add("Mayo");
            cbmes.Items.Add("Junio");
            cbmes.Items.Add("Julio");
            cbmes.Items.Add("Agosto");
            cbmes.Items.Add("Septiembre");
            cbmes.Items.Add("Octubre");
            cbmes.Items.Add("Noviembre");
            cbmes.Items.Add("Diciembre");
            cbbus.SelectedIndex = 1;
            cbmes.SelectedIndex = 0;

        }

        private void tlp1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void buscarpormes()
        {

        }
        private void btnbusmes_Click(object sender, EventArgs e)
        {
            string seleccion = cbbus.SelectedItem.ToString();
            string mess = cbmes.SelectedItem.ToString();
            string busqueda = "";
            string ano = "";
            if (txtano.Text == "")
            {
                ano = "YEAR(GETDATE()) ";
            }
            else
            {
                ano = txtano.Text;
            }
            if (seleccion == "Ultimo Mes")
            {
                busqueda = "fechaventa >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0)  AND fechaventa <= GETDATE() ";
            }
            else if (seleccion == "Ultimo Año")
            {
                busqueda = "fechaventa >= DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE()), 0)  AND fechaventa <= GETDATE() ";
            }
            else if (seleccion == "Ultima Semana")
            {
                busqueda = "fechaventa >= DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()), 0)  AND fechaventa <= GETDATE() ";
            }
            else if (seleccion == "Buscar por Mes")
            {

                if (mess == "Enero")
                {
                    busqueda = "DATEPART(MONTH, FechaVenta) = 1  AND YEAR(FechaVenta) = " + ano;
                }
                else if (mess == "Febrero")
                {
                    busqueda = "DATEPART(MONTH, FechaVenta) = 2  AND YEAR(FechaVenta) = " + ano;
                }
                else if (mess == "Marzo")
                {
                    busqueda = "DATEPART(MONTH, FechaVenta) = 3  AND YEAR(FechaVenta) = " + ano;

                }
                else if (mess == "Abril")
                {
                    busqueda = "DATEPART(MONTH, FechaVenta) = 4  AND YEAR(FechaVenta) = " + ano;

                }
                else if (mess == "Mayo")
                {
                    busqueda = "DATEPART(MONTH, FechaVenta) = 5  AND YEAR(FechaVenta) = " + ano;

                }
                else if (mess == "Junio")
                {
                    busqueda = "DATEPART(MONTH, FechaVenta) = 6  AND YEAR(FechaVenta) = " + ano;
                }
                else if (mess == "Julio")
                {
                    busqueda = "DATEPART(MONTH, FechaVenta) = 7  AND YEAR(FechaVenta) = " + ano;
                }
                else if (mess == "Agosto")
                {
                    busqueda = "DATEPART(MONTH, FechaVenta) = 8  AND YEAR(FechaVenta) = " + ano;
                }
                else if (mess == "Septiembre")
                {
                    busqueda = "DATEPART(MONTH, FechaVenta) = 9  AND YEAR(FechaVenta) = " + ano;
                }
                else if (mess == "Octubre")
                {
                    busqueda = "DATEPART(MONTH, FechaVenta) = 10  AND YEAR(FechaVenta) = " + ano;
                }
                else if (mess == "Noviembre")
                {
                    busqueda = "DATEPART(MONTH, FechaVenta) = 11  AND YEAR(FechaVenta) = " + ano;
                }
                else if (mess == "Diciembre")
                {
                    busqueda = "DATEPART(MONTH, FechaVenta) = 12  AND YEAR(FechaVenta) = " + ano;
                }
                else
                {
                    MessageBox.Show("Seleccione un mes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            string query2 = "SELECT v.idventas, p.nombre_producto, c.nombre cliente, v.fechaventa, v.precio, " +
                "v.cantidad, v.descripcionventa, v.total FROM Ventas v " +
                "JOIN productos p on v.idproductos = p.id_producto " +
                "JOIN clientes c on v.id_clientes = c.idclientes  " +
                "WHERE " + busqueda + "ORDER BY idventas DESC";
            using (SqlConnection conexion = new SqlConnection(Program.connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query2, conexion);
                dataTable = new DataTable();

                dataAdapter.Fill(dataTable);
                dgv1.DataSource = dataTable;
                dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
            decimal total = 0;
            for (int i = 0; i < dgv1.Rows.Count; i++)
            {
                total += Convert.ToDecimal(dgv1.Rows[i].Cells["total"].Value);
            }
            Lbtotal.Text = total.ToString("C");
        }

        private void txtano_KeyPress(object sender, KeyPressEventArgs e)
        {
            //valida que solo se ingresen numeros y no mas 4 digitos
            if (char.IsDigit(e.KeyChar))
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

            if (txtano.Text.Length == 4)
            {
                e.Handled = true;
            }

        }

        private void cbmes_Click(object sender, EventArgs e)
        {
            cbmes.DropDownStyle = ComboBoxStyle.DropDownList;

            cbmes.DroppedDown = true;
        }

        private void cbbus_Click(object sender, EventArgs e)
        {
            cbbus.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}
