using Infrastructure.Entities;
using Services.Entities;

namespace Services.Services
{
    public interface IProductService
    {
        public Task<List<ProductDTO>> GetAllAsync();
        public Task<ProductDTO> GetByIdAsync(int id);
        public Task AddAsync(ProductDTO product);
        public Task UpdateAsync(int id, UpdateProductDTO product);
        public Task DeleteAsync(int id);
    }
}
