using Microsoft.EntityFrameworkCore;

namespace SamplePrj.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                context.Database.EnsureCreated();
                // Look for any products.
                if (context.Products.Any())
                {
                    return;   // DB has been seeded
                }

                context.Products.AddRange(
                    new Product { Name = "Product1", Price = 10.0M },
                    new Product { Name = "Product2", Price = 20.0M },
                    new Product { Name = "Product3", Price = 30.0M }
                );

                context.SaveChanges();
            }
        }
    }
}
