using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public required string Name { get; set; }

        [StringLength(200, MinimumLength = 10)]
        public required string Description { get; set; }
        public required ECategories Category { get; set; }

        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public required string ImageURL { get; set; }
    }
}
