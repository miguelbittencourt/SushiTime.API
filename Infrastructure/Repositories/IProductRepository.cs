using Infrastructure.Entities;

namespace Infrastructure.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(int id, UpdateProductDTO product);
        Task DeleteAsync(int id);
    }
}
