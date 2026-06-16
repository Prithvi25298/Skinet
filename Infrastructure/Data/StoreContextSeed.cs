
using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data;

public class StoreContextSeed
{
    public static async Task SeedAsync(StoreContext context)
    {
        try
        {
            if (!context.Products.Any())
            {
                var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                if (products == null) return;
                
                context.Products.AddRange(products);
                await context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            // Log the exception or handle it as needed
            Console.WriteLine($"An error occurred while seeding the database: {ex.Message}");
        }
    }
}
