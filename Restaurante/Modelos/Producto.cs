using System;

namespace Restaurante.Modelos
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaElaboracion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string CodigoBarra { get; set; }
    }
}
