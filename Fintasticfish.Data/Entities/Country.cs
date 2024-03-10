using System;
using System.Collections.Generic;

namespace FintasticFish.Data.Entities;

public partial class Country
{
    public int CountyId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Fish> Fish { get; set; } = new List<Fish>();
}
