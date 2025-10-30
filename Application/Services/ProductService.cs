using AutoMapper;
using WebApi_With_SQL_Server.Application.DTOs;
using WebApi_With_SQL_Server.Application.IServices;
using WebApi_With_SQL_Server.Application.IRepositories;
using WebApi_With_SQL_Server.Domain.Entities;

namespace WebApi_With_SQL_Server.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var product = await _repo.GetByIdAsync(id);
            return product == null ? null : _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> CreateAsync(ProductDto dto)
        {
            var entity = _mapper.Map<Product>(dto);
            await _repo.AddAsync(entity);
            

            return _mapper.Map<ProductDto>(entity);
        }

        public async Task<ProductDto?> UpdateAsync(int id, ProductDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return null;

            _mapper.Map(dto, existing);
            _repo.Update(existing);
            

            return _mapper.Map<ProductDto>(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return false;

            _repo.Delete(existing);
            
            return true;
        }
    }
}
