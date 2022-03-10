using FirstProjectEmptyApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProjectEmptyApp.Data
{


    public class ArtPlaygroundContext : DbContext
    {
        private readonly IConfiguration _config;

        public ArtPlaygroundContext(IConfiguration config) {
            _config = config;
        }
        public DbSet<Product> Products  { get;set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_config["ConnectionStrings:ArtPlaygroundContextDb"]);

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>().HasData(
                new Order()
                {
                    Id = 1,
                    OrderDate=DateTime.Now,
                    OrderNumber="12345"
                }) ;
        }
    }
}
