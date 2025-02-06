using Restaurante.Modelos;
using System.Data.Entity.ModelConfiguration;

namespace Restaurante._Infrastructure.Maps
{
    public class ProductoMap : EntityTypeConfiguration<Producto>
    {
        public ProductoMap()
        {
            ToTable("Productos");

            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("id_producto");
            Property(x => x.Nombre).HasColumnName("nombre_producto");
            Property(x => x.Precio).HasColumnName("precio");
            Property(x => x.Cantidad).HasColumnName("cantidad");
            Property(x => x.FechaElaboracion).HasColumnName("f_elaboracion");
            Property(x => x.FechaVencimiento).HasColumnName("f_vencimiento");
            Property(x => x.CodigoBarra).HasColumnName("codigo_barras");
        }
    }
}
