using entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository:IProductRepository
    {
        MakeUpContext _makeUpContext;

        public ProductRepository(MakeUpContext makeUpContext)
        {
            this._makeUpContext = makeUpContext;
        }
        public async Task<List<Product>> GetProducts()
        {
            return await _makeUpContext.Products.Include(product => product.Category).ToListAsync();
            //return await _makeUpContext.Products.Include(product => product.Category).ToListAsync();

        }
        public async Task<Product> GetProductById(int id)
        {
            Product? product = await _makeUpContext.Products.FindAsync(id);//.Include(p => p.Category);
            return product != null ? product : null;
        }
        public async Task<Product> addProduct(Product product)
        {
            await _makeUpContext.Products.AddAsync(product);
            await _makeUpContext.SaveChangesAsync();
            return product;
        }
        public async Task<IEnumerable<Product>> getProductsBySearch(string? ProductName, int? minPrice, int? maxPrice, IEnumerable<string>? categoryId)
        {
            var query = _makeUpContext.Products.Where(product =>

                (ProductName == null ? (true) : product.ProductName.Contains(ProductName))
                    &&
                    (minPrice == null ? (true) : product.Price > minPrice)
                    &&
                    (maxPrice == null ? (true) : product.Price < maxPrice)
                    &&
                    (categoryId.Count() <= 0 ? (true) : categoryId.Contains(product.Category.CategoryId.ToString()))
        ).OrderBy(product => product.Price);

            return await query.ToListAsync();

        }

   



    }

}
