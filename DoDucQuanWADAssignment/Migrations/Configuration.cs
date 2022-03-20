namespace DoDucQuanWADAssignment.Migrations
{
    using DoDucQuanWADAssignment.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DoDucQuanWADAssignment.Data.MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DoDucQuanWADAssignment.Data.MyDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var categories = new List<Category>
            {
                new Category{Id=1, Name="CD"},
                new Category{Id=2, Name="Vinyl"}
            };

            categories.ForEach(s => context.Category.AddOrUpdate(s));
            context.SaveChanges();


            var products = new List<Product>
            {
                new Product{
                    Id=1,
                    Name="Liberation CD",
                    CategoryId=1,
                    Price=10,
                    Thumbnail="https://upload.wikimedia.org/wikipedia/en/3/3f/Christina_Aguilera_-_Liberation_%28Official_Album_Cover%29.png"
                },
                new Product{
                    Id=2,
                    Name="Bionic CD",
                    CategoryId=1,
                    Price=8,
                    Thumbnail="https://upload.wikimedia.org/wikipedia/en/f/f5/Christina_Aguilera_-_Bionic_%28album%29.png"
                },
                new Product{
                    Id=3,
                    Name="folklore Vinyl",
                    CategoryId=2,
                    Price=23,
                    Thumbnail="https://upload.wikimedia.org/wikipedia/vi/f/f8/Taylor_Swift_-_Folklore.png"
                },
                new Product{
                    Id=4,
                    Name="Red Vinyl",
                    CategoryId=2,
                    Price=50,
                    Thumbnail="https://upload.wikimedia.org/wikipedia/vi/0/08/Red_Taylor%27s_Version.jpeg"
                }
            };

            products.ForEach(s => context.Product.AddOrUpdate(s));
            context.SaveChanges();
        }
    }
}
