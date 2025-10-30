using WebApi_With_SQL_Server.Application.IRepositories;
using WebApi_With_SQL_Server.Infrastructure.Persistence;
using WebApi_With_SQL_Server.Infrastructure.Repositories;

namespace WebApi_With_SQL_Server.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private readonly AppDbContext _context;

        public IProductRepository Products { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Products = new ProductRepository(context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
