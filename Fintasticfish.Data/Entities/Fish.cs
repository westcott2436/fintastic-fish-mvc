using System;
using System.Collections.Generic;

namespace FintasticFish.Data.Entities;

public partial class Fish
{
    public int FishId { get; set; }

    public string Name { get; set; } = null!;

    public double Cost { get; set; }

    public int Stock { get; set; }

    public int WaterTypeId { get; set; }

    public int AggressionLevel { get; set; }

    public int CountryId { get; set; }

    public virtual Country Country { get; set; } = null!;
}
