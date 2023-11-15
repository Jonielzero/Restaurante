using System;
using System.Windows.Forms;

namespace Restaurante.Usuarios
{
    public partial class Contra : Form
    {
        public Contra()
        {
            InitializeComponent();
        }
        private void btnaceptar_Click(object sender, EventArgs e)
        {
            string Contras = usuarios.contra;
            if (txtcontra.Text == Contras)
            {
                if (txtnueva.Text == "" || txtrepetir.Text == "")
                {
                    MessageBox.Show("No puede dejar campos vacios");
                }
                else
                {
                    if (txtnueva.Text == txtrepetir.Text)
                    {
                        Encriptador.EncryptTextToFile(txtnueva.Text, @"C:\Users\Dell\Documents\Restaurante\Restaurante\Restaurante\Resources\cont.txt");
                        MessageBox.Show("Contraseña cambiada debe cerrar y volver a abrir la aplicacion");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Las contraseñas no coinciden");
                    }
                }
            }
            else
            {
                MessageBox.Show("Contraseña incorrecta");
            }
        }



        private void Contra_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = usuarios.closed;
            txtcontra.PasswordChar = '*';
            txtnueva.PasswordChar = '*';
            txtrepetir.PasswordChar = '*';
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == usuarios.closed)
            {
                pictureBox1.Image = usuarios.open;
                txtcontra.PasswordChar = '\0';
                txtnueva.PasswordChar = '\0';
                txtrepetir.PasswordChar = '\0';
            }
            else
            {
                pictureBox1.Image = usuarios.closed;
                txtcontra.PasswordChar = '*';
                txtnueva.PasswordChar = '*';
                txtrepetir.PasswordChar = '*';
            }
        }

        private void txtcontra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtnueva.Focus();
            }
        }

        private void txtnueva_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtrepetir.Focus();
            }
        }

        private void txtrepetir_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnaceptar_Click(sender, e);
            }
        }
    }
}
