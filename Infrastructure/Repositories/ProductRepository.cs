using Infrastructure.Data;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dataContext;
        public ProductRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<Product>> GetAllAsync()
        {
            return await _dataContext.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var product = await _dataContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
                throw new Exception("O produto não existe");

            return product;
        }
        public async Task AddAsync(Product product)
        {
            product.CreatedAt = DateTime.Now;
            product.UpdatedAt = DateTime.Now;
            await _dataContext.Products.AddAsync(product);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, UpdateProductDTO updatedProduct)
        {
            var requestedProduct = await _dataContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (requestedProduct == null)
                throw new Exception("O produto não existe");

            requestedProduct.Name = updatedProduct.Name;
            requestedProduct.Description = updatedProduct.Description;
            requestedProduct.Category = updatedProduct.Category;
            requestedProduct.Price = updatedProduct.Price;
            requestedProduct.UpdatedAt = DateTime.Now;

            _dataContext.Products.Update(requestedProduct);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _dataContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
                throw new Exception("O produto não existe");

            _dataContext.Products.Remove(product);
            await _dataContext.SaveChangesAsync();
        }
    }
}
