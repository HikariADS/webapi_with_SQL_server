using WebApi_With_SQL_Server.Domain.Entities;

namespace WebApi_With_SQL_Server.Application.IRepositories
{
    public interface IProductRepository
    {
        // Lấy tất cả sản phẩm
        Task<IEnumerable<Product>> GetAllAsync();

        // Lấy sản phẩm theo ID
        Task<Product?> GetByIdAsync(int id);

        // Thêm mới sản phẩm
        Task AddAsync(Product entity);

        // Cập nhật sản phẩm
        void Update(Product entity);

        // Xóa sản phẩm
        void Delete(Product entity);

        // Lưu thay đổi
        Task SaveAsync();
    }
}
