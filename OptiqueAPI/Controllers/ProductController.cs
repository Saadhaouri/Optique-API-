using AutoMapper;
using Core.App.Dto.ProductDTO;
using Core.App.IServices;
using Microsoft.AspNetCore.Mvc;
using OptiqueAPI.ViewModels.Product;

namespace OptiqueAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduitService _produitService;
        private readonly IMapper _mapper;

        public ProductController(IProduitService produitService, IMapper mapper)
        {
            _produitService = produitService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _produitService.GetAllProducts();
            var productViewModels = _mapper.Map<IEnumerable<ProductViewModel>>(products);
            return Ok(productViewModels);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(Guid id)
        {
            var product = _produitService.GetProductById(id);
            if (product == null)
                return NotFound();

            var productViewModel = _mapper.Map<ProductViewModel>(product);
            return Ok(productViewModel);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] CreateUpdateProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var productDto = _mapper.Map<CreateUpdateProductDto>(productViewModel);
            _produitService.CreateProduct(productDto);

            return Ok("Prodcut Created successfully ");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(Guid id, [FromBody] CreateUpdateProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var productDto = _mapper.Map<CreateUpdateProductDto>(productViewModel);
                _produitService.UpdateProduct(id, productDto);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(Guid id)
        {
            var product = _produitService.GetProductById(id);
            if (product == null)
                return NotFound();

            _produitService.DeleteProduct(id);
            return NoContent();
        }
    }
}
