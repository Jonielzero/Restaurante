using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Restaurante
{
    internal static class Program
    {
        public static string permiso = "";
        public static string connectionString = "Data Source=DESKTOP-MARLON;Initial Catalog=Restaurante;User ID=Restaurante;Password=Marlon1234";

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form3());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar la solicitud: " + ex.Message);
            }

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();

                    Console.WriteLine("Conexión establecida con éxito.");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar con la base de datos: " + ex.Message);
                }

            }


        }

    }
}
