using FirstProjectEmptyApp.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FirstProjectEmptyApp.Data
{
    public interface IArtPlaygroundRepository
    {
        IEnumerable<Product> GetAllPRoducts();
        IEnumerable<Product> GetProductsByCategory(string Category);

        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);
        public bool SaveAll();
        void AddEntity(object model);
    }
}