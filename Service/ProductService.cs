using entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService : IProductService
    {
        IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }
        public async Task<List<Product>> GetProducts()
        {
            return await _productRepository.GetProducts();
        }
        public async Task<Product> GetProductById(int id)
        {
            return await _productRepository.GetProductById(id);
        }
        public async Task<Product> AddProduct(Product product)
        {
            return await _productRepository.addProduct(product);
        }
    

        public async Task<IEnumerable<Product>> getProductsBySearch(string? ProductName, int? minPrice, int? maxPrice, IEnumerable<string>? categoryId)
        {
            return await _productRepository.getProductsBySearch(ProductName, minPrice, maxPrice, categoryId);
        }


    }
}
