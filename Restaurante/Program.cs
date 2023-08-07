using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurante
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            string connectionString = "Data Source=DESKTOP-DRUTTH1;Initial Catalog=Restaurante;User ID=Restaurante;Password=marlon123";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    Console.WriteLine("Conexión establecida con éxito.");

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al conectarse a la base de datos: " + ex.Message);
                }

            }

            
        }
    }
}
