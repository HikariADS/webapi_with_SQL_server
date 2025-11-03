using Microsoft.AspNetCore.Mvc;
using WebApi_With_SQL_Server.Application.IServices;
using WebApi_With_SQL_Server.Application.DTOs;
using WebApi_With_SQL_Server.Api.Responses;

namespace WebApi_With_SQL_Server.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/products")]
    [Route("api/products")] 
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(ApiResponse<IEnumerable<ProductDto>>.Ok(result, "Fetched successfully (v1)"));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result == null
                ? NotFound(ApiResponse<string>.Fail("Product not found"))
                : Ok(ApiResponse<ProductDto>.Ok(result, "Fetched successfully"));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, ApiResponse<ProductDto>.Ok(result, "Created successfully"));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            return updated == null
                ? NotFound(ApiResponse<string>.Fail("Product not found"))
                : Ok(ApiResponse<ProductDto>.Ok(updated, "Updated successfully"));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            return deleted
                ? Ok(ApiResponse<string>.Ok("Deleted successfully"))
                : NotFound(ApiResponse<string>.Fail("Product not found"));
        }
    }
}
