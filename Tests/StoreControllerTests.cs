using Infrastructure.Entities;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Services.Entities;
using Services.Services;
using SushiTime.API.Controllers;

namespace Tests
{
    public class StoreControllerTests
    {
        [Fact]
        public void Should_Return_All_Products()
        {
            // Arrange
            var mockProductService = new Mock<IProductService>();
            var mockProductRepository = new Mock<IProductRepository>();
            var products = new List<Product>()
            {
                new Product { Id = 1, Name = "Produto 1", Description = "Primeiro Produto de Teste", Category = ECategories.Prato, ImageURL = "link da imagem"},
                new Product { Id = 2, Name = "Produto 2", Description = "Segundo Produto de Teste", Category = ECategories.Combo, ImageURL = "link da imagem"}
            };

            mockProductRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(products);
            mockProductService.Setup(x => x.GetAllAsync()).ReturnsAsync(mockProductRepository.Object.GetAllAsync().Result.Select(x => ProductDTO.MapToDTO(x)).ToList());

            var controller = new StoreController(mockProductService.Object);

            // Act
            var result = controller.GetAll();
            var okResult = Assert.IsType<OkObjectResult>(result.Result.Result);
            var returnedProducts = Assert.IsAssignableFrom<List<ProductDTO>>(okResult.Value);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(products.Count, returnedProducts.Count());
            Assert.Equal(products[0].Name, returnedProducts.First().Name);
            Assert.Equal(products[1].Name, returnedProducts.Last().Name);
        }

        //[Fact]
        //public void Should_Return_A_Product_And_Status_Code_Ok_When_Product_Exists()
        //{
        //    //Arrange
        //    var mockProductService = new Mock<IProductService>();
        //    var mockProductRepository = new Mock<IProductRepository>();

        //    var product = new Product
        //    {
        //        Id = 1,
        //        Name = "Produto",
        //        Description = "Descrição do produto",
        //        Category = ECategories.Prato,
        //        ImageURL = "link da imagem",
        //    };

        //    mockProductRepository.Setup(x => x.GetByIdAsync(product.Id)).ReturnsAsync(product);
        //    var productResponse = mockProductRepository.Object.GetByIdAsync(product.Id);
        //    mockProductService.Setup(x => x.GetByIdAsync(product.Id)).ReturnsAsync(ProductDTO.MapToDTO(productResponse.Result));

        //    var controller = new StoreController(mockProductService.Object);

        //    //Act
        //    var result = controller.GetById(product.Id).Result;
        //    var okResult = Assert.IsType<OkObjectResult>(result.Result);
        //    var returnedProduct = Assert.IsAssignableFrom<ProductDTO>(okResult.Value);

        //    //Assert
        //    Assert.NotNull(returnedProduct);
        //    Assert.Equal(product.Name, returnedProduct.Name);
        //}

        //[Fact]
        //public void Should_Return_NotFound_When_Product_Does_Not_Exists()
        //{
        //    //Arrange
        //    var mockProductService = new Mock<IProductService>();
        //    var mockProductRepository = new Mock<IProductRepository>();

        //    mockProductRepository.Setup(x => x.GetByIdAsync(1).IsCanceled == true);

        //    var controller = new StoreController(mockProductService.Object);

        //    //Act
        //    var result = controller.GetById(1);
        //    var notFoundResult = Assert.IsType<NotFoundResult>(result.Result.Result);

        //    //Assert
        //    Assert.Null(result);
        //}
    }
}