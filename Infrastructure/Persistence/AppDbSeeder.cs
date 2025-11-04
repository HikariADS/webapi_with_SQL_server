using WebApi_With_SQL_Server.Domain.Entities;

namespace WebApi_With_SQL_Server.Infrastructure.Persistence
{
    public static class AppDbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            try
            {      
                if (context.Products.Any() || context.Categories.Any())
                    return;

                var categories = new List<Category>
                {
                    new() { Name = "Laptop" },
                    new() { Name = "Smartphone" },
                    new() { Name = "Accessory" },
                    new() { Name = "Tablet" }
                };

                context.Categories.AddRange(categories);
                context.SaveChanges();
               
                var products = new List<Product>
                {
                    new()
                    {
                        Name = "Dell XPS 13",
                        Price = 29000,
                        CategoryId = categories[0].Id
                    },
                    new()
                    {
                        Name = "MacBook Air M2",
                        Price = 34000,
                        CategoryId = categories[0].Id
                    },
                    new()
                    {
                        Name = "iPhone 16 Pro",
                        Price = 32000,
                        CategoryId = categories[1].Id
                    },
                    new()
                    {
                        Name = "Samsung Galaxy S24 Ultra",
                        Price = 28000,
                        CategoryId = categories[1].Id
                    },
                    new()
                    {
                        Name = "Logitech MX Master 3S",
                        Price = 2500,
                        CategoryId = categories[2].Id
                    },
                    new()
                    {
                        Name = "iPad Pro 2024",
                        Price = 26000,
                        CategoryId = categories[3].Id
                    }
                };

                context.Products.AddRange(products);
                context.SaveChanges(); 

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("✅ Database seeded successfully!");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"❌ Database seeding failed: {ex.Message}");
                Console.WriteLine($"   Inner: {ex.InnerException?.Message}");
                Console.ResetColor();
            }
        }
    }
}
