using System.ComponentModel.DataAnnotations;

namespace SampleApplication.Models
{
    public class FishModel
    {
        public int FishId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;
        [Required]
        public double Cost { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public int WaterTypeId { get; set; }
        [Required]
        public int AggressionLevel { get; set; }
        [Required]
        public int CountryId { get; set; }
    }
}
