using Services.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services;
using SushiTime.API.Models;
using Infrastructure.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Azure.Core;
using Microsoft.OpenApi.Extensions;

namespace SushiTime.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IProductService _productService;
        public StoreController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ProductDTO>> GetById([FromRoute] int id)
        {
            try
            {
                var product = await _productService.GetByIdAsync(id);
                return product;
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProductViewModel request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newProduct = new ProductDTO
            {
                Name = request.ProductName,
                Description = request.Description,
                Category = request.Category,
                Price = request.Price,
                ImageURL = request.ImageURL
            };
            await _productService.AddAsync(newProduct);
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ProductViewModel request)
        {
            var updatedProduct = new UpdateProductDTO
            {
                Name = request.ProductName,
                Description = request.Description,
                Category = request.Category,
                Price = request.Price,
                ImageURL = request.ImageURL
            };

            try
            {
                await _productService.UpdateAsync(id, updatedProduct);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _productService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
