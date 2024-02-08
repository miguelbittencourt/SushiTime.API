using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class UpdateProductDTO
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required ECategories Category { get; set; }
        public double Price { get; set; }
        public DateTime UpdatedAt { get; set; }
        public required string ImageURL { get; set; }
    }
}
