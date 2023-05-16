using entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IProductRepository
    {
        Task<Product> addProduct(Product product);
        Task<Product> GetProductById(int id);
        Task<List<Product>> GetProducts();
        Task<IEnumerable<Product>> getProductsBySearch(string? ProductName, int? minPrice, int? maxPrice, IEnumerable<string>? categoryId);



    }
}
