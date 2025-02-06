using ReaLTaiizor.Extension;
using Restaurante._Infrastructure.Maps;
using Restaurante.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante._Infrastructure
{
    public class RestauranteContext : DbContext
    {

        public RestauranteContext() : base(Program.connectionString)
        {

        }

        public virtual DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
