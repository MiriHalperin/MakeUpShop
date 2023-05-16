using AutoMapper;
using entities;
using Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyShop.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryService _categoryService;
        IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
           _categoryService = categoryService;
            _mapper = mapper;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            IEnumerable<Category> categories = await _categoryService.GetCategories();
            IEnumerable<CategoryDTO> categoryDTOs = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(categories);
            return categoryDTOs.Count() > 0 ? Ok(categoryDTOs) : NoContent();
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> Post([FromBody] CategoryDTO categoryDto)
        {
            Category category = _mapper.Map<CategoryDTO, Category>(categoryDto);
            Category newCategory = await _categoryService.addCategory(category);
            CategoryDTO newCategoryDTO = _mapper.Map<Category, CategoryDTO>(newCategory);
            return newCategoryDTO != null ? Ok(newCategoryDTO) : BadRequest();
        }

    }
}
