using System;
using System.Collections.Generic;

namespace SampleApplication.Entities;

public partial class Country
{
    public int CountyId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Fish> Fish { get; set; } = new List<Fish>();
}
