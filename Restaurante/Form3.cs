using Restaurante.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Linq;


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
            ActualizarFechaHora();
            MostrarSaludo();
            
            EstilizarEtiquetas();
            CargarImagenAleatoria();
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
        private void CargarImagenAleatoria()
        {
            string carpeta = @"C:\imagenes";

            if (!Directory.Exists(carpeta))
            {
                MessageBox.Show("No se encontró la carpeta de imágenes: " + carpeta);
                return;
            }

            string[] extensionesValidas = { ".jpg", ".jpeg", ".png", ".bmp" };
            string[] imagenes = Directory.GetFiles(carpeta)
                .Where(f => extensionesValidas.Contains(Path.GetExtension(f).ToLower()))
                .ToArray();

            if (imagenes.Length == 0)
            {
                MessageBox.Show("La carpeta no contiene imágenes válidas.");
                return;
            }

            int index = random.Next(imagenes.Length);

            using (var stream = new MemoryStream(File.ReadAllBytes(imagenes[index])))
            {
                this.BackgroundImage = Image.FromStream(stream);
            }

            this.BackgroundImageLayout = ImageLayout.Stretch;
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
           // Ventas.ventas formhijo = new Ventas.ventas(this);
        }
        public Panel obtrenerpanel()
        {
            return this.panelDesktopPanel;
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Productos.agregarproducto(this), sender);
            //Productos.agregarproducto formhijo = new Productos.agregarproducto(this);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Clientes.Clientes(this), sender);
            //Clientes.Clientes formhijo = new Clientes.Clientes(this);
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Proveedores.Proveedores(), sender);
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new Usuarios.usuarios(), sender);
        }

        private void panelLogo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm = null;
            }

            DisableButton();
            currentButton = null;
            lblTitle.Text = "Home";
        }
        private void MostrarSaludo()
        {
            int hora = DateTime.Now.Hour;
            string saludo;

            if (hora < 5)
            {
                saludo = "Buenas noches";
            }
            else if (hora < 12)
            {
                saludo = "Buenos días";
            }
            else if (hora < 19)
            {
                saludo = "Buenas tardes";
            }
            else
            {
                saludo = "Buenas noches";
            }

            lblBienvenida.Text = $"{saludo}";
            lblBienvenida.Font = new Font("Segoe UI Light", 18F, FontStyle.Regular);
            lblBienvenida.ForeColor = Color.FromArgb(250, 250, 250); // gris azulado oscuro, no negro puro
        }

        private void ActualizarFechaHora()
        {
            lblFechaHora.Text = DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy - hh:mm:ss tt",
                new System.Globalization.CultureInfo("es-ES"));
            //lblFechaHora.Font = new Font("Segoe UI Light", 11F, FontStyle.Regular);
            //lblFechaHora.ForeColor = Color.White; // gris medio, discreto
        }

        private void timerReloj_Tick(object sender, EventArgs e)
        {
            ActualizarFechaHora(); // se refresca cada segundo, incluyendo los segundos en vivo
        }

        private void EstilizarEtiquetas()
        {
            lblBienvenida.BackColor = Color.FromArgb(51, 51, 76);
            lblBienvenida.ForeColor = Color.White;
            lblBienvenida.Padding = new Padding(15, 8, 15, 8);
            lblBienvenida.AutoSize = true;

            lblFechaHora.BackColor = Color.WhiteSmoke;
            lblFechaHora.ForeColor = Color.Gainsboro; // gris muy claro, casi blanco — más suave que blanco puro
            lblFechaHora.Padding = new Padding(10, 5, 10, 5);
            lblFechaHora.AutoSize = true;
        }

        private void timerReloj_Tick_1(object sender, EventArgs e)
        {
            ActualizarFechaHora();
        }

        private void lblFechaHora_Click(object sender, EventArgs e)
        {

        }
    }
}
