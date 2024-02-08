using Infrastructure.Entities;
using Infrastructure.Services;
using Services.Entities;

namespace Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductDataService _productDataService;
        public ProductService(IProductDataService productDataService)
        {
            _productDataService = productDataService;
        }
        public async Task<List<ProductDTO>> GetAllAsync()
        {
            var products = await _productDataService.GetAllAsync();
            return products.Select(x => ProductDTO.MapToDTO(x)).ToList();
        }

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            var product = await _productDataService.GetByIdAsync(id);
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
            await _productDataService.AddAsync(newProduct);
        }

        public async Task UpdateAsync(int id, UpdateProductDTO product)
        {
            await _productDataService.UpdateAsync(id, product);
        }

        public async Task DeleteAsync(int id)
        {
            await _productDataService.DeleteAsync(id);
        }
    }
}
