using AutoMapper;
using entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;


namespace MyShop.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductService _productService;
        IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            this._productService = productService;
            this._mapper = mapper;
        }

        // GET: api/<ProductController>
        [HttpGet]
        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> Get()
        {
            List<Product> products = await _productService.GetProducts();
            List<ProductDTO> productsDTO = _mapper.Map<List<Product>, List<ProductDTO>>(products);
            return productsDTO == null ? NoContent() : Ok(productsDTO);
        }

        [HttpGet("search")]
        public async Task<IEnumerable<ProductDTO>> GetbySearch([FromQuery] IEnumerable<string>? categoryId, string? ProductName, int? minPrice, int? maxPrice)
        {
            IEnumerable<Product> products = await _productService.getProductsBySearch(ProductName, minPrice, maxPrice, categoryId);
            IEnumerable<ProductDTO> productsDTO = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);
            return productsDTO;

        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<ActionResult<ProductDTO>> Post([FromBody] ProductDTO productDTO)
        {
            Product product = _mapper.Map<ProductDTO, Product>(productDTO);
            Product addProduct = await _productService.AddProduct(product);
            if (addProduct != null)
            {
                ProductDTO addProductDTO = _mapper.Map<Product, ProductDTO>(addProduct);
                return CreatedAtAction(nameof(Get), new { id = addProductDTO.ProductId }, addProductDTO);
            }
            return BadRequest();
        }


    }
    
}
