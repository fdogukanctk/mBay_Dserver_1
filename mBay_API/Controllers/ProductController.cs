using mBay_Business.Repository.IRepository;
using mBay_Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mBay_API.Properties
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productRepository.GetAll());
        }
        [HttpGet("getpro/{productId}")]
        public async Task<IActionResult> Get(int? productId)
        {
            if (productId == null || productId == 0)
            {
                return BadRequest(new ErrorResponseDTO()
                {
                    ErrorMessage = "Geçersiz  Id",
                    StatusCode = StatusCodes.Status404NotFound
                });

            }
            var product = await _productRepository.GetById(productId.Value);
            if (product == null)
            {
                return BadRequest(new ErrorResponseDTO()
                {
                    ErrorMessage = "Geçersiz Id",
                    StatusCode = StatusCodes.Status404NotFound
                });

            }
            return Ok(product);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var result = await _productRepository.GetProductByCategoryId(id);
            if(result.Count == 0)
            {
                return BadRequest(new ErrorResponseDTO()
                {
                    ErrorMessage = "Ürün Bulunamadı.",
                    StatusCode = StatusCodes.Status404NotFound,
                });
            }
            return Ok(result);
        }
    }
}
