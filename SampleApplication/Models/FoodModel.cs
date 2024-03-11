using System.ComponentModel.DataAnnotations;

namespace SampleApplication.Models
{
    public class FoodModel
    {
        [Required]
        public int FoodId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;
        [Required]
        public int Stock { get; set; }
        [Required]
        public double Cost { get; set; }
        [Required]
        public int FoodTypeId { get; set; }
    }
}
