﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FintasticFish.Data.Entities;

public partial class Measurement
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Fish> Fish { get; set; } = new List<Fish>();

    public virtual ICollection<Food> Foods { get; set; } = new List<Food>();

    public virtual ICollection<Plant> Plants { get; set; } = new List<Plant>();
}
