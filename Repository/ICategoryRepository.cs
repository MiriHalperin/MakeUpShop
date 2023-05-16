using System;
using entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ICategoryRepository
    {

        public Task<IEnumerable<Category>> GetCategories();
        public Task<Category> addCategory(Category category);
    }
}
