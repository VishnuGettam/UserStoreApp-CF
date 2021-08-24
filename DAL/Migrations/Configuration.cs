namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.UserStoreDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.UserStoreDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            //Brands
            context.Brands.AddOrUpdate(new Brand() { BrandId = 1, BrandName = "Samsung" });
            context.Brands.AddOrUpdate(new Brand() { BrandId = 2, BrandName = "Toshiba" });
            context.Brands.AddOrUpdate(new Brand() { BrandId = 3, BrandName = "Nokia" });
            context.Brands.AddOrUpdate(new Brand() { BrandId = 4, BrandName = "Lg" });

            //Category
            context.Categories.AddOrUpdate(new Category() { CategoryId = 1, CategoryName = "Tv" });
            context.Categories.AddOrUpdate(new Category() { CategoryId = 2, CategoryName = "Mobile" });
            context.Categories.AddOrUpdate(new Category() { CategoryId = 3, CategoryName = "Fridge" });
            context.Categories.AddOrUpdate(new Category() { CategoryId = 4, CategoryName = "Oven" });
            context.Categories.AddOrUpdate(new Category() { CategoryId = 5, CategoryName = "Laptop" });
            context.Categories.AddOrUpdate(new Category() { CategoryId = 6, CategoryName = "Accesories" });

            //Product
            context.Products.AddOrUpdate(new Product() { Name = "Samsung Tv", DateofPurchase = DateTime.Now, UnitPrice = 5245, ProductImage = null, BrandId = 1, CategoryId = 1 });
            context.Products.AddOrUpdate(new Product() { Name = "Nokia Tv", DateofPurchase = DateTime.Now, UnitPrice = 845121, ProductImage = null, BrandId = 3, CategoryId = 1 });
            context.Products.AddOrUpdate(new Product() { Name = "Samsung Mobile", DateofPurchase = DateTime.Now, UnitPrice = 23145, ProductImage = null, BrandId = 1, CategoryId = 2 });
            context.Products.AddOrUpdate(new Product() { Name = "Lg Fridge", DateofPurchase = DateTime.Now, UnitPrice = 8953, ProductImage = null, BrandId = 4, CategoryId = 3 });
            context.Products.AddOrUpdate(new Product() { Name = "Toshina Laptop", DateofPurchase = DateTime.Now, UnitPrice = 01241, ProductImage = null, BrandId = 2, CategoryId = 5 });
            context.Products.AddOrUpdate(new Product() { Name = "Samsung Oven", DateofPurchase = DateTime.Now, UnitPrice = 8745, ProductImage = null, BrandId = 1, CategoryId = 4 });
            context.Products.AddOrUpdate(new Product() { Name = "Accessories", DateofPurchase = DateTime.Now, UnitPrice = 63636, ProductImage = null, BrandId = 3, CategoryId = 6 });
        }
    }
}