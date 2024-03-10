using System;
using System.Collections.Generic;

namespace FintasticFish.Data.Entities;

public partial class FishFood
{
    public int FishId { get; set; }

    public int FoodId { get; set; }

    public virtual Fish Fish { get; set; } = null!;

    public virtual Food Food { get; set; } = null!;
}
