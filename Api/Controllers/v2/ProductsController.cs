using Microsoft.AspNetCore.Mvc;
using WebApi_With_SQL_Server.Application.IServices;
using WebApi_With_SQL_Server.Application.DTOs;
using WebApi_With_SQL_Server.Api.Responses;

namespace WebApi_With_SQL_Server.Api.Controllers.v2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly IWebHostEnvironment _env;

        public ProductsController(IProductService service, IWebHostEnvironment env)
        {
            _service = service;
            _env = env;
        }

        // GET with paging + search
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? search = null, int page = 1, int pageSize = 5)
        {
            var result = await _service.GetPagedAsync(search, page, pageSize);
            return Ok(ApiResponse<object>.Ok(result, "Fetched successfully (v2 with search + paging)"));
        }

        // Upload image
        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest(ApiResponse<string>.Fail("No file uploaded."));

            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
            Directory.CreateDirectory(folderPath);
            var filePath = Path.Combine(folderPath, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var relativePath = $"/images/{file.FileName}";
            return Ok(ApiResponse<string>.Ok(relativePath, "Image uploaded successfully."));
        }

        // Other CRUD inherited from v1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result == null
                ? NotFound(ApiResponse<string>.Fail("Product not found"))
                : Ok(ApiResponse<ProductDto>.Ok(result, "Fetched successfully"));
        }
    }
}
