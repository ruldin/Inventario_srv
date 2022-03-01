using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class InventaryContext : DbContext 
    {
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<StorageEntity> Storages { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<InputOutputEntity> InOuts { get; set; }
        public DbSet<WarehouseEntity> Warehouses { get; set; }

       protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //verificar si no se ha configurado en otro lado
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Server=LT-RULDIN-LENOV\\SQLEXPRESS2019;Database=InventoryDB;Trusted_Connection=True");
            }
        }


        //para precargar datos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CategoryEntity>().HasData(
                new CategoryEntity{
                    CategoryId = "ASH",
                    CategoryName = "Aseo Hogar"
                },
                new CategoryEntity { CategoryId = "ASP", CategoryName = "Aseo Personal" },
                new CategoryEntity { CategoryId = "HGR", CategoryName = "Hogar" },
                new CategoryEntity { CategoryId = "PRF", CategoryName = "Perfumería" },
                new CategoryEntity { CategoryId = "SLD", CategoryName = "Salud" },
                new CategoryEntity { CategoryId = "VDJ", CategoryName = "Video Juegos" }
                );

            modelBuilder.Entity<WarehouseEntity>().HasData(
                new WarehouseEntity { WarehouseId = Guid.NewGuid().ToString(), WarehouseName = "Bodega Central", WarehouseAddress = "Calle 8 con 23" },
                new WarehouseEntity { WarehouseId = Guid.NewGuid().ToString(), WarehouseName = "Bodega Norte", WarehouseAddress = "Calle norte con occidente" }
                );

            modelBuilder.Entity<ProductEntity>().HasData(
                new ProductEntity { ProductId = "ASJ-98", ProductName = "Crema para manos marca Tersa", ProductDescription = "", CategoryId = "PRF" },
                new ProductEntity { ProductId = "RPT-54", ProductName = "Pastillas para la garganta LESUS", ProductDescription = "", CategoryId = "SLD" }
                );



        }

    }
}
