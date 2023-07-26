using mBay_Business.Repository.IRepository;
using mBay_Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mBay_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var response = await _categoryRepository.GetAll();
            if (response == null)
            {
                return BadRequest(new ErrorResponseDTO()
                {
                    ErrorMessage = "Kategori Bulunamadı.",
                    StatusCode = StatusCodes.Status404NotFound
                });

            }
            return Ok(response);
        }
    }
}
