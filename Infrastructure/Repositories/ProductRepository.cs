using Microsoft.EntityFrameworkCore;
using WebApi_With_SQL_Server.Application.IRepositories;
using WebApi_With_SQL_Server.Domain.Entities;
using WebApi_With_SQL_Server.Infrastructure.Persistence;

namespace WebApi_With_SQL_Server.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Product entity)
        {
            await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync(); // ✅ thêm Save trực tiếp để insert nhanh
        }

        public void Update(Product entity)
        {
            _context.Products.Update(entity);
        }

        public void Delete(Product entity)
        {
            _context.Products.Remove(entity);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
