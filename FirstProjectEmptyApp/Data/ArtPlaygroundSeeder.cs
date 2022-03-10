using FirstProjectEmptyApp.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FirstProjectEmptyApp.Data
{
    public class ArtPlaygroundSeeder
    {
        private readonly ArtPlaygroundContext _ctx;
        private readonly IWebHostEnvironment _env;

        public ArtPlaygroundSeeder( ArtPlaygroundContext ctx, IWebHostEnvironment env)
        {
            _ctx = ctx;
            _env = env;
        }
        public void Seed() {
            _ctx.Database.EnsureCreated(); // Checks if db is created.
            if (!_ctx.Products.Any()) {
                //Need to create sampel data
                var filePath = Path.Combine(_env.ContentRootPath, "Data/art.json");
                var json = File.ReadAllText(filePath);
                var products = JsonSerializer.Deserialize<IEnumerable<Product>>(json);
                _ctx.AddRange(products);
                var order = new Order()
                {
                    OrderDate = DateTime.Today,
                    OrderNumber = "1000",
                    Items = new List<OrderItem>() {
                        new OrderItem(){
                            Product = products.First(),
                            Quantity = 5,
                            UnitPrice=products.First().Price
                        }

                    }
                };
                _ctx.Orders.Add(order);
                _ctx.SaveChanges();
            }


        }
    }
}
