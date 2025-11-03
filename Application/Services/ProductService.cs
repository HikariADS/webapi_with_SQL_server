using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi_With_SQL_Server.Application.DTOs;
using WebApi_With_SQL_Server.Application.IRepositories;
using WebApi_With_SQL_Server.Application.IServices;
using WebApi_With_SQL_Server.Domain.Entities;
using WebApi_With_SQL_Server.Infrastructure.Persistence;

namespace WebApi_With_SQL_Server.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public ProductService(IProductRepository repo, IMapper mapper, AppDbContext context)
        {
            _repo = repo;
            _mapper = mapper;
            _context = context;
        }

        // -----------------------------
        // CRUD cơ bản (v1)
        // -----------------------------
        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var items = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(items);
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            return _mapper.Map<ProductDto?>(entity);
        }

        public async Task<ProductDto> CreateAsync(ProductDto dto)
        {
            var entity = _mapper.Map<Product>(dto);
            await _repo.AddAsync(entity); // ✅ repo đã tự SaveChangesAsync()
            return _mapper.Map<ProductDto>(entity);
        }

        public async Task<ProductDto?> UpdateAsync(int id, ProductDto dto)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) return null;

            _mapper.Map(dto, entity);
            _repo.Update(entity);           // ✅ không dùng UpdateAsync()
            await _repo.SaveAsync();        // ✅ giữ SaveAsync để commit DB
            return _mapper.Map<ProductDto>(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) return false;

            _repo.Delete(entity);           // ✅ không dùng DeleteAsync()
            await _repo.SaveAsync();
            return true;
        }

        // -----------------------------
        // 🆕 v2: Search + Paging
        // -----------------------------
        public async Task<object> GetPagedAsync(string? search, int page, int pageSize)
        {
            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(search))
                query = query.Where(p => p.Name.Contains(search));

            var total = await query.CountAsync();
            var items = await query
                .OrderBy(p => p.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new
            {
                page,
                pageSize,
                total,
                totalPages = (int)Math.Ceiling(total / (double)pageSize),
                items = _mapper.Map<IEnumerable<ProductDto>>(items)
            };
        }
    }
}
