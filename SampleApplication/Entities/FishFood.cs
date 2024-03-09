using System;
using System.Collections.Generic;

namespace SampleApplication.Entities;

public partial class FishFood
{
    public int FishId { get; set; }

    public int FoodId { get; set; }

    public virtual Fish Fish { get; set; } = null!;

    public virtual Food Food { get; set; } = null!;
}
