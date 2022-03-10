using FirstProjectEmptyApp.Data.Entities;
using System.Collections.Generic;

namespace FirstProjectEmptyApp.Data
{
    public interface IArtPlaygroundRepository
    {
        IEnumerable<Product> GetAllPRoducts();
        IEnumerable<Product> GetProductsByCategory(string Category);

        public bool SaveAll();
    }
}