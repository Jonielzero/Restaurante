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

        private void button1_Click(object sender, EventArgs e)
        {
            // Creamos una instancia de la segunda ventana (Form2)
            Form2 segundaVentana = new Form2();

            // Mostramos la segunda ventana
            segundaVentana.Show();
        }
    }
}