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

            // Mostrar el formulario secundario
            if (formSecundario == null || formSecundario.IsDisposed)
            {
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
            
            Proveedores.Proveedores provdiv = new Proveedores.Proveedores();
           
            provdiv.FormBorderStyle = FormBorderStyle.None;
            provdiv.TopLevel = false;
            tableLayoutPanel2.Controls.Add(provdiv);
            provdiv.Dock = DockStyle.Fill;
            provdiv.BringToFront();
            provdiv.Show();
        }
    }
}