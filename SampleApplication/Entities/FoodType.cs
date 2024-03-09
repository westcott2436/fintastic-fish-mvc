using System;
using System.Collections.Generic;

namespace SampleApplication.Entities;

public partial class FoodType
{
    public int FoodTypeId { get; set; }

    public string Name { get; set; } = null!;
}
