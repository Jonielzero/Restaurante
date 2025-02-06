using Restaurante.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Restaurante
{
    public partial class Form3 : Form
    {
        private Button currentButton;
        private Random random;
        private int tempIndex;
        public Form activeForm;
        public Form3()
        {
            InitializeComponent();
            random = new Random();
        }
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;  
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                }
            }
        }
        private void DisableButton()
        {
            foreach(Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }
        public void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPanel.Controls.Add(childForm);
            this.panelDesktopPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }


        private void Form3_Load(object sender, EventArgs e)
        {
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Ventas.ventas(this), sender);
            Ventas.ventas formhijo = new Ventas.ventas(this);
        }
        public Panel obtrenerpanel()
        {
            return this.panelDesktopPanel;
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Productos.agregarproducto(this), sender);
            Productos.agregarproducto formhijo = new Productos.agregarproducto(this);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Clientes.Clientes(this), sender);
            Clientes.Clientes formhijo = new Clientes.Clientes(this);
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Proveedores.Proveedores(), sender);
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new Usuarios.usuarios(), sender);
        }

       
    }
}
