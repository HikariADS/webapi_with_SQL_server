using Microsoft.EntityFrameworkCore.Diagnostics;
using WebApi_With_SQL_Server.Application.DTOs;

namespace WebApi_With_SQL_Server.Application.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto?> GetByIdAsync(int id);
        Task<ProductDto> CreateAsync(ProductDto dto);
        Task<ProductDto?> UpdateAsync(int id, ProductDto dto);
        Task<bool> DeleteAsync(int id);

    }
}
