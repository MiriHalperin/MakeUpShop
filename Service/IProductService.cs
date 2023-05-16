using entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IProductService
    {
        Task<Product> AddProduct(Product product);
        Task<Product> GetProductById(int id);
        Task<List<Product>> GetProducts();
        Task<IEnumerable<Product>> getProductsBySearch(string? desc, int? minPrice, int? maxPrice, IEnumerable<string>? categoryId);
    }
}
