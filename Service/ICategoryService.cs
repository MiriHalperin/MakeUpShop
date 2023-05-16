using entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface ICategoryService
    {
        Task<Category> addCategory(Category category);
        Task<IEnumerable<Category>> GetCategories();

    }
}
