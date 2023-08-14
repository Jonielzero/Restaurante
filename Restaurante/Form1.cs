using Restaurante.Proveedores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurante
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        private Form2 formSecundario;
        private Proveedores.Proveedores provdiv;   
        private Clientes.Clientes clidiv;
        private Ventas.ventas ventdiv;
        private void button1_Click(object sender, EventArgs e)
        {
            //button1.Anchor = AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left;

            // Creamos una instancia de la segunda ventana (Form2)
            // Form2 segundaVentana = new Form2();

            // Mostramos la segunda ventana
            // segundaVentana.Show();

            // Crear una instancia del formulario secundario
           // Form2 formSecundario = new Form2
           // {
                //,

                // Mostrar el formulario secundario como formulario hijo del formulario principal
                // formSecundario.MdiParent = this; // Establece el formulario principal como el contenedor
                // formSecundario.Show();
                // Agregar el formulario secundario como control secundario del TableLayoutPanel
                // Crear un Panel para contener el formulario secundario
                //
            //};
            // Panel panelContenedor = new Panel();
            // panelContenedor.Dock = DockStyle.Fill;
            // panelContenedor.Controls.Add(formSecundario);

            // Agregar el Panel al TableLayoutPanel


            // Establecer propiedades del formulario secundario (si es necesario)

            

            if (formSecundario == null || formSecundario.IsDisposed || provdiv == null || provdiv.IsDisposed || ventdiv == null || ventdiv.IsDisposed || provdiv == null || provdiv.IsDisposed)
            {
                clidiv = new Clientes.Clientes();
                ventdiv = new Ventas.ventas();
                provdiv = new Proveedores.Proveedores();
                formSecundario = new Form2();
                formSecundario.FormBorderStyle = FormBorderStyle.None;
                formSecundario.TopLevel = false;
                formSecundario.TopLevel = false;
                formSecundario.Dock = DockStyle.Fill;
                tableLayoutPanel2.Controls.Add(formSecundario);         
                formSecundario.Show();
            }
            else
            {
                formSecundario.BringToFront();
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            //tableLayoutPanel1.Dock = DockStyle.Fill;
        }
       
        private void button4_Click(object sender, EventArgs e)
        {
            if (provdiv == null || provdiv.IsDisposed || formSecundario == null || formSecundario.IsDisposed || ventdiv == null || ventdiv.IsDisposed || provdiv == null || provdiv.IsDisposed)
            {
                clidiv = new Clientes.Clientes();
                ventdiv = new Ventas.ventas();
                formSecundario = new Form2();
                provdiv = new Proveedores.Proveedores();
                provdiv.FormBorderStyle = FormBorderStyle.None;
                provdiv.TopLevel = false;
                provdiv.TopLevel = false;
                provdiv.Dock = DockStyle.Fill;
                tableLayoutPanel2.Controls.Add(provdiv);
                provdiv.Show();
            }
            else
            {
                provdiv.BringToFront();
            }   
            
            

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //programa que el boton vaya a clientes de la misma manera que estan programados los demas botones
            if (clidiv == null || clidiv.IsDisposed || formSecundario == null || formSecundario.IsDisposed|| ventdiv == null || ventdiv.IsDisposed || provdiv == null || provdiv.IsDisposed)
            {
                ventdiv = new Ventas.ventas();
                provdiv = new Proveedores.Proveedores();
                formSecundario = new Form2();
                clidiv = new Clientes.Clientes();
                clidiv.FormBorderStyle = FormBorderStyle.None;
                clidiv.TopLevel = false;
                clidiv.TopLevel = false;
                clidiv.Dock = DockStyle.Fill;
                tableLayoutPanel2.Controls.Add(clidiv);
                clidiv.Show();
            }
            else
            {
                clidiv.BringToFront();
            }
            
        }

        private void Ventas_Click(object sender, EventArgs e)
        {
            //programa que este boton lleve a ventas de la misma manera que los demas botones
            if (ventdiv == null || ventdiv.IsDisposed || formSecundario == null || formSecundario.IsDisposed || clidiv == null || clidiv.IsDisposed || provdiv == null || provdiv.IsDisposed)
            {
                clidiv = new Clientes.Clientes();
                provdiv = new Proveedores.Proveedores();
                formSecundario = new Form2();
                ventdiv = new Ventas.ventas();
                ventdiv.FormBorderStyle = FormBorderStyle.None;
                ventdiv.TopLevel = false;
                ventdiv.TopLevel = false;
                ventdiv.Dock = DockStyle.Fill;
                tableLayoutPanel2.Controls.Add(ventdiv);
                ventdiv.Show();
            }
            else
            {
                ventdiv.BringToFront();
            }
        }
    }
}