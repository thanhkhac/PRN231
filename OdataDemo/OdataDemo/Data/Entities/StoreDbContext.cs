using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace OdataDemo.Data.Entities
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            var categories = new List<Category>
            {
                new Category { Id = 1, CategoryName = "Rau Củ" },
                new Category { Id = 2, CategoryName = "Thịt" },
                new Category { Id = 3, CategoryName = "Đồ Làm Bếp" }
            };

            var products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    ProductName = "Cà Rốt",
                    Brand = "Công Ty A",
                    Cost = 20,
                    Type = "Rau Củ",
                    ImageName = "Carrot.jpg",
                    CategoryId = 1
                },
                new Product
                {
                    Id = 2,
                    ProductName = "Cải Bó Xôi",
                    Brand = "Công Ty B",
                    Cost = 25,
                    Type = "Rau Củ",
                    ImageName = "Spinach.jpg",
                    CategoryId = 1
                },
                new Product
                {
                    Id = 3,
                    ProductName = "Súp Lơ",
                    Brand = "Công Ty C",
                    Cost = 30,
                    Type = "Rau Củ",
                    ImageName = "Cauliflower.jpg",
                    CategoryId = 1
                },
                new Product
                {
                    Id = 4,
                    ProductName = "Thịt Bò Mỹ",
                    Brand = "Công Ty D",
                    Cost = 150,
                    Type = "Thịt",
                    ImageName = "Beef.jpg",
                    CategoryId = 2
                },
                new Product
                {
                    Id = 5,
                    ProductName = "Thịt Gà Sạch",
                    Brand = "Công Ty E",
                    Cost = 80,
                    Type = "Thịt",
                    ImageName = "Chicken.jpg",
                    CategoryId = 2
                },
                new Product
                {
                    Id = 6,
                    ProductName = "Thịt Lợn Sạch",
                    Brand = "Công Ty F",
                    Cost = 70,
                    Type = "Thịt",
                    ImageName = "Pork.jpg",
                    CategoryId = 2
                },
                new Product
                {
                    Id = 7,
                    ProductName = "Chảo Inox 28cm",
                    Brand = "Công Ty G",
                    Cost = 250,
                    Type = "Đồ Làm Bếp",
                    ImageName = "Pan.jpg",
                    CategoryId = 3
                },
                new Product
                {
                    Id = 8,
                    ProductName = "Nồi Cơm Điện 1.8L",
                    Brand = "Công Ty H",
                    Cost = 350,
                    Type = "Đồ Làm Bếp",
                    ImageName = "RiceCooker.jpg",
                    CategoryId = 3
                },
                new Product
                {
                    Id = 9,
                    ProductName = "Máy Xay Sinh Tố",
                    Brand = "Công Ty I",
                    Cost = 400,
                    Type = "Đồ Làm Bếp",
                    ImageName = "Blender.jpg",
                    CategoryId = 3
                }
            };


            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Product>().HasData(products);
        }
    }
}