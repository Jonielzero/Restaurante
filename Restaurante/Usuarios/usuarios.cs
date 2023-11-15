using Restaurante.Clientes;
using Restaurante.Proveedores;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Restaurante.Usuarios
{
    public partial class usuarios : Form
    {
        public usuarios()
        {
            InitializeComponent();
        }
        public static string contra = Convert.ToString(Encriptador.DecryptTextFromFile(@"C:\Users\Dell\Documents\Restaurante\Restaurante\Restaurante\Resources\cont.txt"));
        public static Image open = Image.FromFile(@"C:\Users\Dell\Documents\Restaurante\Restaurante\Restaurante\Resources\open.png");
        public static Image closed = Image.FromFile(@"C:\Users\Dell\Documents\Restaurante\Restaurante\Restaurante\Resources\clos.png");

        private void usuarios_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = closed;
            textBox2.PasswordChar = '*';
        }


        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox2.Text == contra)
            {

                if (Program.permiso == "cliente")
                {
                    Editar_clientes editar = new Editar_clientes();
                    editar.Show();
                    Program.permiso = "";
                    editar.BringToFront();
                    this.Hide();
                }
                else if (Program.permiso == "proveedores")
                {
                    editar_proveedores editar = new editar_proveedores();
                    editar.Show();
                    Program.permiso = "";
                    this.Close();
                    editar.BringToFront();
                }
                else if (Program.permiso == "producto")
                {
                    editarproducto editar = new editarproducto();
                    editar.Show();
                    Program.permiso = "";
                    this.Close();
                    editar.BringToFront();
                }
            }
            else
            {
                MessageBox.Show("Contraseña incorrecta");

            }

        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                button1_Click(sender, e);
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            if (pictureBox1.Image == closed)
            {
                pictureBox1.Image = open;
                textBox2.PasswordChar = '\0';
            }
            else
            {
                pictureBox1.Image = closed;
                textBox2.PasswordChar = '*';
            }
        }


    }
}
