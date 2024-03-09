namespace SampleApplication.Models
{
    public class FoodModel
    {

        public int FoodId { get; set; }

        public string Name { get; set; } = null!;

        public int Stock { get; set; }

        public double Cost { get; set; }

        public int FoodTypeId { get; set; }
    }
}
