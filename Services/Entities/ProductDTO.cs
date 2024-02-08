using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Entities
{
    public class ProductDTO
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required ECategories Category { get; set; }
        public double Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public required string ImageURL { get; set; }

        public static ProductDTO MapToDTO(Product entity)
        {
            if (entity == null)
                throw new Exception("O item está nulo ou nao existe");

            ProductDTO mappedProduct = new ProductDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Category = entity.Category,
                Price = entity.Price,
                ImageURL = entity.ImageURL,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
            return mappedProduct;
        }
    }
}
