﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace FintasticFish.Data.Entities;

public partial class OrdersFood
{
    public int OrderId { get; set; }

    public int FoodId { get; set; }

    public virtual Food Food { get; set; }

    public virtual Order Order { get; set; }
}