using Microsoft.EntityFrameworkCore;
using ProductProvider.Enums;
using ProductProvider.Models;
using System.Collections.Generic;

namespace ProductProvider.Contexts
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        public virtual DbSet<ProductEntity> Products { get; set; }
        public virtual DbSet<ProductSize> Sizes { get; set; }
        public virtual DbSet<ProductCategory> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductSize>(x =>
            {
                x.HasIndex(size => size.SizeName).IsUnique();
            });
            //modelBuilder.Entity<ProductSize>().HasData(
            //new ProductSize
            //{
            //    Id = 1,
            //    SizeName = ElectronicsEnum.None.ToString()
            //},
            //new ProductSize
            //{
            //    Id = 2,
            //    SizeName = ShoeSizeEnum.Size42.ToString()
            //},
            //new ProductSize
            //{
            //    Id = 3,
            //    SizeName = ClothingSizeEnum.S.ToString()
            //});


            //modelBuilder.Entity<ProductCategory>().HasData(
            //   new ProductCategory
            //   {
            //       Id = 1,
            //       Category = CategoryName.Clothing,
            //       SizeType = new ProductSize
            //       {
            //           Id = 3,
            //           SizeName = ClothingSizeEnum.S.ToString()
            //       }
            //   });
            //new ProductCategory
            //{
            //    Id = 2,
            //    Category = CategoryName.Electronics,
            //    SizeType = SizeType.None
            //},
            //new ProductCategory
            //{
            //    Id = 3,
            //    Category = CategoryName.Shoes,
            //    SizeType = SizeType.ShoeSize
            //});

            //modelBuilder.Entity<ProductEntity>().HasData(
            //new ProductEntity
            //{
            //    Id = 1,
            //    Brand = "Apple",
            //    Model = "iPhone 15",
            //    Description = "Latest iPhone model with advanced features.",
            //    Price = 1299.99M,
            //    CategoryId = 1,
            //    Category = new ProductCategory { Id = 1, SizeType = SizeType.None },
            //    Image = "https://example.com/images/iphone15.jpg",
            //    Stock = 50,
            //    SizeId = null,
            //    Size = null,
            //    AddedDate = DateOnly.FromDateTime(DateTime.Now)
            //},
            //new ProductEntity
            //{
            //    Id = 2,
            //    Brand = "Nike",
            //    Model = "Air Max 2024",
            //    Description = "Comfortable and stylish running shoes.",
            //    Price = 199.99M,
            //    CategoryId = 2,
            //    Category = new ProductCategory { Id = 2, SizeType = SizeType.ShoeSize },
            //    Image = "https://example.com/images/airmax2024.jpg",
            //    Stock = 150,
            //    SizeId = 1,
            //    Size = new ProductSize { Id = 1, Value = ShoeSizeEnum.Size45.ToString() },
            //    AddedDate = DateOnly.FromDateTime(DateTime.Now)
            //},
            //new ProductEntity
            //{
            //    Id = 3,
            //    Brand = "Samsung",
            //    Model = "Galaxy Tab S9",
            //    Description = "High-performance tablet for work and entertainment.",
            //    Price = 899.99M,
            //    CategoryId = 1,
            //    Category = new ProductCategory { Id = 1, SizeType = SizeType.None },
            //    Image = "https://example.com/images/galaxytabs9.jpg",
            //    Stock = 30,
            //    SizeId = null,
            //    Size = null,
            //    AddedDate = DateOnly.FromDateTime(DateTime.Now)
            //});





        }

    }
}
