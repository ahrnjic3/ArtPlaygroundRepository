using FirstProjectEmptyApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProjectEmptyApp.Data
{
    public class ArtPlaygroundRepository : IArtPlaygroundRepository
    {
        private readonly ArtPlaygroundContext _ctx;

        public ArtPlaygroundRepository(ArtPlaygroundContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Product> GetAllPRoducts()
        {
            return _ctx.Products.OrderBy(p => p.Title).ToList();
        }
        public IEnumerable<Product> GetProductsByCategory(string Category)
        {

            return _ctx.Products.Where(p => p.Category == Category).ToList();
        }

        public IEnumerable<Order> GetAllOrders() {
            return _ctx.Orders.Include(o=> o.Items).ThenInclude(o => o.Product).OrderBy(o => o.Id).ToList();
        }
        public bool SaveAll() {
            return _ctx.SaveChanges() > 0;
        }

        public Order GetOrderById(int id)
        {
            return _ctx.Orders.Include(o=> o.Items).ThenInclude(o=> o.Product).Where(o => o.Id == id).ToList().FirstOrDefault();
        }

        public void AddEntity(object model)
        {
            _ctx.Add(model);
        }
    }
}
