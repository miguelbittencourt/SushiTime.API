using Infrastructure.Entities;
using System.ComponentModel.DataAnnotations;

namespace SushiTime.API.Models
{
    public class ProductViewModel
    {
        [StringLength(50, MinimumLength = 3)]
        public required string ProductName { get; set; }

        [StringLength(200, MinimumLength = 10)]
        public required string Description { get; set; }
        public required ECategories Category { get; set; }

        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        public required string ImageURL { get; set; }
    }
}
