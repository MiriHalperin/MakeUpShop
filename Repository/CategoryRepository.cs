using entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        MakeUpContext _makeUpContext;
        public CategoryRepository(MakeUpContext makeUpContext)
        {
            _makeUpContext = makeUpContext;
        }
        public async Task<Category> addCategory(Category category)
        {
            await _makeUpContext.Categories.AddAsync(category);
            await _makeUpContext.SaveChangesAsync();
            return category;
        }
        public async Task<IEnumerable<Category>> GetCategories()
        {
            var categories = await _makeUpContext.Categories.ToListAsync();
            return categories;
        }

       
    }
}
