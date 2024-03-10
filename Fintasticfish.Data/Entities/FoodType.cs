using System;
using System.Collections.Generic;

namespace FintasticFish.Data.Entities;

public partial class FoodType
{
    public int FoodTypeId { get; set; }

    public string Name { get; set; } = null!;
}
