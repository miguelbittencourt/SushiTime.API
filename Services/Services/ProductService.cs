using Infrastructure.Entities;
using Infrastructure.Repositories;
using Services.Entities;

namespace Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<List<ProductDTO>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products.Select(x => ProductDTO.MapToDTO(x)).ToList();
        }

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            var responseProduct = ProductDTO.MapToDTO(product);
            return responseProduct;
        }

        public async Task AddAsync(ProductDTO product)
        {
            Product newProduct = new Product
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                Price = product.Price,
                ImageURL = product.ImageURL,
            };
            await _productRepository.AddAsync(newProduct);
        }

        public async Task UpdateAsync(int id, UpdateProductDTO product)
        {
            await _productRepository.UpdateAsync(id, product);
        }

        public async Task DeleteAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }
    }
}
